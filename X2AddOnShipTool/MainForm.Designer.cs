namespace X2AddOnShipTool
{
	partial class MainForm
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this._drawPanel = new OpenTK.GLControl();
			this._mainPanel = new System.Windows.Forms.Panel();
			this._shipGroupBox = new System.Windows.Forms.GroupBox();
			this._importShadowSlpButton = new System.Windows.Forms.Button();
			this._importBaseSlpButton = new System.Windows.Forms.Button();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this._nameLabel = new System.Windows.Forms.Label();
			this._menuGroupBox = new System.Windows.Forms.GroupBox();
			this._newShipButton = new System.Windows.Forms.Button();
			this._exportButton = new System.Windows.Forms.Button();
			this._openShipButton = new System.Windows.Forms.Button();
			this._saveShipButton = new System.Windows.Forms.Button();
			this._bottomPanel = new System.Windows.Forms.Panel();
			this._civGroupBox = new System.Windows.Forms.GroupBox();
			this._civWEButton = new System.Windows.Forms.RadioButton();
			this._civORButton = new System.Windows.Forms.RadioButton();
			this._civMEButton = new System.Windows.Forms.RadioButton();
			this._civINButton = new System.Windows.Forms.RadioButton();
			this._civASButton = new System.Windows.Forms.RadioButton();
			this._renderGroupBox = new System.Windows.Forms.GroupBox();
			this._mainSailFrameField = new System.Windows.Forms.NumericUpDown();
			this._rotationField = new System.Windows.Forms.NumericUpDown();
			this._rotationLabel = new System.Windows.Forms.Label();
			this._centerUnitButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this._zoomField = new System.Windows.Forms.NumericUpDown();
			this._openGraphicsDrsDialog = new System.Windows.Forms.OpenFileDialog();
			this._openShipDialog = new System.Windows.Forms.OpenFileDialog();
			this._saveShipDialog = new System.Windows.Forms.SaveFileDialog();
			this._openSlpDialog = new System.Windows.Forms.OpenFileDialog();
			this._sailPanel = new System.Windows.Forms.Panel();
			this._mainSailModeGoButton = new System.Windows.Forms.RadioButton();
			this._mainSailModeStopButton = new System.Windows.Forms.RadioButton();
			this._mainSailModeLabel = new System.Windows.Forms.Label();
			this._mainSailField = new X2AddOnShipTool.SailPlacementControl();
			this._largeSailField = new X2AddOnShipTool.SailPlacementControl();
			this._midSailField = new X2AddOnShipTool.SailPlacementControl();
			this._smallSailField = new X2AddOnShipTool.SailPlacementControl();
			this._openExportFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this._mainPanel.SuspendLayout();
			this._shipGroupBox.SuspendLayout();
			this._menuGroupBox.SuspendLayout();
			this._bottomPanel.SuspendLayout();
			this._civGroupBox.SuspendLayout();
			this._renderGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._mainSailFrameField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._rotationField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._zoomField)).BeginInit();
			this._sailPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _drawPanel
			// 
			this._drawPanel.BackColor = System.Drawing.Color.Black;
			this._drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._drawPanel.Location = new System.Drawing.Point(0, 64);
			this._drawPanel.Name = "_drawPanel";
			this._drawPanel.Size = new System.Drawing.Size(798, 388);
			this._drawPanel.TabIndex = 0;
			this._drawPanel.VSync = false;
			this._drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this._drawPanel_Paint);
			this._drawPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this._drawPanel_KeyDown);
			this._drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this._drawPanel_MouseDown);
			this._drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._drawPanel_MouseMove);
			this._drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this._drawPanel_MouseUp);
			this._drawPanel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this._drawPanel_PreviewKeyDown);
			this._drawPanel.Resize += new System.EventHandler(this._drawPanel_Resize);
			// 
			// _mainPanel
			// 
			this._mainPanel.Controls.Add(this._shipGroupBox);
			this._mainPanel.Controls.Add(this._menuGroupBox);
			this._mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this._mainPanel.Location = new System.Drawing.Point(0, 0);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(1049, 64);
			this._mainPanel.TabIndex = 1;
			// 
			// _shipGroupBox
			// 
			this._shipGroupBox.Controls.Add(this._importShadowSlpButton);
			this._shipGroupBox.Controls.Add(this._importBaseSlpButton);
			this._shipGroupBox.Controls.Add(this._nameTextBox);
			this._shipGroupBox.Controls.Add(this._nameLabel);
			this._shipGroupBox.Enabled = false;
			this._shipGroupBox.Location = new System.Drawing.Point(527, 5);
			this._shipGroupBox.Name = "_shipGroupBox";
			this._shipGroupBox.Size = new System.Drawing.Size(514, 51);
			this._shipGroupBox.TabIndex = 3;
			this._shipGroupBox.TabStop = false;
			this._shipGroupBox.Text = "Schiff";
			// 
			// _importShadowSlpButton
			// 
			this._importShadowSlpButton.Location = new System.Drawing.Point(353, 19);
			this._importShadowSlpButton.Name = "_importShadowSlpButton";
			this._importShadowSlpButton.Size = new System.Drawing.Size(153, 23);
			this._importShadowSlpButton.TabIndex = 7;
			this._importShadowSlpButton.Text = "Schatten-SLP importieren...";
			this._importShadowSlpButton.UseVisualStyleBackColor = true;
			this._importShadowSlpButton.Click += new System.EventHandler(this._importShadowSlpButton_Click);
			// 
			// _importBaseSlpButton
			// 
			this._importBaseSlpButton.Location = new System.Drawing.Point(197, 19);
			this._importBaseSlpButton.Name = "_importBaseSlpButton";
			this._importBaseSlpButton.Size = new System.Drawing.Size(150, 23);
			this._importBaseSlpButton.TabIndex = 6;
			this._importBaseSlpButton.Text = "Rumpf-SLP importieren...";
			this._importBaseSlpButton.UseVisualStyleBackColor = true;
			this._importBaseSlpButton.Click += new System.EventHandler(this._importBaseSlpButton_Click);
			// 
			// _nameTextBox
			// 
			this._nameTextBox.Location = new System.Drawing.Point(49, 21);
			this._nameTextBox.Name = "_nameTextBox";
			this._nameTextBox.Size = new System.Drawing.Size(142, 20);
			this._nameTextBox.TabIndex = 5;
			this._nameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
			// 
			// _nameLabel
			// 
			this._nameLabel.AutoSize = true;
			this._nameLabel.Location = new System.Drawing.Point(5, 24);
			this._nameLabel.Name = "_nameLabel";
			this._nameLabel.Size = new System.Drawing.Size(38, 13);
			this._nameLabel.TabIndex = 4;
			this._nameLabel.Text = "Name:";
			// 
			// _menuGroupBox
			// 
			this._menuGroupBox.Controls.Add(this._newShipButton);
			this._menuGroupBox.Controls.Add(this._exportButton);
			this._menuGroupBox.Controls.Add(this._openShipButton);
			this._menuGroupBox.Controls.Add(this._saveShipButton);
			this._menuGroupBox.Location = new System.Drawing.Point(7, 5);
			this._menuGroupBox.Name = "_menuGroupBox";
			this._menuGroupBox.Size = new System.Drawing.Size(514, 51);
			this._menuGroupBox.TabIndex = 2;
			this._menuGroupBox.TabStop = false;
			this._menuGroupBox.Text = "Menü";
			// 
			// _newShipButton
			// 
			this._newShipButton.Location = new System.Drawing.Point(8, 19);
			this._newShipButton.Name = "_newShipButton";
			this._newShipButton.Size = new System.Drawing.Size(120, 23);
			this._newShipButton.TabIndex = 3;
			this._newShipButton.Text = "Neues Schiff";
			this._newShipButton.UseVisualStyleBackColor = true;
			this._newShipButton.Click += new System.EventHandler(this._newShipButton_Click);
			// 
			// _exportButton
			// 
			this._exportButton.Enabled = false;
			this._exportButton.Location = new System.Drawing.Point(386, 19);
			this._exportButton.Name = "_exportButton";
			this._exportButton.Size = new System.Drawing.Size(120, 23);
			this._exportButton.TabIndex = 2;
			this._exportButton.Text = "Schiff exportieren...";
			this._exportButton.UseVisualStyleBackColor = true;
			this._exportButton.Click += new System.EventHandler(this._exportButton_Click);
			// 
			// _openShipButton
			// 
			this._openShipButton.Location = new System.Drawing.Point(134, 19);
			this._openShipButton.Name = "_openShipButton";
			this._openShipButton.Size = new System.Drawing.Size(120, 23);
			this._openShipButton.TabIndex = 0;
			this._openShipButton.Text = "Schiff laden...";
			this._openShipButton.UseVisualStyleBackColor = true;
			this._openShipButton.Click += new System.EventHandler(this._openShipButton_Click);
			// 
			// _saveShipButton
			// 
			this._saveShipButton.Enabled = false;
			this._saveShipButton.Location = new System.Drawing.Point(260, 19);
			this._saveShipButton.Name = "_saveShipButton";
			this._saveShipButton.Size = new System.Drawing.Size(120, 23);
			this._saveShipButton.TabIndex = 1;
			this._saveShipButton.Text = "Schiff speichern...";
			this._saveShipButton.UseVisualStyleBackColor = true;
			this._saveShipButton.Click += new System.EventHandler(this._saveShipButton_Click);
			// 
			// _bottomPanel
			// 
			this._bottomPanel.Controls.Add(this._civGroupBox);
			this._bottomPanel.Controls.Add(this._renderGroupBox);
			this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._bottomPanel.Enabled = false;
			this._bottomPanel.Location = new System.Drawing.Point(0, 452);
			this._bottomPanel.Name = "_bottomPanel";
			this._bottomPanel.Size = new System.Drawing.Size(1049, 60);
			this._bottomPanel.TabIndex = 2;
			// 
			// _civGroupBox
			// 
			this._civGroupBox.Controls.Add(this._civWEButton);
			this._civGroupBox.Controls.Add(this._civORButton);
			this._civGroupBox.Controls.Add(this._civMEButton);
			this._civGroupBox.Controls.Add(this._civINButton);
			this._civGroupBox.Controls.Add(this._civASButton);
			this._civGroupBox.Location = new System.Drawing.Point(508, 5);
			this._civGroupBox.Name = "_civGroupBox";
			this._civGroupBox.Size = new System.Drawing.Size(197, 47);
			this._civGroupBox.TabIndex = 5;
			this._civGroupBox.TabStop = false;
			this._civGroupBox.Text = "Grafikset";
			// 
			// _civWEButton
			// 
			this._civWEButton.Appearance = System.Windows.Forms.Appearance.Button;
			this._civWEButton.Location = new System.Drawing.Point(158, 17);
			this._civWEButton.Name = "_civWEButton";
			this._civWEButton.Size = new System.Drawing.Size(33, 24);
			this._civWEButton.TabIndex = 8;
			this._civWEButton.Text = "WE";
			this._civWEButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._civWEButton.UseVisualStyleBackColor = true;
			this._civWEButton.CheckedChanged += new System.EventHandler(this._civButton_CheckedChanged);
			// 
			// _civORButton
			// 
			this._civORButton.Appearance = System.Windows.Forms.Appearance.Button;
			this._civORButton.Location = new System.Drawing.Point(120, 17);
			this._civORButton.Name = "_civORButton";
			this._civORButton.Size = new System.Drawing.Size(32, 24);
			this._civORButton.TabIndex = 7;
			this._civORButton.Text = "OR";
			this._civORButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._civORButton.UseVisualStyleBackColor = true;
			this._civORButton.CheckedChanged += new System.EventHandler(this._civButton_CheckedChanged);
			// 
			// _civMEButton
			// 
			this._civMEButton.Appearance = System.Windows.Forms.Appearance.Button;
			this._civMEButton.Location = new System.Drawing.Point(82, 17);
			this._civMEButton.Name = "_civMEButton";
			this._civMEButton.Size = new System.Drawing.Size(32, 24);
			this._civMEButton.TabIndex = 6;
			this._civMEButton.Text = "ME";
			this._civMEButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._civMEButton.UseVisualStyleBackColor = true;
			this._civMEButton.CheckedChanged += new System.EventHandler(this._civButton_CheckedChanged);
			// 
			// _civINButton
			// 
			this._civINButton.Appearance = System.Windows.Forms.Appearance.Button;
			this._civINButton.Location = new System.Drawing.Point(44, 17);
			this._civINButton.Name = "_civINButton";
			this._civINButton.Size = new System.Drawing.Size(32, 24);
			this._civINButton.TabIndex = 5;
			this._civINButton.Text = "IN";
			this._civINButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._civINButton.UseVisualStyleBackColor = true;
			this._civINButton.CheckedChanged += new System.EventHandler(this._civButton_CheckedChanged);
			// 
			// _civASButton
			// 
			this._civASButton.Appearance = System.Windows.Forms.Appearance.Button;
			this._civASButton.Checked = true;
			this._civASButton.Location = new System.Drawing.Point(6, 17);
			this._civASButton.Name = "_civASButton";
			this._civASButton.Size = new System.Drawing.Size(32, 24);
			this._civASButton.TabIndex = 4;
			this._civASButton.TabStop = true;
			this._civASButton.Text = "AS";
			this._civASButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._civASButton.UseVisualStyleBackColor = true;
			this._civASButton.CheckedChanged += new System.EventHandler(this._civButton_CheckedChanged);
			// 
			// _renderGroupBox
			// 
			this._renderGroupBox.Controls.Add(this._mainSailFrameField);
			this._renderGroupBox.Controls.Add(this._rotationField);
			this._renderGroupBox.Controls.Add(this._rotationLabel);
			this._renderGroupBox.Controls.Add(this._centerUnitButton);
			this._renderGroupBox.Controls.Add(this.label2);
			this._renderGroupBox.Controls.Add(this._zoomField);
			this._renderGroupBox.Location = new System.Drawing.Point(7, 5);
			this._renderGroupBox.Name = "_renderGroupBox";
			this._renderGroupBox.Size = new System.Drawing.Size(495, 47);
			this._renderGroupBox.TabIndex = 3;
			this._renderGroupBox.TabStop = false;
			this._renderGroupBox.Text = "Rendereinstellungen";
			// 
			// _mainSailFrameField
			// 
			this._mainSailFrameField.Location = new System.Drawing.Point(451, 19);
			this._mainSailFrameField.Maximum = new decimal(new int[] {
            49,
            0,
            0,
            0});
			this._mainSailFrameField.Name = "_mainSailFrameField";
			this._mainSailFrameField.Size = new System.Drawing.Size(38, 20);
			this._mainSailFrameField.TabIndex = 7;
			this._mainSailFrameField.ValueChanged += new System.EventHandler(this._mainSailFrameField_ValueChanged);
			// 
			// _rotationField
			// 
			this._rotationField.Location = new System.Drawing.Point(415, 19);
			this._rotationField.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this._rotationField.Name = "_rotationField";
			this._rotationField.Size = new System.Drawing.Size(30, 20);
			this._rotationField.TabIndex = 6;
			this._rotationField.ValueChanged += new System.EventHandler(this._rotationField_ValueChanged);
			// 
			// _rotationLabel
			// 
			this._rotationLabel.AutoSize = true;
			this._rotationLabel.Location = new System.Drawing.Point(249, 22);
			this._rotationLabel.Name = "_rotationLabel";
			this._rotationLabel.Size = new System.Drawing.Size(160, 13);
			this._rotationLabel.TabIndex = 5;
			this._rotationLabel.Text = "Drehposition / Hauptsegelframe:";
			// 
			// _centerUnitButton
			// 
			this._centerUnitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._centerUnitButton.Location = new System.Drawing.Point(102, 17);
			this._centerUnitButton.Name = "_centerUnitButton";
			this._centerUnitButton.Size = new System.Drawing.Size(141, 23);
			this._centerUnitButton.TabIndex = 4;
			this._centerUnitButton.Text = "Auf Einheit zentrieren";
			this._centerUnitButton.UseVisualStyleBackColor = true;
			this._centerUnitButton.Click += new System.EventHandler(this._centerUnitButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(10, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Zoom:";
			// 
			// _zoomField
			// 
			this._zoomField.DecimalPlaces = 1;
			this._zoomField.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this._zoomField.Location = new System.Drawing.Point(53, 19);
			this._zoomField.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this._zoomField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this._zoomField.Name = "_zoomField";
			this._zoomField.Size = new System.Drawing.Size(43, 20);
			this._zoomField.TabIndex = 0;
			this._zoomField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._zoomField.ValueChanged += new System.EventHandler(this._zoomField_ValueChanged);
			// 
			// _openGraphicsDrsDialog
			// 
			this._openGraphicsDrsDialog.FileName = "graphics.drs";
			this._openGraphicsDrsDialog.Filter = "DRS-Dateien (*.drs)|*.drs";
			this._openGraphicsDrsDialog.Title = "Basis-Graphics-DRS laden...";
			// 
			// _openShipDialog
			// 
			this._openShipDialog.Filter = "Schiffdateien (*.ship)|*.ship";
			this._openShipDialog.Title = "Schiff laden...";
			// 
			// _saveShipDialog
			// 
			this._saveShipDialog.Filter = "Schiffdateien (*.ship)|*.ship";
			this._saveShipDialog.Title = "Schiff speichern...";
			// 
			// _openSlpDialog
			// 
			this._openSlpDialog.Filter = "SLP-Dateien (*.slp)|*.slp";
			this._openSlpDialog.Title = "SLP-Datei laden...";
			// 
			// _sailPanel
			// 
			this._sailPanel.Controls.Add(this._mainSailModeGoButton);
			this._sailPanel.Controls.Add(this._mainSailModeStopButton);
			this._sailPanel.Controls.Add(this._mainSailModeLabel);
			this._sailPanel.Controls.Add(this._mainSailField);
			this._sailPanel.Controls.Add(this._largeSailField);
			this._sailPanel.Controls.Add(this._midSailField);
			this._sailPanel.Controls.Add(this._smallSailField);
			this._sailPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this._sailPanel.Enabled = false;
			this._sailPanel.Location = new System.Drawing.Point(798, 64);
			this._sailPanel.Name = "_sailPanel";
			this._sailPanel.Size = new System.Drawing.Size(251, 388);
			this._sailPanel.TabIndex = 3;
			// 
			// _mainSailModeGoButton
			// 
			this._mainSailModeGoButton.AutoSize = true;
			this._mainSailModeGoButton.Location = new System.Drawing.Point(176, 119);
			this._mainSailModeGoButton.Name = "_mainSailModeGoButton";
			this._mainSailModeGoButton.Size = new System.Drawing.Size(58, 17);
			this._mainSailModeGoButton.TabIndex = 6;
			this._mainSailModeGoButton.Text = "Fahren";
			this._mainSailModeGoButton.UseVisualStyleBackColor = true;
			this._mainSailModeGoButton.CheckedChanged += new System.EventHandler(this._mainSailModeButton_CheckedChanged);
			// 
			// _mainSailModeStopButton
			// 
			this._mainSailModeStopButton.AutoSize = true;
			this._mainSailModeStopButton.Checked = true;
			this._mainSailModeStopButton.Location = new System.Drawing.Point(111, 119);
			this._mainSailModeStopButton.Name = "_mainSailModeStopButton";
			this._mainSailModeStopButton.Size = new System.Drawing.Size(59, 17);
			this._mainSailModeStopButton.TabIndex = 5;
			this._mainSailModeStopButton.TabStop = true;
			this._mainSailModeStopButton.Text = "Stehen";
			this._mainSailModeStopButton.UseVisualStyleBackColor = true;
			this._mainSailModeStopButton.CheckedChanged += new System.EventHandler(this._mainSailModeButton_CheckedChanged);
			// 
			// _mainSailModeLabel
			// 
			this._mainSailModeLabel.AutoSize = true;
			this._mainSailModeLabel.Location = new System.Drawing.Point(6, 121);
			this._mainSailModeLabel.Name = "_mainSailModeLabel";
			this._mainSailModeLabel.Size = new System.Drawing.Size(99, 13);
			this._mainSailModeLabel.TabIndex = 4;
			this._mainSailModeLabel.Text = "Hauptsegel-Modus:";
			// 
			// _mainSailField
			// 
			this._mainSailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._mainSailField.AnchorX = 0;
			this._mainSailField.AnchorY = 0;
			this._mainSailField.Location = new System.Drawing.Point(4, 90);
			this._mainSailField.Name = "_mainSailField";
			this._mainSailField.SailName = "Hauptsegel";
			this._mainSailField.SailUsed = false;
			this._mainSailField.Size = new System.Drawing.Size(244, 23);
			this._mainSailField.TabIndex = 3;
			this._mainSailField.Changed += new System.EventHandler(this._mainSailField_Changed);
			// 
			// _largeSailField
			// 
			this._largeSailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._largeSailField.AnchorX = 0;
			this._largeSailField.AnchorY = 0;
			this._largeSailField.Location = new System.Drawing.Point(4, 61);
			this._largeSailField.Name = "_largeSailField";
			this._largeSailField.SailName = "Großes Nebensegel";
			this._largeSailField.SailUsed = false;
			this._largeSailField.Size = new System.Drawing.Size(244, 23);
			this._largeSailField.TabIndex = 2;
			this._largeSailField.Changed += new System.EventHandler(this._largeSailField_Changed);
			// 
			// _midSailField
			// 
			this._midSailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._midSailField.AnchorX = 0;
			this._midSailField.AnchorY = 0;
			this._midSailField.Location = new System.Drawing.Point(4, 32);
			this._midSailField.Name = "_midSailField";
			this._midSailField.SailName = "Mittleres Nebensegel";
			this._midSailField.SailUsed = false;
			this._midSailField.Size = new System.Drawing.Size(244, 23);
			this._midSailField.TabIndex = 1;
			this._midSailField.Changed += new System.EventHandler(this._midSailField_Changed);
			// 
			// _smallSailField
			// 
			this._smallSailField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._smallSailField.AnchorX = 0;
			this._smallSailField.AnchorY = 0;
			this._smallSailField.Location = new System.Drawing.Point(4, 3);
			this._smallSailField.Name = "_smallSailField";
			this._smallSailField.SailName = "Kleines Nebensegel";
			this._smallSailField.SailUsed = false;
			this._smallSailField.Size = new System.Drawing.Size(244, 23);
			this._smallSailField.TabIndex = 0;
			this._smallSailField.Changed += new System.EventHandler(this._smallSailField_Changed);
			// 
			// _openExportFolderDialog
			// 
			this._openExportFolderDialog.Description = "Export-Ordner auswählen...";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1049, 512);
			this.Controls.Add(this._drawPanel);
			this.Controls.Add(this._sailPanel);
			this.Controls.Add(this._bottomPanel);
			this.Controls.Add(this._mainPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "X2-AddOn :: Schiffe verankern";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this._mainPanel.ResumeLayout(false);
			this._shipGroupBox.ResumeLayout(false);
			this._shipGroupBox.PerformLayout();
			this._menuGroupBox.ResumeLayout(false);
			this._bottomPanel.ResumeLayout(false);
			this._civGroupBox.ResumeLayout(false);
			this._renderGroupBox.ResumeLayout(false);
			this._renderGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._mainSailFrameField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._rotationField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._zoomField)).EndInit();
			this._sailPanel.ResumeLayout(false);
			this._sailPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private OpenTK.GLControl _drawPanel;
		private System.Windows.Forms.Panel _mainPanel;
		private System.Windows.Forms.Panel _bottomPanel;
		private System.Windows.Forms.GroupBox _renderGroupBox;
		private System.Windows.Forms.Button _centerUnitButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown _zoomField;
		private System.Windows.Forms.OpenFileDialog _openGraphicsDrsDialog;
		private System.Windows.Forms.Button _openShipButton;
		private System.Windows.Forms.GroupBox _menuGroupBox;
		private System.Windows.Forms.Button _saveShipButton;
		private System.Windows.Forms.Button _exportButton;
		private System.Windows.Forms.OpenFileDialog _openShipDialog;
		private System.Windows.Forms.SaveFileDialog _saveShipDialog;
		private System.Windows.Forms.Button _newShipButton;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.Label _nameLabel;
		private System.Windows.Forms.GroupBox _shipGroupBox;
		private System.Windows.Forms.Button _importShadowSlpButton;
		private System.Windows.Forms.Button _importBaseSlpButton;
		private System.Windows.Forms.OpenFileDialog _openSlpDialog;
		private System.Windows.Forms.Panel _sailPanel;
		private SailPlacementControl _smallSailField;
		private SailPlacementControl _largeSailField;
		private SailPlacementControl _midSailField;
		private SailPlacementControl _mainSailField;
		private System.Windows.Forms.RadioButton _civASButton;
		private System.Windows.Forms.GroupBox _civGroupBox;
		private System.Windows.Forms.RadioButton _civWEButton;
		private System.Windows.Forms.RadioButton _civORButton;
		private System.Windows.Forms.RadioButton _civMEButton;
		private System.Windows.Forms.RadioButton _civINButton;
		private System.Windows.Forms.NumericUpDown _rotationField;
		private System.Windows.Forms.Label _rotationLabel;
		private System.Windows.Forms.NumericUpDown _mainSailFrameField;
		private System.Windows.Forms.RadioButton _mainSailModeGoButton;
		private System.Windows.Forms.RadioButton _mainSailModeStopButton;
		private System.Windows.Forms.Label _mainSailModeLabel;
		private System.Windows.Forms.FolderBrowserDialog _openExportFolderDialog;
	}
}

