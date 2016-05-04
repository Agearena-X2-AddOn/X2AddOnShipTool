﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X2AddOnShipTool
{
	/// <summary>
	/// Formular zur Eingabe der Export-SLP-ID.
	/// </summary>
	public partial class SlpIdForm : Form
	{
		/// <summary>
		/// Konstruktor.
		/// </summary>
		public SlpIdForm()
		{
			// Steuerelemente laden
			InitializeComponent();

			// Nicht fertig
			DialogResult = DialogResult.Cancel;
		}

		private void _okButton_Click(object sender, EventArgs e)
		{
			// Wert prüfen
			int val = 0;
			if(!int.TryParse(_idTextBox.Text, out val) || val < 0)
			{
				// Fehler
				MessageBox.Show("Bitte eine gültige Zahl eingeben.");
				return;
			}

			// Fertig
			SlpId = val;
			Broadside = _broadsideCheckBox.Checked;
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Die ausgewählte SLP-ID.
		/// </summary>
		public int SlpId { get; private set; }
		
		/// <summary>
		/// Der gewählte Breitseitenmodus.
		/// </summary>
		public bool Broadside { get; private set; }
	}
}
