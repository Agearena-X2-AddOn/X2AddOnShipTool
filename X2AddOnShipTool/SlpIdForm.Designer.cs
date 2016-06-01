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
			this._civSetASCheckBox = new System.Windows.Forms.CheckBox();
			this._civSetWECheckBox = new System.Windows.Forms.CheckBox();
			this._civSetORCheckBox = new System.Windows.Forms.CheckBox();
			this._civSetMECheckBox = new System.Windows.Forms.CheckBox();
			this._civSetINCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// _idTextBox
			// 
			this._idTextBox.Location = new System.Drawing.Point(12, 12);
			this._idTextBox.Name = "_idTextBox";
			this._idTextBox.Size = new System.Drawing.Size(156, 20);
			this._idTextBox.TabIndex = 0;
			// 
			// _okButton
			// 
			this._okButton.Location = new System.Drawing.Point(175, 12);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(55, 22);
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
			// _civSetASCheckBox
			// 
			this._civSetASCheckBox.AutoSize = true;
			this._civSetASCheckBox.Location = new System.Drawing.Point(12, 64);
			this._civSetASCheckBox.Name = "_civSetASCheckBox";
			this._civSetASCheckBox.Size = new System.Drawing.Size(40, 17);
			this._civSetASCheckBox.TabIndex = 3;
			this._civSetASCheckBox.Text = "AS";
			this._civSetASCheckBox.UseVisualStyleBackColor = true;
			// 
			// _civSetWECheckBox
			// 
			this._civSetWECheckBox.AutoSize = true;
			this._civSetWECheckBox.Location = new System.Drawing.Point(196, 64);
			this._civSetWECheckBox.Name = "_civSetWECheckBox";
			this._civSetWECheckBox.Size = new System.Drawing.Size(44, 17);
			this._civSetWECheckBox.TabIndex = 4;
			this._civSetWECheckBox.Text = "WE";
			this._civSetWECheckBox.UseVisualStyleBackColor = true;
			// 
			// _civSetORCheckBox
			// 
			this._civSetORCheckBox.AutoSize = true;
			this._civSetORCheckBox.Location = new System.Drawing.Point(150, 64);
			this._civSetORCheckBox.Name = "_civSetORCheckBox";
			this._civSetORCheckBox.Size = new System.Drawing.Size(42, 17);
			this._civSetORCheckBox.TabIndex = 5;
			this._civSetORCheckBox.Text = "OR";
			this._civSetORCheckBox.UseVisualStyleBackColor = true;
			// 
			// _civSetMECheckBox
			// 
			this._civSetMECheckBox.AutoSize = true;
			this._civSetMECheckBox.Location = new System.Drawing.Point(104, 64);
			this._civSetMECheckBox.Name = "_civSetMECheckBox";
			this._civSetMECheckBox.Size = new System.Drawing.Size(42, 17);
			this._civSetMECheckBox.TabIndex = 6;
			this._civSetMECheckBox.Text = "ME";
			this._civSetMECheckBox.UseVisualStyleBackColor = true;
			// 
			// _civSetINCheckBox
			// 
			this._civSetINCheckBox.AutoSize = true;
			this._civSetINCheckBox.Location = new System.Drawing.Point(58, 64);
			this._civSetINCheckBox.Name = "_civSetINCheckBox";
			this._civSetINCheckBox.Size = new System.Drawing.Size(37, 17);
			this._civSetINCheckBox.TabIndex = 7;
			this._civSetINCheckBox.Text = "IN";
			this._civSetINCheckBox.UseVisualStyleBackColor = true;
			// 
			// SlpIdForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(242, 93);
			this.Controls.Add(this._civSetINCheckBox);
			this.Controls.Add(this._civSetMECheckBox);
			this.Controls.Add(this._civSetORCheckBox);
			this.Controls.Add(this._civSetWECheckBox);
			this.Controls.Add(this._civSetASCheckBox);
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
		private System.Windows.Forms.CheckBox _civSetASCheckBox;
		private System.Windows.Forms.CheckBox _civSetWECheckBox;
		private System.Windows.Forms.CheckBox _civSetORCheckBox;
		private System.Windows.Forms.CheckBox _civSetMECheckBox;
		private System.Windows.Forms.CheckBox _civSetINCheckBox;
	}
}