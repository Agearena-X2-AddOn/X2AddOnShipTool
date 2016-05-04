using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IORAMHelper;
using SLPLoader;
using System.IO;
using System.Collections.ObjectModel;

namespace X2AddOnShipTool
{
	/// <summary>
	/// Enthält Informationen über ein zu verankerndes Schiff. Entspricht im Prinzip einer Projektdatei.
	/// </summary>
	class ShipFile
	{
		#region Variablen

		/// <summary>
		/// Der Name des Schiffes.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Die Rumpf-SLP.
		/// </summary>
		public SLPFile BaseSlp { get; set; }

		/// <summary>
		/// Die Schatten-SLP.
		/// </summary>
		public SLPFile ShadowSlp { get; set; }

		/// <summary>
		/// Die Segel.
		/// </summary>
		public Dictionary<Sail.SailType, Sail> Sails { get; private set; }

		/// <summary>
		/// Die 1-Typen der invertierten Segel.
		/// </summary>
		public List<Sail.SailType> InvertedSails { get; private set; }

		#endregion

		#region Funktionen

		/// <summary>
		/// Konstruktor.
		/// </summary>
		public ShipFile()
		{
			// Variablen erstellen
			Sails = new Dictionary<Sail.SailType, Sail>();
			InvertedSails = new List<Sail.SailType>();

			/*Sail s = new Sail(Sail.SailType.MainStop, new DRSLibrary.DRSFile("E:\\Programme\\Age of Empires II\\DATA\\graphics.drs"));
			foreach(var el in s.SailSlps)
			{
				List<SLPFile.FrameInformationHeader> head = new List<SLPFile.FrameInformationHeader>(el.Value._frameInformationHeaders);
				List<SLPFile.FrameInformationData> data = new List<SLPFile.FrameInformationData>(el.Value._frameInformationData);

				el.Value._frameInformationHeaders.Clear();
				el.Value._frameInformationData.Clear();
				for(int j = 0; j < 2; ++j)
					for(int i = 0; i < 10; ++i)
					{
						int off = i + 0;
						SLPFile.FrameInformationHeader h = new SLPFile.FrameInformationHeader();
						h.AnchorX = head[off].AnchorX;
						h.AnchorY = head[off].AnchorY;
						h.FrameCommandsOffset = head[off].FrameCommandsOffset;
						h.FrameOutlineOffset = head[off].FrameOutlineOffset;
						h.Height = head[off].Height;
						h.PaletteOffset = head[off].PaletteOffset;
						h.Properties = head[off].Properties;
						h.Width = head[off].Width;
						el.Value._frameInformationHeaders.Add(h);
						SLPFile.FrameInformationData d = new SLPFile.FrameInformationData();
						d.BinaryCommandTable = new List<SLPFile.BinaryCommand>(data[off].BinaryCommandTable);
						d.BinaryRowEdge = data[off].BinaryRowEdge;
						d.CommandTable = data[off].CommandTable;
						d.CommandTableOffsets = new uint[data[off].CommandTableOffsets.Length];
						Array.Copy(data[off].CommandTableOffsets, d.CommandTableOffsets, data[off].CommandTableOffsets.Length);
						d.RowEdge = data[off].RowEdge;
						el.Value._frameInformationData.Add(d);
					}
				for(int j = 0; j < 2; ++j)
					for(int i = 0; i < 10; ++i)
					{
						int off = i + 10;
						SLPFile.FrameInformationHeader h = new SLPFile.FrameInformationHeader();
						h.AnchorX = head[off].AnchorX;
						h.AnchorY = head[off].AnchorY;
						h.FrameCommandsOffset = head[off].FrameCommandsOffset;
						h.FrameOutlineOffset = head[off].FrameOutlineOffset;
						h.Height = head[off].Height;
						h.PaletteOffset = head[off].PaletteOffset;
						h.Properties = head[off].Properties;
						h.Width = head[off].Width;
						el.Value._frameInformationHeaders.Add(h);
						SLPFile.FrameInformationData d = new SLPFile.FrameInformationData();
						d.BinaryCommandTable = new List<SLPFile.BinaryCommand>(data[off].BinaryCommandTable);
						d.BinaryRowEdge = data[off].BinaryRowEdge;
						d.CommandTable = data[off].CommandTable;
						d.CommandTableOffsets = new uint[data[off].CommandTableOffsets.Length];
						Array.Copy(data[off].CommandTableOffsets, d.CommandTableOffsets, data[off].CommandTableOffsets.Length);
						d.RowEdge = data[off].RowEdge;
						el.Value._frameInformationData.Add(d);
					}
				for(int j = 0; j < 2; ++j)
					for(int i = 0; i < 10; ++i)
					{
						int off = i + 20;
						SLPFile.FrameInformationHeader h = new SLPFile.FrameInformationHeader();
						h.AnchorX = head[off].AnchorX;
						h.AnchorY = head[off].AnchorY;
						h.FrameCommandsOffset = head[off].FrameCommandsOffset;
						h.FrameOutlineOffset = head[off].FrameOutlineOffset;
						h.Height = head[off].Height;
						h.PaletteOffset = head[off].PaletteOffset;
						h.Properties = head[off].Properties;
						h.Width = head[off].Width;
						el.Value._frameInformationHeaders.Add(h);
						SLPFile.FrameInformationData d = new SLPFile.FrameInformationData();
						d.BinaryCommandTable = new List<SLPFile.BinaryCommand>(data[off].BinaryCommandTable);
						d.BinaryRowEdge = data[off].BinaryRowEdge;
						d.CommandTable = data[off].CommandTable;
						d.CommandTableOffsets = new uint[data[off].CommandTableOffsets.Length];
						Array.Copy(data[off].CommandTableOffsets, d.CommandTableOffsets, data[off].CommandTableOffsets.Length);
						d.RowEdge = data[off].RowEdge;
						el.Value._frameInformationData.Add(d);
					}
				for(int j = 0; j < 2; ++j)
					for(int i = 0; i < 10; ++i)
					{
						int off = i + 30;
						SLPFile.FrameInformationHeader h = new SLPFile.FrameInformationHeader();
						h.AnchorX = head[off].AnchorX;
						h.AnchorY = head[off].AnchorY;
						h.FrameCommandsOffset = head[off].FrameCommandsOffset;
						h.FrameOutlineOffset = head[off].FrameOutlineOffset;
						h.Height = head[off].Height;
						h.PaletteOffset = head[off].PaletteOffset;
						h.Properties = head[off].Properties;
						h.Width = head[off].Width;
						el.Value._frameInformationHeaders.Add(h);
						SLPFile.FrameInformationData d = new SLPFile.FrameInformationData();
						d.BinaryCommandTable = new List<SLPFile.BinaryCommand>(data[off].BinaryCommandTable);
						d.BinaryRowEdge = data[off].BinaryRowEdge;
						d.CommandTable = data[off].CommandTable;
						d.CommandTableOffsets = new uint[data[off].CommandTableOffsets.Length];
						Array.Copy(data[off].CommandTableOffsets, d.CommandTableOffsets, data[off].CommandTableOffsets.Length);
						d.RowEdge = data[off].RowEdge;
						el.Value._frameInformationData.Add(d);
					}
					for(int i = 0; i < 10; ++i)
					{
						int off = i + 40;
						SLPFile.FrameInformationHeader h = new SLPFile.FrameInformationHeader();
						h.AnchorX = head[off].AnchorX;
						h.AnchorY = head[off].AnchorY;
						h.FrameCommandsOffset = head[off].FrameCommandsOffset;
						h.FrameOutlineOffset = head[off].FrameOutlineOffset;
						h.Height = head[off].Height;
						h.PaletteOffset = head[off].PaletteOffset;
						h.Properties = head[off].Properties;
						h.Width = head[off].Width;
						el.Value._frameInformationHeaders.Add(h);
						SLPFile.FrameInformationData d = new SLPFile.FrameInformationData();
						d.BinaryCommandTable = new List<SLPFile.BinaryCommand>(data[off].BinaryCommandTable);
						d.BinaryRowEdge = data[off].BinaryRowEdge;
						d.CommandTable = data[off].CommandTable;
						d.CommandTableOffsets = new uint[data[off].CommandTableOffsets.Length];
						Array.Copy(data[off].CommandTableOffsets, d.CommandTableOffsets, data[off].CommandTableOffsets.Length);
						d.RowEdge = data[off].RowEdge;
						el.Value._frameInformationData.Add(d);
					}

				((RAMBuffer)el.Value.DataBuffer).Clear();
				el.Value.writeData();
				((RAMBuffer)el.Value.DataBuffer).Save("MainStop_" + CivNames[el.Key] + ".slp");
			}*/
		}

		/// <summary>
		/// Konstruktor. Lädt die angegebene Datei.
		/// </summary>
		/// <param name="filename">Die zu ladende Datei.</param>
		public ShipFile(string filename)
			: this()
		{
			// Datei laden
			RAMBuffer buffer = new RAMBuffer(filename);

			// Namen lesen
			Name = buffer.ReadString(buffer.ReadInteger());

			// Rumpf-SLP lesen
			if(buffer.ReadByte() == 1)
				BaseSlp = new SLPFile(buffer);

			// Schatten-SLP lesen
			if(buffer.ReadByte() == 1)
				ShadowSlp = new SLPFile(buffer);

			// Segel lesen
			int sailCount = buffer.ReadByte();
			for(int i = 0; i < sailCount; ++i)
			{
				// Lesen
				Sail.SailType currType = (Sail.SailType)buffer.ReadByte();
				Sail currSail = new Sail(buffer);
				Sails.Add(currType, currSail);
			}

			// Invertierte Segeltypen lesen
			int invSailCount = buffer.ReadByte();
			for(int i = 0; i < invSailCount; ++i)
				InvertedSails.Add((Sail.SailType)buffer.ReadByte());

			// 0 -> 0, 10 -> 0, 20 -> 10, 30 -> 10, 40 -> 20, 50 -> 20, 60 -> 30, 70 -> 30, 80 -> 40

			/*func(Sail.SailType.MainGo, Civ.AS, Properties.Resources.MainGo_AS);
			func(Sail.SailType.MainGo, Civ.IN, Properties.Resources.MainGo_IN);
			func(Sail.SailType.MainGo, Civ.ME, Properties.Resources.MainGo_ME);
			func(Sail.SailType.MainGo, Civ.OR, Properties.Resources.MainGo_OR);
			func(Sail.SailType.MainGo, Civ.WE, Properties.Resources.MainGo_WE);
			func(Sail.SailType.MainStop, Civ.AS, Properties.Resources.MainStop_AS);
			func(Sail.SailType.MainStop, Civ.IN, Properties.Resources.MainStop_IN);
			func(Sail.SailType.MainStop, Civ.ME, Properties.Resources.MainStop_ME);
			func(Sail.SailType.MainStop, Civ.OR, Properties.Resources.MainStop_OR);
			func(Sail.SailType.MainStop, Civ.WE, Properties.Resources.MainStop_WE);

			Save(Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename) + "_converted.ship"));*/
		}

		/*void func(Sail.SailType type, Civ civ, byte[] data)
		{
			SLPFile s = new SLPFile(new RAMBuffer(data));
			for(int f = 0; f < 90; ++f)
			{
				s._frameInformationHeaders[f].AnchorX = Sails[type].SailSlps[civ]._frameInformationHeaders[10 * ((f / 10) / 2) + (f % 10)].AnchorX;
				s._frameInformationHeaders[f].AnchorY = Sails[type].SailSlps[civ]._frameInformationHeaders[10 * ((f / 10) / 2) + (f % 10)].AnchorY;
			}
			Sails[type].SailSlps[civ] = s;
		}*/

		/// <summary>
		/// Speichert die Schiffsdaten in der angegebenen Datei.
		/// </summary>
		/// <param name="filename">Die Zieldatei.</param>
		public void Save(string filename)
		{
			// Puffer erstellen
			RAMBuffer buffer = new RAMBuffer();

			// Name schreiben
			buffer.WriteInteger(Name.Length);
			buffer.WriteString(Name);

			// Rumpf-SLP schreiben
			if(BaseSlp != null)
			{
				// SLP schreiben
				buffer.WriteByte(1);
				BaseSlp.writeData();
				buffer.Write((RAMBuffer)BaseSlp.DataBuffer);
			}
			else
				buffer.WriteByte(0);

			// Schatten-SLP schreiben
			if(ShadowSlp != null)
			{
				// SLP schreiben
				buffer.WriteByte(1);
				ShadowSlp.writeData();
				buffer.Write((RAMBuffer)ShadowSlp.DataBuffer);
			}
			else
				buffer.WriteByte(0);

			// Segel schreiben
			buffer.WriteByte((byte)Sails.Count);
			foreach(var currSail in Sails)
			{
				// Schreiben
				buffer.WriteByte((byte)currSail.Key);
				currSail.Value.WriteData(buffer);
			}

			// Invertierte Segel schreiben
			buffer.WriteByte((byte)InvertedSails.Count);
			foreach(var invSail in InvertedSails)
				buffer.WriteByte((byte)invSail);

			// Speichern
			buffer.Save(filename);
		}

		/// <summary>
		/// Export die enthaltenen SLPs in den gegebenen Ordner.
		/// Reihenfolge der Exports ist wichtig - bei Änderungen im TechTreeEditor-Plugin gegenprüfen!
		/// </summary>
		/// <param name="folder">Der Zielordner.</param>
		/// <param name="baseId">Die erste freie ID, zu der exportiert werden soll.</param>
		/// <param name="broadside">Gibt an, ob die Grafiken zusätzlich im Breitseitenmodus exportiert werden sollen.</param>
		public void Export(string folder, int baseId, bool broadside)
		{
			// Die aktuell freie ID
			int currId = baseId;

			// Basispfad bauen
			string baseFileName = Path.Combine(folder, Name);

			// Der XML-Projektdatei-Code
			string xmlCode = "";

			// Hilfsfunktion fürs Exportieren
			Action<SLPFile, string> exportSlp = (slp, suffix) =>
			{
				// Exportstruktur anlegen
				DRSLibrary.DRSFile.ExternalFile extFile = new DRSLibrary.DRSFile.ExternalFile();

				// Breitseitenmodus?
				SLPFile slpE = slp;
				if(broadside)
				{
					// Suffix erweitern
					suffix += " [B]";

					// Neue SLP mit umkopierten Frames erzeugen
					slp.writeData();
					RAMBuffer tmpBuffer = (RAMBuffer)slp.DataBuffer;
					tmpBuffer.Position = 0;
					slpE = new SLPFile(tmpBuffer);
					slpE._frameInformationHeaders.Clear();
					slpE._frameInformationData.Clear();

					// Drehrichtungen vorne bis links (-> links bis hinten)
					for(int i = 4; i <= 8; ++i)
					{
						// Alle Frames der Drehrichtung kopieren
						for(int f = i * (int)(slp.FrameCount / 9); f < (i + 1) * (int)(slp.FrameCount / 9); ++f)
						{
							// Header kopieren
							SLPFile.FrameInformationHeader fHead = new SLPFile.FrameInformationHeader();
							fHead.AnchorX = slp._frameInformationHeaders[f].AnchorX;
							fHead.AnchorY = slp._frameInformationHeaders[f].AnchorY;
							fHead.Width = slp._frameInformationHeaders[f].Width;
							fHead.Height = slp._frameInformationHeaders[f].Height;
							fHead.Properties = slp._frameInformationHeaders[f].Properties;
							slpE._frameInformationHeaders.Add(fHead);

							// Daten kopieren
							SLPFile.FrameInformationData fData = new SLPFile.FrameInformationData();
							fData.BinaryCommandTable = new List<SLPFile.BinaryCommand>(slp._frameInformationData[f].BinaryCommandTable);
							fData.BinaryRowEdge = slp._frameInformationData[f].BinaryRowEdge;
							fData.CommandTable = slp._frameInformationData[f].CommandTable;
							fData.CommandTableOffsets = new uint[slp._frameInformationData[f].CommandTableOffsets.Length];
							fData.RowEdge = slp._frameInformationData[f].RowEdge;
							slpE._frameInformationData.Add(fData);
						}
					}

					// Drehrichtungen links links hinten bis hinten (-> hinten hinten rechts bis rechts)
					for(int i = 7; i >= 4; --i)
					{
						// Alle Frames der Drehrichtung spiegeln und kopieren
						for(int f = i * (int)(slp.FrameCount / 9); f < (i + 1) * (int)(slp.FrameCount / 9); ++f)
						{
							// Header kopieren
							SLPFile.FrameInformationHeader fHead = new SLPFile.FrameInformationHeader();
							fHead.AnchorX = (int)slp._frameInformationHeaders[f].Width - slp._frameInformationHeaders[f].AnchorX;
							fHead.AnchorY = slp._frameInformationHeaders[f].AnchorY;
							fHead.Width = slp._frameInformationHeaders[f].Width;
							fHead.Height = slp._frameInformationHeaders[f].Height;
							fHead.Properties = slp._frameInformationHeaders[f].Properties;
							slpE._frameInformationHeaders.Add(fHead);

							// Daten spiegeln und kopieren
							SLPFile.FrameInformationData fData = new SLPFile.FrameInformationData();
							fData.BinaryCommandTable = new List<SLPFile.BinaryCommand>();
							fData.BinaryRowEdge = new SLPFile.BinaryRowedge[slp._frameInformationData[f].BinaryRowEdge.Length];
							for(int bre = 0; bre < fData.BinaryRowEdge.Length; ++bre)
								fData.BinaryRowEdge[bre] = new SLPFile.BinaryRowedge(slp._frameInformationData[f].BinaryRowEdge[bre]._right, slp._frameInformationData[f].BinaryRowEdge[bre]._left);
							fData.RowEdge = new ushort[fHead.Height, 2];
							for(int re = 0; re < fHead.Height; ++re)
							{
								fData.RowEdge[re, 0] = slp._frameInformationData[f].RowEdge[re, 1];
								fData.RowEdge[re, 1] = slp._frameInformationData[f].RowEdge[re, 0];
							}
							fData.CommandTable = new int[fHead.Height, fHead.Width];
							for(int h = 0; h < fHead.Height; ++h)
								for(int w = 0; w < fHead.Width; ++w)
									fData.CommandTable[h, fHead.Width - w - 1] = slp._frameInformationData[f].CommandTable[h, w];
							fData.CommandTableOffsets = new uint[slp._frameInformationData[f].CommandTableOffsets.Length];
							slpE.CreateBinaryCommandTable(fData, (int)fHead.Width, (int)fHead.Height, slpE._settings);
							slpE._frameInformationData.Add(fData);
						}
					}
				}

				// SLP-Daten lesen und zuweisen
				slpE.writeData();
				RAMBuffer slpBuffer = (RAMBuffer)slpE.DataBuffer;
				slpBuffer.Position = 0;
				extFile.Data = slpBuffer.ReadByteArray(slpBuffer.Length);

				// Metadaten festlegen
				extFile.DRSFile = "graphics";
				extFile.FileID = (uint)(currId++);
				extFile.ResourceType = "slp";

				// Exportdatei speichern
				extFile.ToBinary().Save(Path.Combine(folder, extFile.FileID + ".res"));

				// XML-Code generieren
				xmlCode += "<ResFile>" + extFile.FileID + ".res</ResFile>\r\n";

				// SLP speichern
				if(!string.IsNullOrEmpty(suffix))
					slpBuffer.Save(baseFileName + " " + suffix + ".slp");
				else
					slpBuffer.Save(baseFileName + ".slp");
			};

			// Schatten und Rumpf exportieren
			if(ShadowSlp != null)
				exportSlp(ShadowSlp, "(Schatten)");
			if(BaseSlp != null)
				exportSlp(BaseSlp, "");

			// Hilfsfunktion für Segel-Export (Reihenfolge wichtig für ID-Vergabe)
			Action<Civ> exportCivSails = (civ) =>
			{
				// Segel exportieren
				if(Sails[Sail.SailType.MainGo].Used)
					exportSlp(Sails[Sail.SailType.MainGo].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.MainGo] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Small1].Used)
					exportSlp(Sails[Sail.SailType.Small1].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Small1] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Mid1].Used)
					exportSlp(Sails[Sail.SailType.Mid1].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Mid1] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Large1].Used)
					exportSlp(Sails[Sail.SailType.Large1].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Large1] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.MainStop].Used)
					exportSlp(Sails[Sail.SailType.MainStop].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.MainStop] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Large2].Used)
					exportSlp(Sails[Sail.SailType.Large2].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Large2] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Mid2].Used)
					exportSlp(Sails[Sail.SailType.Mid2].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Mid2] + ") [" + CivNames[civ] + "]");
				if(Sails[Sail.SailType.Small2].Used)
					exportSlp(Sails[Sail.SailType.Small2].SailSlps[civ], "(" + Sail.SailTypeNames[Sail.SailType.Small2] + ") [" + CivNames[civ] + "]");
			};

			// Segel kulturweise exportieren
			exportCivSails(Civ.AS);
			exportCivSails(Civ.IN);
			exportCivSails(Civ.ME);
			exportCivSails(Civ.OR);
			exportCivSails(Civ.WE);

			// XML-Code speichern
			File.WriteAllText(Path.Combine(folder, "projectdata" + (broadside ? "_b" : "") + ".xml"), xmlCode);

			// Ggf. noch die Nicht-Breitseiten-Frames exportieren
			if(broadside)
				Export(folder, currId, false);
		}

		#endregion

		#region Enumeration

		/// <summary>
		/// Die verfügbaren Kulturen.
		/// </summary>
		public enum Civ : byte
		{
			ME = 0,
			AS = 1,
			OR = 2,
			WE = 3,
			IN = 4
		}

		/// <summary>
		/// Die Namen der einzelnen Kulturen.
		/// </summary>

		public static readonly ReadOnlyDictionary<Civ, string> CivNames = new ReadOnlyDictionary<Civ, string>(new Dictionary<Civ, string>()
		{
			[Civ.ME] = "ME",
			[Civ.AS] = "AS",
			[Civ.OR] = "OR",
			[Civ.WE] = "WE",
			[Civ.IN] = "IN"
		});

		#endregion
	}
}
