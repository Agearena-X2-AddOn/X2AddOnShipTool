using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace X2AddOnShipTool
{
	/// <summary>
	/// Definiert ein Steuerelement zur Platzierung von Segeln.
	/// </summary>
	[DefaultEvent(nameof(Changed))]
	public partial class SailPlacementControl : UserControl
	{
		#region Funktionen

		/// <summary>
		/// Konstruktor.
		/// </summary>
		public SailPlacementControl()
		{
			// Steuerelemente laden
			InitializeComponent();
		}

		#endregion

		#region Ereignishandler

		private void _enableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// Ereignis auslösen
			_anchorXField.Enabled = _enableCheckBox.Checked;
			_anchorYField.Enabled = _enableCheckBox.Checked;
			Changed?.Invoke(this, EventArgs.Empty);
		}

		private void _anchorXField_ValueChanged(object sender, EventArgs e)
		{
			// Ereignis auslösen
			Changed?.Invoke(this, EventArgs.Empty);
		}

		private void _anchorYField_ValueChanged(object sender, EventArgs e)
		{
			// Ereignis auslösen
			Changed?.Invoke(this, EventArgs.Empty);
		}

		#endregion

		#region Eigenschaften

		/// <summary>
		/// Definiert den Namen des repräsentierten Segels.
		/// </summary>
		[Browsable(true)]
		public string SailName
		{
			get { return _enableCheckBox.Text; }
			set { _enableCheckBox.Text = value; }
		}

		/// <summary>
		/// Gibt an, ob das Segel aktiviert ist.
		/// </summary>
		public bool SailUsed
		{
			get { return _enableCheckBox.Checked; }
			set { _enableCheckBox.Checked = value; }
		}

		/// <summary>
		/// Die X-Verschiebung des Segels.
		/// </summary>
		public int AnchorX
		{
			get { return (int)_anchorXField.Value; }
			set { _anchorXField.Value = value; }
		}

		/// <summary>
		/// Die Y-Verschiebung des Segels.
		/// </summary>
		public int AnchorY
		{
			get { return (int)_anchorYField.Value; }
			set { _anchorYField.Value = value; }
		}

		#endregion

		#region Ereignisse

		/// <summary>
		/// Wird ausgelöst, wenn eines der Steuerelemente einen neuen Wert erhält.
		/// </summary>
		public event EventHandler Changed;

		#endregion
	}
}
