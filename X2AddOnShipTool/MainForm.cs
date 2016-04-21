using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using DRSLibrary;

namespace X2AddOnShipTool
{
	/// <summary>
	/// Hauptformular.
	/// </summary>
	public partial class MainForm : Form
	{
		#region Konstanten

		/// <summary>
		/// Die Standard-Hintergrundfarbe.
		/// </summary>
		private Color COLOR_BACKGROUND = Color.FromArgb(243, 233, 212);

		/// <summary>
		/// Die Standard-Schattenfarbe.
		/// </summary>
		private Color COLOR_SHADOW = Color.FromArgb(100, 100, 100, 100);

		/// <summary>
		/// Der vertikale Abstand der Eckpunkte eines Tiles zu dessen Mittelpunkt.
		/// </summary>
		private double TILE_VERTICAL_OFFSET = 11 * Math.Sqrt(5);

		/// <summary>
		/// Der horizontale Abstand der Eckpunkte eines Tiles zu dessen Mittelpunkt.
		/// </summary>
		private double TILE_HORIZONTAL_OFFSET = 22 * Math.Sqrt(5);

		#endregion Konstanten

		#region Variablen

		/// <summary>
		/// Gibt an, ob die OpenGL-Zeichenfläche bereits initialisiert wurde.
		/// </summary>
		private bool _glLoaded = false;

		/// <summary>
		/// Gibt an, ob gerade das zu rendernde Schiff aktualisiert wird. Dies unterbindet Ereignisse von Buttons o.ä..
		/// </summary>
		private bool _updating = false;

		/// <summary>
		/// Das gerade in Bearbeitung befindliche Schiff.
		/// </summary>
		private ShipFile _ship = null;

		/// <summary>
		/// Die Farbtabelle zu Rendern von Grafiken.
		/// </summary>
		private BitmapLibrary.ColorTable _pal50500 = null;

		/// <summary>
		/// Die Graphics-DRS mit Grafiken.
		/// </summary>
		private DRSFile _graphicsDrs = null;

		/// <summary>
		/// Die Zeichen-Textur.
		/// </summary>
		private static int _charTextureID = 0;

		/// <summary>
		/// Die Vergrößerung der zu zeichnenden Animationen.
		/// </summary>
		private float _zoom = 1.0f;

		/// <summary>
		/// Die Position der Maus beim letzten Betätigen der linken Maustaste im Zeichenfeld.
		/// </summary>
		private Point _mouseClickLocation;

		/// <summary>
		/// Die Verschiebung der Zeichenfläche.
		/// </summary>
		private Point _renderingTranslation = new Point(0, 0);

		/// <summary>
		/// Das aktuelle Kultur-Grafikset.
		/// </summary>
		private ShipFile.Civ _currentCiv = ShipFile.Civ.AS;

		/// <summary>
		/// Der Hauptsegel-Anzeigemodus. "Go" entspricht true.
		/// </summary>
		private bool _mainSailMode = false;

		/// <summary>
		/// Die Renderdaten des Rumpfes.
		/// </summary>
		private RenderData _baseRenderData = null;

		/// <summary>
		/// Die Renderdaten des Schattens.
		/// </summary>
		private RenderData _shadowRenderData = null;

		/// <summary>
		/// Die Renderdaten der einzelnen Segeltypen.
		/// </summary>
		private Dictionary<Sail.SailType, RenderData> _sailRenderData = new Dictionary<Sail.SailType, RenderData>();

		#endregion

		#region Funktionen

		/// <summary>
		/// Konstruktor.
		/// </summary>
		public MainForm()
		{
			// Steuerelemente laden
			InitializeComponent();

			// Farbpalette laden
			_pal50500 = new BitmapLibrary.ColorTable(new BitmapLibrary.JASCPalette(new IORAMHelper.RAMBuffer(Properties.Resources.pal50500)));

			// Mausrad-Ereignis auf der Zeichenfläche behandeln
			_drawPanel.MouseWheel += _drawPanel_MouseWheel;

			// TODO: Graphics-DRS laden
		}

		/// <summary>
		/// Initialisiert OpenGL und die Zeichenfläche.
		/// </summary>
		private void InitDrawPanel()
		{
			// Ich bin dran
			_drawPanel.MakeCurrent();

			// Panel leeren
			GL.ClearColor(COLOR_BACKGROUND);

			// Texturen aktivieren
			GL.Enable(EnableCap.Texture2D);

			// 2D-Grafik benötigt keine Tiefenerkennung
			GL.Disable(EnableCap.DepthTest);

			// Blending einschalten
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

			// Blickwinkel erstellen
			SetupDrawPanelViewPort();

			// Zeichen-Texturen für String-Rendering erstellen
			{
				// Bitmap laden
				Bitmap charTexBitmap = X2AddOnShipTool.Properties.Resources.RenderFontConsolas;

				// Textur generieren
				_charTextureID = GL.GenTexture();
				GL.BindTexture(TextureTarget.Texture2D, _charTextureID);

				// Parameter setzen
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
				GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

				// Textur übergeben
				BitmapData charTexBitmapData = charTexBitmap.LockBits(new Rectangle(0, 0, 256, 128), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, 256, 128, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, charTexBitmapData.Scan0);

				// Ressourcen wieder freigeben
				charTexBitmap.UnlockBits(charTexBitmapData);
			}

			// Alles ist geladen
			_glLoaded = true;
		}

		/// <summary>
		/// Erstellt die Koordinaten und Blickwinkel der Zeichenfläche.
		/// </summary>
		private void SetupDrawPanelViewPort()
		{
			// Ich bin dran
			_drawPanel.MakeCurrent();

			// Blickwinkel erstellen
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(0.0, _drawPanel.Width, _drawPanel.Height, 0.0, -1.0, 1.0); // Pixel oben links ist (0, 0)
			GL.Viewport(0, 0, _drawPanel.Width, _drawPanel.Height);

			// Zeichenmodus laden
			GL.MatrixMode(MatrixMode.Modelview);
		}

		/// <summary>
		/// Erstellt eine Textur aus der angegebenen SLP-Datei und gibt deren Renderdaten zurück.
		/// </summary>
		/// <param name="slp">Die SLP-Datei, aus der eine Textur erstellt werden soll.</param>
		/// <returns></returns>
		RenderData CreateTextureFromSlp(SLPLoader.SLPFile slp)
		{
			// Die Ziel-Textur-ID
			RenderData texData = new RenderData();
			texData.AssociatedSlpFile = slp;

			// Die DAT-Framezahl sollte das Produkt aus Achsenzahl und SLP-Framezahl sein => nicht benötigte Achsenframes ignorieren
			uint slpFrameCount = slp.FrameCount;

			// Mindestens ein Frame ist sinnvoll
			if(slpFrameCount > 0)
			{
				// Framegrößen berechnen
				int frameWidth = (int)slp._frameInformationHeaders.Max(h => h.Width);
				if(frameWidth % 2 == 1)
					++frameWidth;
				int frameHeight = (int)slp._frameInformationHeaders.Max(h => h.Height);
				if(frameHeight % 2 == 1)
					++frameHeight;
				texData.FrameBounds = new Size(frameWidth, frameHeight);

				// Möglichst platzsparend mit dem Texturspeicher umgehen => beste Frameverteilung berechnen
				int maxTextureSize = GL.GetInteger(GetPName.MaxTextureSize);
				int minTexSize = int.MaxValue;
				for(int fpl = (int)Math.Ceiling((double)slpFrameCount / (maxTextureSize / frameHeight)); fpl <= slpFrameCount / 2 + 1 && (fpl * frameWidth <= maxTextureSize); ++fpl)
				{
					// Neue Größe berechnen und vergleichen
					int newTexSize = Log2(fpl * frameWidth) + Log2((int)Math.Ceiling((double)slpFrameCount / fpl) * frameHeight);
					if(newTexSize < minTexSize)
					{
						// Besserer Wert gefunden
						minTexSize = newTexSize;
						texData.FramesPerLine = fpl;
					}
				}

				// Finale Texturengröße berechnen
				int textureWidth = (int)NextPowerOfTwo((uint)texData.FramesPerLine * (uint)frameWidth);
				int textureHeight = (int)NextPowerOfTwo((uint)Math.Ceiling((double)slpFrameCount / texData.FramesPerLine) * (uint)frameHeight);
				texData.TextureBounds = new Size(textureWidth, textureHeight);

				// Frames nacheinander auf Bitmap zeichnen
				using(Bitmap textureBitmap = new Bitmap(textureWidth, textureHeight))
				{
					// Bitmap-Grafikobjekt abrufen
					using(Graphics g = Graphics.FromImage(textureBitmap))
					{
						// Frames durchlaufen
						int i = 0;
						int j = 0;
						for(uint f = 0; f < slpFrameCount; ++f)
						{
							// Frame-Bitmap holen und zeichnen
							using(Bitmap currFrame = slp.getFrameAsBitmap(f, _pal50500, SLPLoader.SLPFile.Masks.Graphic, Color.FromArgb(0, 0, 0, 0), COLOR_SHADOW))
								g.DrawImage(currFrame, j * frameWidth, i * frameHeight);

							// Koordinaten erhöhen
							if(++j >= texData.FramesPerLine)
							{
								// Neue Zeile
								++i;
								j = 0;
							}
						}
					}

					// Textur anlegen und binden
					texData.TextureId = GL.GenTexture();
					GL.BindTexture(TextureTarget.Texture2D, texData.TextureId);

					// Textur soll bei Verkleinerung/Vergrößerung scharf (= pixelig) bleiben
					GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
					GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

					// Bild-Bits sperren
					BitmapData data = textureBitmap.LockBits(new Rectangle(0, 0, textureWidth, textureHeight), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

					// Textur an OpenGL übergeben
					GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textureWidth, textureHeight, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

					// Bild-Bits wieder freigeben
					textureBitmap.UnlockBits(data);

					// Texturbindung beenden
					GL.BindTexture(TextureTarget.Texture2D, 0);
				}
			}

			// Fertig
			return texData;
		}

		/// <summary>
		/// Legt die Texturen für das Schiff an.
		/// </summary>
		void CreateShipTextures()
		{
			// Ggf. erst freigeben
			if(_baseRenderData != null)
				GL.DeleteTexture(_baseRenderData.TextureId);
			if(_shadowRenderData != null)
				GL.DeleteTexture(_shadowRenderData.TextureId);
			foreach(var rd in _sailRenderData)
				GL.DeleteTexture(rd.Value.TextureId);
			_sailRenderData.Clear();

			// Rumpf
			if(_ship.BaseSlp != null)
				_baseRenderData = CreateTextureFromSlp(_ship.BaseSlp);
			else
				_baseRenderData = null;

			// Schatten
			if(_ship.ShadowSlp != null)
				_shadowRenderData = CreateTextureFromSlp(_ship.ShadowSlp);
			else
				_shadowRenderData = null;

			// Segel
			_sailRenderData.Add(Sail.SailType.Small1, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Small1].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.Mid2, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Mid2].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.Large1, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Large1].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.MainGo, CreateTextureFromSlp(_ship.Sails[Sail.SailType.MainGo].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.MainStop, CreateTextureFromSlp(_ship.Sails[Sail.SailType.MainStop].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.Large2, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Large2].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.Mid1, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Mid1].SailSlps[_currentCiv]));
			_sailRenderData.Add(Sail.SailType.Small2, CreateTextureFromSlp(_ship.Sails[Sail.SailType.Small2].SailSlps[_currentCiv]));
		}

		/// <summary>
		/// Aktualisiert die Segeldaten anhand des gegebenen Steuerelements.
		/// </summary>
		/// <param name="sailType">Der Segeltyp.</param>
		/// <param name="secondSailType">Der Typ des zugehörigen zweiten Segels (komplementär je Drehrichtung).</param>
		/// <param name="sailControl">Das Steuerelement mit den Segeleinstellungen.</param>
		private void UpdateSailData(Sail.SailType sailType, Sail.SailType secondSailType, SailPlacementControl sailControl)
		{
			// Aktualisieren...
			_updating = true;

			// Segeldaten aktualisieren
			bool justEnabled = (!_ship.Sails[sailType].Used && sailControl.SailUsed);
			if(_ship.Sails[sailType].Used != sailControl.SailUsed)
				_ship.Sails[sailType].Used = sailControl.SailUsed;
			if(_ship.Sails[secondSailType].Used != sailControl.SailUsed)
				_ship.Sails[secondSailType].Used = sailControl.SailUsed;

			// Segel-Anker aktualisieren
			SLPLoader.SLPFile.FrameInformationHeader sailFrameHeader = _ship.Sails[sailType].SailSlps[_currentCiv]._frameInformationHeaders[_sailRenderData[sailType].CurrentFrameId];
			if(justEnabled)
			{
				// Steuerelemente aktualisieren
				sailControl.AnchorX = sailFrameHeader.AnchorX;
				sailControl.AnchorY = sailFrameHeader.AnchorY;
			}
			else
			{
				// SLP-Daten aktualisieren
				sailFrameHeader.AnchorX = sailControl.AnchorX;
				sailFrameHeader.AnchorY = sailControl.AnchorY;
			}

			// Neuzeichnen
			_updating = false;
			_drawPanel.Invalidate();
		}

		/// <summary>
		/// Aktualisiert die Segel-Steuerelemente. Wird aufgerufen bei Änderung der Drehrichtung etc.
		/// </summary>
		private void UpdateSailControls()
		{
			// Werte eintragen
			if(_smallSailField.SailUsed)
			{
				// Anker
				Sail.SailType shownSailType = (_sailRenderData[Sail.SailType.Small1].CurrentFrameId < 5 ? Sail.SailType.Small1 : Sail.SailType.Small2);
				SLPLoader.SLPFile.FrameInformationHeader sailFrameHeader = _ship.Sails[shownSailType].SailSlps[_currentCiv]._frameInformationHeaders[_sailRenderData[shownSailType].CurrentFrameId];
				_smallSailField.AnchorX = sailFrameHeader.AnchorX;
				_smallSailField.AnchorY = sailFrameHeader.AnchorY;
			}
			if(_midSailField.SailUsed)
			{
				// Anker
				Sail.SailType shownSailType = (_sailRenderData[Sail.SailType.Mid1].CurrentFrameId < 5 ? Sail.SailType.Mid1 : Sail.SailType.Mid2);
				SLPLoader.SLPFile.FrameInformationHeader sailFrameHeader = _ship.Sails[shownSailType].SailSlps[_currentCiv]._frameInformationHeaders[_sailRenderData[shownSailType].CurrentFrameId];
				_midSailField.AnchorX = sailFrameHeader.AnchorX;
				_midSailField.AnchorY = sailFrameHeader.AnchorY;
			}
			if(_largeSailField.SailUsed)
			{
				// Anker
				Sail.SailType shownSailType = (_sailRenderData[Sail.SailType.Large1].CurrentFrameId < 5 ? Sail.SailType.Large1 : Sail.SailType.Large2);
				SLPLoader.SLPFile.FrameInformationHeader sailFrameHeader = _ship.Sails[shownSailType].SailSlps[_currentCiv]._frameInformationHeaders[_sailRenderData[shownSailType].CurrentFrameId];
				_largeSailField.AnchorX = sailFrameHeader.AnchorX;
				_largeSailField.AnchorY = sailFrameHeader.AnchorY;
			}
			if(_mainSailField.SailUsed)
			{
				// Anker
				Sail.SailType shownSailType = (_mainSailMode ? Sail.SailType.MainGo : Sail.SailType.MainStop);
				SLPLoader.SLPFile.FrameInformationHeader sailFrameHeader = _ship.Sails[shownSailType].SailSlps[_currentCiv]._frameInformationHeaders[_sailRenderData[shownSailType].CurrentFrameId];
				_mainSailField.AnchorX = sailFrameHeader.AnchorX;
				_mainSailField.AnchorY = sailFrameHeader.AnchorY;
			}
		}

		#endregion

		#region Ereignishandler

		private void MainForm_Load(object sender, EventArgs e)
		{
			// OpenGL und das Zeichenpanel initialisieren
			if(!DesignMode)
				InitDrawPanel();

			// Graphics-DRS laden
			if(_openGraphicsDrsDialog.ShowDialog() != DialogResult.OK)
				Close();
			_graphicsDrs = new DRSFile(_openGraphicsDrsDialog.FileName);
			BringToFront();
		}

		private void _drawPanel_Paint(object sender, PaintEventArgs e)
		{
			// Wurde OpenGL schon geladen?
			if(!_glLoaded)
				return;

			// Zeichenfläche leeren
			GL.Clear(ClearBufferMask.ColorBufferBit);

			// Während Update lieber nichts tun
			if(_updating)
			{
				// Hintergrund anzeigen und abbrechen
				_drawPanel.SwapBuffers();
				return;
			}

			// Zeichenmatrix zurücksetzen
			GL.LoadIdentity();

			// Zeichenfläche verschieben
			GL.Translate(_renderingTranslation.X, _renderingTranslation.Y, 0.0f);

			// Ausgang aller Zeichnungen ist der Fenstermittelpunkt
			GL.Translate(_drawPanel.Width / 2.0f, _drawPanel.Height / 2.0f, 0.0f);

			// Tile-Gitternetz zeichnen
			for(float i = 0.0f; i < 16.5f; i += 0.5f)
				for(float j = 0.0f; j < 16.5f; j += 0.5f)
					DrawBorder(i, j, Color.FromArgb(180, 180, 180), false);

			// Zeichenfunktion definieren
			Action<RenderData> drawObject = (renderData) =>
			{
				// Ist eine Textur vorhanden?
				if(renderData.TextureId > 0)
				{
					// Textur binden
					GL.Color3(Color.White);
					GL.BindTexture(TextureTarget.Texture2D, renderData.TextureId);

					// Gezoomte Texturabmessungen berechnen
					double zoomedTexHalfWidth = (_zoom / 2) * renderData.FrameBounds.Width;
					double zoomedTexHalfHeight = (_zoom / 2) * renderData.FrameBounds.Height;

					// Ansicht verschieben
					GL.PushMatrix();
					int frameID = renderData.CurrentFrameId;
					GL.Translate(-renderData.AssociatedSlpFile._frameInformationHeaders[frameID].AnchorX * _zoom, -renderData.AssociatedSlpFile._frameInformationHeaders[frameID].AnchorY * _zoom, 0.0);
					{
						// Frame-Koordinaten berechnen
						double frameX = (frameID % renderData.FramesPerLine) * renderData.FrameBounds.Width;
						double frameY = (frameID / renderData.FramesPerLine) * renderData.FrameBounds.Height;

						// Frame zeichnen
						double texLeft = frameX / renderData.TextureBounds.Width;
						double texRight = (frameX + renderData.FrameBounds.Width) / renderData.TextureBounds.Width;
						double texTop = frameY / renderData.TextureBounds.Height;
						double texBottom = (frameY + renderData.FrameBounds.Height) / renderData.TextureBounds.Height;
						GL.Begin(PrimitiveType.Quads);
						{
							GL.TexCoord2(texLeft, texTop); GL.Vertex2(0, 0); // Oben links
							GL.TexCoord2(texRight, texTop); GL.Vertex2(2 * zoomedTexHalfWidth, 0); // Oben rechts
							GL.TexCoord2(texRight, texBottom); GL.Vertex2(2 * zoomedTexHalfWidth, 2 * zoomedTexHalfHeight); // Unten rechts
							GL.TexCoord2(texLeft, texBottom); GL.Vertex2(0, 2 * zoomedTexHalfHeight); // Unten links
						}
						GL.End();
					}
					GL.PopMatrix();
				}
			};

			// Objekte zeichnen
			if(_baseRenderData != null)
				drawObject(_baseRenderData);
			if(_shadowRenderData != null)
				drawObject(_shadowRenderData);
			foreach(var currSail in _sailRenderData)
				if(_ship.Sails[currSail.Key].Used)
					if((currSail.Key != Sail.SailType.MainGo && currSail.Key != Sail.SailType.MainStop)
								|| (!_mainSailMode && currSail.Key == Sail.SailType.MainStop)
								|| (_mainSailMode && currSail.Key == Sail.SailType.MainGo))
						drawObject(currSail.Value);

			// Keine Textur binden
			GL.BindTexture(TextureTarget.Texture2D, 0);

			// Ankerposition markieren
#if DEBUG
			// Markierung zeichnen
			GL.Color3(Color.DeepPink);
			GL.Begin(PrimitiveType.Quads);
			{
				GL.Vertex2(-4, -4);
				GL.Vertex2(4, -4);
				GL.Vertex2(4, 4);
				GL.Vertex2(-4, 4);
			}
			GL.End();
#endif

			// Puffer tauschen => Bildschirmausgabe
			_drawPanel.SwapBuffers();
		}

		private void _drawPanel_Resize(object sender, EventArgs e)
		{
			// Visual Studio Designer-Crash verhindern
			if(DesignMode)
				return;

			// Prüfen, ob das Panel überhaupt eine Größe hat (Fenster minimiert?)
			if(_drawPanel.Width != 0 && _drawPanel.Height != 0)
			{
				// Blickwinkel neu laden
				SetupDrawPanelViewPort();

				// Neuzeichnen erzwingen
				_drawPanel.Invalidate();
			}
		}

		private void _drawPanel_MouseDown(object sender, MouseEventArgs e)
		{
			// Verschiebe-Cursor anzeigen
			_drawPanel.Cursor = Cursors.SizeAll;
			_mouseClickLocation = e.Location;
		}

		private void _drawPanel_MouseUp(object sender, MouseEventArgs e)
		{
			// Cursor zurücksetzen
			_drawPanel.Cursor = Cursors.Default;
		}

		private void _drawPanel_MouseMove(object sender, MouseEventArgs e)
		{
			// Falls Maustause gedrückt, Zeichnung verschieben
			if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle)
			{
				// Neues Offset berechnen
				_renderingTranslation = new Point(_renderingTranslation.X + e.Location.X - _mouseClickLocation.X, _renderingTranslation.Y + e.Location.Y - _mouseClickLocation.Y);
				_mouseClickLocation = e.Location;

				// Neuzeichnen
				_drawPanel.Invalidate();
			}
		}

		private void _drawPanel_MouseWheel(object sender, MouseEventArgs e)
		{
			// Steuerungstaste gedrückt?
			if(ModifierKeys == Keys.Control)
			{
				// Vom Zoom bereinigten Abstand des unter dem Mauszeiger befindlichen Punktes von Bildmitte berechnen
				PointF mousePointCenterDistance = new PointF((e.X - _drawPanel.Width / 2) / _zoom, (e.Y - _drawPanel.Height / 2) / _zoom);

				// Alte von Zoom bereinigte Verschiebung der Zeichenfläche merken
				PointF oldRenderingTranslation = new PointF(_renderingTranslation.X / _zoom, _renderingTranslation.Y / _zoom);

				// Zoomen
				float zoomDelta = (e.Delta > 0 ? 0.5f : -0.5f);
				if(_zoomField.Value + (decimal)zoomDelta <= _zoomField.Maximum && _zoomField.Value + (decimal)zoomDelta >= _zoomField.Minimum)
					_zoomField.Value += (decimal)zoomDelta;
				else if(zoomDelta < 0)
				{
					zoomDelta = (float)(_zoomField.Minimum - _zoomField.Value);
					_zoomField.Value = _zoomField.Minimum;
				}
				else
				{
					zoomDelta = (float)(_zoomField.Maximum - _zoomField.Value);
					_zoomField.Value = _zoomField.Maximum;
				}

				// Renderoffset entsprechend ändern, um auf die aktuelle Mausposition zoomen zu können
				_renderingTranslation.X = (int)(_zoom * oldRenderingTranslation.X + e.X - _drawPanel.Width / 2 - _zoom * mousePointCenterDistance.X);
				_renderingTranslation.Y = (int)(_zoom * oldRenderingTranslation.Y + e.Y - _drawPanel.Height / 2 - _zoom * mousePointCenterDistance.Y);

				// Neu zeichnen
				_drawPanel.Invalidate();
			}
		}

		private void _zoomField_ValueChanged(object sender, EventArgs e)
		{
			// Neuen Zoom speichern
			_zoom = (float)_zoomField.Value;

			// Neu zeichnen
			_drawPanel.Invalidate();
		}

		private void _centerUnitButton_Click(object sender, EventArgs e)
		{
			// Zentrieren
			_renderingTranslation = new Point(0, 0);

			// Neu zeichnen
			_drawPanel.Invalidate();
		}

		private void _newShipButton_Click(object sender, EventArgs e)
		{
			// Sicherheitsfrage
			if(_ship != null && MessageBox.Show("Alle nicht gespeicherten Änderungen verwerfen?", "Neues Schiff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			// Schiff erstellen
			_ship = new ShipFile();

			// Steuerelemente aktualisieren
			_updating = true;

			// Dummy-Namen einsetzen
			_ship.Name = "Neues Schiff";
			_nameTextBox.Text = _ship.Name;

			// Segel anlegen
			_ship.Sails.Add(Sail.SailType.Small1, new Sail(Sail.SailType.Small1, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.Small2, new Sail(Sail.SailType.Small2, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.Mid1, new Sail(Sail.SailType.Mid1, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.Mid2, new Sail(Sail.SailType.Mid2, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.Large1, new Sail(Sail.SailType.Large1, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.Large2, new Sail(Sail.SailType.Large2, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.MainGo, new Sail(Sail.SailType.MainGo, _graphicsDrs));
			_ship.Sails.Add(Sail.SailType.MainStop, new Sail(Sail.SailType.MainStop, _graphicsDrs));

			// Keine Segel aktiviert
			_smallSailField.SailUsed = false;
			_midSailField.SailUsed = false;
			_largeSailField.SailUsed = false;
			_mainSailField.SailUsed = false;
			CreateShipTextures();
			UpdateSailControls();

			// Steuerelemente freischalten
			_saveShipButton.Enabled = true;
			_exportButton.Enabled = true;
			_shipGroupBox.Enabled = true;
			_bottomPanel.Enabled = true;
			_sailPanel.Enabled = true;
			_shipGroupBox.Enabled = true;

			// Neuzeichnen
			_updating = false;
			_drawPanel.Invalidate();
		}

		private void _openShipButton_Click(object sender, EventArgs e)
		{
			// Sicherheitsfrage
			if(_ship != null && MessageBox.Show("Alle nicht gespeicherten Änderungen verwerfen?", "Neues Schiff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			// Dialog zeigen
			if(_openShipDialog.ShowDialog() != DialogResult.OK)
				return;

			// Schiff laden
			_ship = new ShipFile(_openShipDialog.FileName);

			// Steuerelemente aktualisieren
			_updating = true;

			// Namen anzeigen
			_nameTextBox.Text = _ship.Name;

			// Segel-Steuerelemente setzen
			_smallSailField.SailUsed = _ship.Sails[Sail.SailType.Small1].Used;
			_midSailField.SailUsed = _ship.Sails[Sail.SailType.Mid1].Used;
			_largeSailField.SailUsed = _ship.Sails[Sail.SailType.Large1].Used;
			_mainSailField.SailUsed = _ship.Sails[Sail.SailType.MainStop].Used;
			CreateShipTextures();
			UpdateSailControls();

			// Steuerelemente freischalten
			_saveShipButton.Enabled = true;
			_exportButton.Enabled = true;
			_shipGroupBox.Enabled = true;
			_bottomPanel.Enabled = true;
			_sailPanel.Enabled = true;
			_shipGroupBox.Enabled = true;

			// Fertig
			_updating = false;
			_drawPanel.Invalidate();
		}

		private void _saveShipButton_Click(object sender, EventArgs e)
		{
			// Schiff speichern
			if(_saveShipDialog.ShowDialog() == DialogResult.OK)
			{
				// Schönen Cursor anzeigen derweils
				Cursor.Current = Cursors.WaitCursor;
				_ship.Save(_saveShipDialog.FileName);
				Cursor.Current = Cursors.Default;
			}
		}

		private void _exportButton_Click(object sender, EventArgs e)
		{
			// Ordner auswählen lassen
			if(_openExportFolderDialog.ShowDialog() == DialogResult.OK)
			{
				// Exportieren mit schönem Cursor
				Cursor.Current = Cursors.WaitCursor;
				_ship.Export(_openExportFolderDialog.SelectedPath);
				Cursor.Current = Cursors.Default;

				// Erfolgsnachricht
				MessageBox.Show("Exportieren nach \"" + _openExportFolderDialog.SelectedPath + "\" erfolgreich!", "Exportieren", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void _nameTextBox_TextChanged(object sender, EventArgs e)
		{
			// Bei Updates nichts machen
			if(_updating)
				return;

			// Namen setzen
			_ship.Name = _nameTextBox.Text;
		}

		private void _importBaseSlpButton_Click(object sender, EventArgs e)
		{
			// Dialog anzeigen
			if(_openSlpDialog.ShowDialog() != DialogResult.OK)
				return;

			// SLP laden
			_ship.BaseSlp = new SLPLoader.SLPFile(new IORAMHelper.RAMBuffer(_openSlpDialog.FileName));

			// Textur erstellen
			if(_baseRenderData != null)
				GL.DeleteTexture(_baseRenderData.TextureId);
			_baseRenderData = CreateTextureFromSlp(_ship.BaseSlp);

			// Neu zeichnen
			_drawPanel.Invalidate();
		}

		private void _importShadowSlpButton_Click(object sender, EventArgs e)
		{
			// Dialog anzeigen
			if(_openSlpDialog.ShowDialog() != DialogResult.OK)
				return;

			// SLP laden
			_ship.ShadowSlp = new SLPLoader.SLPFile(new IORAMHelper.RAMBuffer(_openSlpDialog.FileName));

			// Textur erstellen
			if(_shadowRenderData != null)
				GL.DeleteTexture(_shadowRenderData.TextureId);
			_shadowRenderData = CreateTextureFromSlp(_ship.ShadowSlp);

			// Neu zeichnen
			_drawPanel.Invalidate();
		}

		private void _smallSailField_Changed(object sender, EventArgs e)
		{
			// Bei Updates nichts machen
			if(_updating)
				return;

			// Funktion aufrufen
			if(_sailRenderData[Sail.SailType.Small1].CurrentFrameId < 5)
				UpdateSailData(Sail.SailType.Small1, Sail.SailType.Small2, _smallSailField);
			else
				UpdateSailData(Sail.SailType.Small2, Sail.SailType.Small1, _smallSailField);
		}

		private void _midSailField_Changed(object sender, EventArgs e)
		{
			// Bei Updates nichts machen
			if(_updating)
				return;

			// Funktion aufrufen
			if(_sailRenderData[Sail.SailType.Mid1].CurrentFrameId < 5)
				UpdateSailData(Sail.SailType.Mid1, Sail.SailType.Mid2, _midSailField);
			else
				UpdateSailData(Sail.SailType.Mid2, Sail.SailType.Mid1, _midSailField);
		}

		private void _largeSailField_Changed(object sender, EventArgs e)
		{
			// Bei Updates nichts machen
			if(_updating)
				return;

			// Funktion aufrufen
			if(_sailRenderData[Sail.SailType.Large1].CurrentFrameId < 5)
				UpdateSailData(Sail.SailType.Large1, Sail.SailType.Large2, _largeSailField);
			else
				UpdateSailData(Sail.SailType.Large2, Sail.SailType.Large1, _largeSailField);
		}

		private void _mainSailField_Changed(object sender, EventArgs e)
		{
			// Bei Updates nichts machen
			if(_updating)
				return;

			// Funktion aufrufen
			if(_mainSailMode)
				UpdateSailData(Sail.SailType.MainGo, Sail.SailType.MainStop, _mainSailField);
			else
				UpdateSailData(Sail.SailType.MainStop, Sail.SailType.MainGo, _mainSailField);
		}

		private void _mainSailModeButton_CheckedChanged(object sender, EventArgs e)
		{
			// Modus setzen
			_mainSailMode = _mainSailModeGoButton.Checked;

			// Feld aktualisieren
			UpdateSailControls();

			// Neuzeichnen
			_drawPanel.Invalidate();
		}

		private void _civButton_CheckedChanged(object sender, EventArgs e)
		{
			// Aktuelle Kultur aktualisieren
			if(_civASButton.Checked)
				_currentCiv = ShipFile.Civ.AS;
			else if(_civINButton.Checked)
				_currentCiv = ShipFile.Civ.IN;
			else if(_civMEButton.Checked)
				_currentCiv = ShipFile.Civ.ME;
			else if(_civORButton.Checked)
				_currentCiv = ShipFile.Civ.OR;
			else if(_civWEButton.Checked)
				_currentCiv = ShipFile.Civ.WE;

			// Neue Texturen erstellen
			CreateShipTextures();

			// Schiffsgrafiken korrekt drehen (wird erst auf 0 gesetzt)
			_updating = true;
			_rotationField_ValueChanged(this, EventArgs.Empty);
			_mainSailFrameField_ValueChanged(this, EventArgs.Empty);
			_updating = false;
			UpdateSailControls();

			// Neuzeichnen
			_drawPanel.Invalidate();
		}

		private void _rotationField_ValueChanged(object sender, EventArgs e)
		{
			// Neue Frame-Indizes eintragen
			int val = (int)_rotationField.Value;
			if(_baseRenderData != null)
				_baseRenderData.CurrentFrameId = val;
			if(_shadowRenderData != null)
				_shadowRenderData.CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Small1].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Small2].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Mid1].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Mid2].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Large1].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.Large2].CurrentFrameId = val;

			// Aktualisieren...
			if(_updating)
				return;
			_updating = true;

			// Hauptsegel-Feld aktualisieren
			_mainSailFrameField.Value = (val / 2) * 10;

			// Steuerelemente aktualisieren
			UpdateSailControls();

			// Fertig
			_updating = false;

			// Neuzeichnen
			_drawPanel.Invalidate();
		}

		private void _mainSailFrameField_ValueChanged(object sender, EventArgs e)
		{
			// Neue Frame-Indizes eintragen
			int val = (int)_mainSailFrameField.Value;
			_sailRenderData[Sail.SailType.MainStop].CurrentFrameId = val;
			_sailRenderData[Sail.SailType.MainGo].CurrentFrameId = val;

			// Aktualisieren...
			if(_updating)
				return;
			_updating = true;

			// Rotationsfeld aktualisieren
			if(_rotationField.Value < 2 * (val / 10) || _rotationField.Value > 2 * (val / 10) + 1)
				_rotationField.Value = 2 * (val / 10);

			// Steuerelemente aktualisieren
			UpdateSailControls();

			// Fertig
			_updating = false;

			// Neuzeichnen
			_drawPanel.Invalidate();
		}

		private void _drawPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			// Pfeiltasten erlauben
			switch(e.KeyCode)
			{
				case Keys.Left:
				case Keys.Right:
				case Keys.Up:
				case Keys.Down:
				case Keys.Shift | Keys.Left:
				case Keys.Shift | Keys.Right:
				case Keys.Shift | Keys.Up:
				case Keys.Shift | Keys.Down:
					e.IsInputKey = true;
					break;
			}
		}

		private void _drawPanel_KeyDown(object sender, KeyEventArgs e)
		{
			// Es sollte ein Schiff geladen sein
			if(_ship == null)
				return;

			// Frames scrollen
			if(e.KeyCode == Keys.Up)
			{
				// Umschalttaste => Achse drehen
				if(e.Shift && _rotationField.Value < _rotationField.Maximum)
					++_rotationField.Value;
				else if(_mainSailFrameField.Value < _mainSailFrameField.Maximum)
					++_mainSailFrameField.Value;
			}
			else if(e.KeyCode == Keys.Down)
			{
				// Umschalttaste => Achse drehen
				if(e.Shift && _rotationField.Value > _rotationField.Minimum)
					--_rotationField.Value;
				else if(_mainSailFrameField.Value > _mainSailFrameField.Minimum)
					--_mainSailFrameField.Value;
			}
		}

		#endregion

		#region Hilfsklassen

		/// <summary>
		/// Definiert Renderdaten für ein Segel.
		/// </summary>
		class RenderData
		{
			/// <summary>
			/// Die Textur-ID des Segels.
			/// </summary>
			public int TextureId { get; set; } = 0;

			/// <summary>
			/// Die ID des aktuell angezeigten Frames.
			/// </summary>
			public int CurrentFrameId { get; set; } = 0;

			/// <summary>
			/// Die Abmessungen eines Frames.
			/// </summary>
			public Size FrameBounds { get; set; } = Size.Empty;

			/// <summary>
			/// Die Frames pro Zeile.
			/// </summary>
			public int FramesPerLine { get; set; } = 0;

			/// <summary>
			/// Die Abmessungen der Textur.
			/// </summary>
			public Size TextureBounds { get; set; } = Size.Empty;

			/// <summary>
			/// Die zugehörige SLP-Datei.
			/// </summary>
			public SLPLoader.SLPFile AssociatedSlpFile { get; set; }
		}

		#endregion

		#region Hilfsfunktionen

		/// <summary>
		/// Zeichnet einen viereckigen oder runden Tile-Bereich um den aktuellen Mittelpunkt.
		/// </summary>
		/// <param name="size1">Die Höhe des Bereichs.</param>
		/// <param name="size2">Die Breite des Bereichs.</param>
		/// <param name="color">Die Farbe des Rahmens.</param>
		/// <param name="round">Gibt an, ob der Rahmen rund oder eckig sein soll.</param>
		/// <returns></returns>
		private void DrawBorder(float size1, float size2, Color color, bool round)
		{
			// Rund?
			if(round)
			{
				// Radien berechnen
				const double step = 2 * Math.PI / 360;
				double radX = size2 * TILE_HORIZONTAL_OFFSET;
				double radY = size1 * TILE_VERTICAL_OFFSET;

				// Zeichnen
				GL.Color3(color);
				GL.Begin(PrimitiveType.LineLoop);
				for(double i = 0; i < 2 * Math.PI; i += step)
					GL.Vertex2(_zoom * Math.Cos(i) * radX, _zoom * Math.Sin(i) * radY);
				GL.End();
			}
			else
			{
				// Seitenpunkte berechnen
				float topX = (float)((size2 - size1) * TILE_HORIZONTAL_OFFSET);
				float topY = (float)((size2 + size1) * TILE_VERTICAL_OFFSET);
				float leftX = (float)(-(size1 + size2) * TILE_HORIZONTAL_OFFSET);
				float leftY = (float)((size1 - size2) * TILE_VERTICAL_OFFSET);

				// Zeichnen
				GL.Color3(color);
				GL.Begin(PrimitiveType.LineLoop);
				{
					GL.Vertex2(_zoom * leftX, _zoom * leftY); // Links
					GL.Vertex2(_zoom * topX, _zoom * topY); // Oben
					GL.Vertex2(-_zoom * leftX, -_zoom * leftY); // Rechts
					GL.Vertex2(-_zoom * topX, -_zoom * topY); // Unten
				}
				GL.End();
			}
		}

		/// <summary>
		/// Berechnet die nächsthöhere (oder gleiche) Zweierpotenz zum gegebenen Wert.
		/// </summary>
		/// <param name="value">Der Wert, zu dem die nächsthöhere Zweierpotenz gefunden werden soll.</param>
		/// <returns></returns>
		private uint NextPowerOfTwo(uint value)
		{
			// Bit-Magie
			--value;
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			return ++value;
		}

		/// <summary>
		/// Berechnet den aufgerundeten ganzzahligen Logarithmus der angegebenen Zahl zur Basis 2.
		/// </summary>
		/// <param name="value">Die Zahl deren Logarithmus bestimmt werden soll.</param>
		/// <returns></returns>
		private int Log2(int value)
		{
			// Abgerundeten Logarithmus berechnen
			int log = 0;
			int temp = value;
			while((temp >>= 1) > 0)
				++log;

			// Ggf. aufrunden
			if((1 << log) < value)
				++log;

			// Fertgi
			return log;
		}

		/// <summary>
		/// Zeichnet die gegebene Zeichenfolge an die gegebene Position. Dabei wird die obere linke Ecke angegeben.
		/// Die Abmessungen betragen 8x13 Pixel für das erste und dann 6x13 Pixel pro Zeichen; dies kann auch mit der MeasureString-Funktion bestimmt werden.
		/// </summary>
		/// <param name="value">Die zu zeichende Zeichenfolge.</param>
		/// <param name="x">Die X-Position, an die die Zeichenfolge gezeichnet werden soll.</param>
		/// <param name="y">Die Y-Position, an die die Zeichenfolge gezeichnet werden soll.</param>
		private void DrawString(string value, int x, int y)
		{
			// Textur laden
			GL.BindTexture(TextureTarget.Texture2D, _charTextureID);

			// String zeichenweise durchlaufen
			foreach(char c in value.ToCharArray())
			{
				// Zeichnen
				int cTrans = (int)c - 32;
				float charPosX = (cTrans & 31) / 32.0f;
				float charPosY = (cTrans >> 5) / 10.0f;
				GL.Begin(PrimitiveType.Quads);
				{
					GL.TexCoord2(charPosX, charPosY); GL.Vertex2(x, y); // Oben links
					GL.TexCoord2(charPosX + 1 / 32.0f, charPosY); GL.Vertex2(x + 8, y); // Oben rechts
					GL.TexCoord2(charPosX + 1 / 32.0f, charPosY + 1 / 9.84615f); GL.Vertex2(x + 8, y + 13); // Unten rechts
					GL.TexCoord2(charPosX, charPosY + 1 / 10.0f); GL.Vertex2(x, y + 13); // Unten links
				}
				GL.End();

				// X-Position erhöhen
				x += 6;
			}

			// Texture entladen
			GL.BindTexture(TextureTarget.Texture2D, 0);
		}

		/// <summary>
		/// Berechnet die Abmessungen des gegebenen Strings.
		/// </summary>
		/// <param name="value">Die Zeichenfolge, deren Abmessungen berechnet werden sollen.</param>
		private Size MeasureString(string value)
		{
			// Größe berechnen
			return new Size((value.Length > 0 ? 8 : 0) + (value.Length - 1) * 6, 13);
		}

		#endregion Hilfsfunktionen
	}
}
