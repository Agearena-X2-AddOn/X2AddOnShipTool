namespace X2AddOnShipTool
{
	partial class SlpIdForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._idTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._broadsideCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// _idTextBox
			// 
			this._idTextBox.Location = new System.Drawing.Point(12, 12);
			this._idTextBox.Name = "_idTextBox";
			this._idTextBox.Size = new System.Drawing.Size(129, 20);
			this._idTextBox.TabIndex = 0;
			// 
			// _okButton
			// 
			this._okButton.Location = new System.Drawing.Point(147, 11);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(39, 22);
			this._okButton.TabIndex = 1;
			this._okButton.Text = "OK";
			this._okButton.UseVisualStyleBackColor = true;
			this._okButton.Click += new System.EventHandler(this._okButton_Click);
			// 
			// _broadsideCheckBox
			// 
			this._broadsideCheckBox.AutoSize = true;
			this._broadsideCheckBox.Location = new System.Drawing.Point(12, 38);
			this._broadsideCheckBox.Name = "_broadsideCheckBox";
			this._broadsideCheckBox.Size = new System.Drawing.Size(156, 17);
			this._broadsideCheckBox.TabIndex = 2;
			this._broadsideCheckBox.Text = "Breitseiten-SLPs generieren";
			this._broadsideCheckBox.UseVisualStyleBackColor = true;
			// 
			// SlpIdForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(198, 65);
			this.Controls.Add(this._broadsideCheckBox);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._idTextBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SlpIdForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "SLP-Basis-ID angeben...";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _idTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.CheckBox _broadsideCheckBox;
	}
}