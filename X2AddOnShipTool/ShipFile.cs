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

		#endregion

		#region Funktionen

		/// <summary>
		/// Konstruktor.
		/// </summary>
		public ShipFile()
		{
			// Variablen erstellen
			Sails = new Dictionary<Sail.SailType, Sail>();
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
		}

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

			// Speichern
			buffer.Save(filename);
		}

		/// <summary>
		/// Export die enthaltenen SLPs in den gegebenen Ordner.
		/// </summary>
		/// <param name="folder"></param>
		public void Export(string folder)
		{
			// Basispfad bauen
			string baseFileName = Path.Combine(folder, Name);

			// Hilfsfunktion fürs Exportieren
			Action<SLPFile, string> exportSlp = (slp, suffix) =>
			{
				// Schreiben und speichern
				slp.writeData();
				if(!string.IsNullOrEmpty(suffix))
					((RAMBuffer)slp.DataBuffer).Save(baseFileName + " " + suffix + ".slp");
				else
					((RAMBuffer)slp.DataBuffer).Save(baseFileName + ".slp");
			};

			// Rumpf und Schatten exportieren
			if(BaseSlp != null)
				exportSlp(BaseSlp, "");
			if(ShadowSlp != null)
				exportSlp(ShadowSlp, "(Schatten)");

			// Segel kulturweise exportieren
			foreach(var currS in Sails)
				if(currS.Value.Used)
					foreach(var currSlp in currS.Value.SailSlps)
						exportSlp(currSlp.Value, "(" + Sail.SailTypeNames[currS.Key] + ") [" + CivNames[currSlp.Key] + "]");
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
