namespace X2AddOnShipTool
{
	partial class SailPlacementControl
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this._enableCheckBox = new System.Windows.Forms.CheckBox();
			this._anchorXField = new System.Windows.Forms.NumericUpDown();
			this._anchorYField = new System.Windows.Forms.NumericUpDown();
			this._invertButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._anchorXField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._anchorYField)).BeginInit();
			this.SuspendLayout();
			// 
			// _enableCheckBox
			// 
			this._enableCheckBox.AutoSize = true;
			this._enableCheckBox.Location = new System.Drawing.Point(3, 3);
			this._enableCheckBox.Name = "_enableCheckBox";
			this._enableCheckBox.Size = new System.Drawing.Size(120, 17);
			this._enableCheckBox.TabIndex = 0;
			this._enableCheckBox.Text = "Langer Segel Name";
			this._enableCheckBox.UseVisualStyleBackColor = true;
			this._enableCheckBox.CheckedChanged += new System.EventHandler(this._enableCheckBox_CheckedChanged);
			// 
			// _anchorXField
			// 
			this._anchorXField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._anchorXField.Enabled = false;
			this._anchorXField.Location = new System.Drawing.Point(129, 2);
			this._anchorXField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this._anchorXField.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this._anchorXField.Name = "_anchorXField";
			this._anchorXField.Size = new System.Drawing.Size(53, 20);
			this._anchorXField.TabIndex = 1;
			this._anchorXField.ValueChanged += new System.EventHandler(this._anchorXField_ValueChanged);
			// 
			// _anchorYField
			// 
			this._anchorYField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._anchorYField.Enabled = false;
			this._anchorYField.Location = new System.Drawing.Point(188, 2);
			this._anchorYField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this._anchorYField.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this._anchorYField.Name = "_anchorYField";
			this._anchorYField.Size = new System.Drawing.Size(53, 20);
			this._anchorYField.TabIndex = 2;
			this._anchorYField.ValueChanged += new System.EventHandler(this._anchorYField_ValueChanged);
			// 
			// _invertButton
			// 
			this._invertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._invertButton.Enabled = false;
			this._invertButton.Location = new System.Drawing.Point(246, 1);
			this._invertButton.Name = "_invertButton";
			this._invertButton.Size = new System.Drawing.Size(32, 22);
			this._invertButton.TabIndex = 3;
			this._invertButton.Text = "<->";
			this._invertButton.UseVisualStyleBackColor = true;
			this._invertButton.Click += new System.EventHandler(this._invertButton_Click);
			// 
			// SailPlacementControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._invertButton);
			this.Controls.Add(this._anchorYField);
			this.Controls.Add(this._anchorXField);
			this.Controls.Add(this._enableCheckBox);
			this.Name = "SailPlacementControl";
			this.Size = new System.Drawing.Size(278, 23);
			((System.ComponentModel.ISupportInitialize)(this._anchorXField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._anchorYField)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox _enableCheckBox;
		private System.Windows.Forms.NumericUpDown _anchorXField;
		private System.Windows.Forms.NumericUpDown _anchorYField;
		private System.Windows.Forms.Button _invertButton;
	}
}
