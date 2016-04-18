using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IORAMHelper;
using SLPLoader;

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

		#endregion
	}
}
