
namespace HOSB
{
    partial class Form1
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
            if (disposing && (components != null))
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            VolumeBar = new TrackBar();
            ButtonsPanel = new FlowLayoutPanel();
            AudioDirButton = new Button();
            CurrentPathLabel = new Label();
            StopButton1 = new Button();
            ReloadButton = new Button();
            QueriedPanel = new FlowLayoutPanel();
            SearchText = new TextBox();
            ShowHotKeysButton = new Button();
            StopLastButton = new Button();
            LowerVolumeButton = new Button();
            HigherVolumeButton = new Button();
            RAMCleanupTimer = new System.Windows.Forms.Timer(components);
            SingleModeCheckBox = new CheckBox();
            VersionLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)VolumeBar).BeginInit();
            SuspendLayout();
            // 
            // VolumeBar
            // 
            VolumeBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            VolumeBar.BackColor = SystemColors.ControlDarkDark;
            VolumeBar.LargeChange = 10;
            VolumeBar.Location = new Point(64, 446);
            VolumeBar.Margin = new Padding(4, 3, 4, 3);
            VolumeBar.Maximum = 100;
            VolumeBar.Name = "VolumeBar";
            VolumeBar.Size = new Size(505, 45);
            VolumeBar.TabIndex = 1;
            VolumeBar.TickFrequency = 5;
            VolumeBar.ValueChanged += VolumeBar_ValueChanged;
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonsPanel.AutoScroll = true;
            ButtonsPanel.BackColor = SystemColors.ControlDarkDark;
            ButtonsPanel.Location = new Point(13, 12);
            ButtonsPanel.Margin = new Padding(4, 3, 4, 3);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Size = new Size(200, 397);
            ButtonsPanel.TabIndex = 2;
            // 
            // AudioDirButton
            // 
            AudioDirButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AudioDirButton.BackColor = SystemColors.ControlDark;
            AudioDirButton.Location = new Point(423, 12);
            AudioDirButton.Margin = new Padding(4, 3, 4, 3);
            AudioDirButton.Name = "AudioDirButton";
            AudioDirButton.Size = new Size(194, 69);
            AudioDirButton.TabIndex = 3;
            AudioDirButton.Text = "Select &Folder";
            AudioDirButton.UseVisualStyleBackColor = false;
            AudioDirButton.Click += AudioDirButton_Click;
            // 
            // CurrentPathLabel
            // 
            CurrentPathLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CurrentPathLabel.Cursor = Cursors.Hand;
            CurrentPathLabel.Location = new Point(423, 173);
            CurrentPathLabel.Margin = new Padding(4, 0, 4, 0);
            CurrentPathLabel.Name = "CurrentPathLabel";
            CurrentPathLabel.Size = new Size(194, 43);
            CurrentPathLabel.TabIndex = 4;
            CurrentPathLabel.Text = "path";
            CurrentPathLabel.Click += CurrentPathLabel_Click;
            // 
            // StopButton1
            // 
            StopButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StopButton1.BackColor = SystemColors.ControlDark;
            StopButton1.Location = new Point(429, 294);
            StopButton1.Margin = new Padding(4, 3, 4, 3);
            StopButton1.Name = "StopButton1";
            StopButton1.Size = new Size(192, 69);
            StopButton1.TabIndex = 5;
            StopButton1.Text = "&Stop";
            StopButton1.UseVisualStyleBackColor = false;
            StopButton1.Click += StopButton_Click;
            // 
            // ReloadButton
            // 
            ReloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ReloadButton.BackColor = SystemColors.ControlDark;
            ReloadButton.Location = new Point(423, 92);
            ReloadButton.Margin = new Padding(4, 3, 4, 3);
            ReloadButton.Name = "ReloadButton";
            ReloadButton.Size = new Size(194, 69);
            ReloadButton.TabIndex = 6;
            ReloadButton.Text = "&Reload Files";
            ReloadButton.UseVisualStyleBackColor = false;
            ReloadButton.Click += ReloadButton_Click;
            // 
            // QueriedPanel
            // 
            QueriedPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            QueriedPanel.AutoScroll = true;
            QueriedPanel.BackColor = SystemColors.ControlDarkDark;
            QueriedPanel.Location = new Point(220, 12);
            QueriedPanel.Margin = new Padding(4, 3, 4, 3);
            QueriedPanel.Name = "QueriedPanel";
            QueriedPanel.Size = new Size(200, 397);
            QueriedPanel.TabIndex = 3;
            // 
            // SearchText
            // 
            SearchText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SearchText.BackColor = SystemColors.ControlDark;
            SearchText.BorderStyle = BorderStyle.FixedSingle;
            SearchText.Location = new Point(221, 415);
            SearchText.Margin = new Padding(4, 3, 4, 3);
            SearchText.Name = "SearchText";
            SearchText.PlaceholderText = "Search";
            SearchText.Size = new Size(200, 23);
            SearchText.TabIndex = 7;
            SearchText.TextAlign = HorizontalAlignment.Center;
            SearchText.TextChanged += SearchText_TextChanged;
            // 
            // ShowHotKeysButton
            // 
            ShowHotKeysButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ShowHotKeysButton.BackColor = SystemColors.ControlDark;
            ShowHotKeysButton.Location = new Point(429, 369);
            ShowHotKeysButton.Margin = new Padding(4, 3, 4, 3);
            ShowHotKeysButton.Name = "ShowHotKeysButton";
            ShowHotKeysButton.Size = new Size(194, 69);
            ShowHotKeysButton.TabIndex = 8;
            ShowHotKeysButton.Text = "Show &HotKeys";
            ShowHotKeysButton.UseVisualStyleBackColor = false;
            ShowHotKeysButton.Click += ShowHotKeysButton_Click;
            // 
            // StopLastButton
            // 
            StopLastButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StopLastButton.BackColor = SystemColors.ControlDark;
            StopLastButton.Location = new Point(429, 219);
            StopLastButton.Margin = new Padding(4, 3, 4, 3);
            StopLastButton.Name = "StopLastButton";
            StopLastButton.Size = new Size(192, 69);
            StopLastButton.TabIndex = 9;
            StopLastButton.Text = "S&top last track";
            StopLastButton.UseVisualStyleBackColor = false;
            StopLastButton.Click += StopLastButton_Click;
            // 
            // LowerVolumeButton
            // 
            LowerVolumeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LowerVolumeButton.BackColor = SystemColors.ControlDark;
            LowerVolumeButton.Location = new Point(12, 446);
            LowerVolumeButton.Name = "LowerVolumeButton";
            LowerVolumeButton.Size = new Size(45, 45);
            LowerVolumeButton.TabIndex = 11;
            LowerVolumeButton.Text = "&-";
            LowerVolumeButton.UseVisualStyleBackColor = false;
            LowerVolumeButton.Click += LowerVolumeButton_Click;
            // 
            // HigherVolumeButton
            // 
            HigherVolumeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            HigherVolumeButton.BackColor = SystemColors.ControlDark;
            HigherVolumeButton.Location = new Point(576, 446);
            HigherVolumeButton.Name = "HigherVolumeButton";
            HigherVolumeButton.Size = new Size(45, 45);
            HigherVolumeButton.TabIndex = 12;
            HigherVolumeButton.Text = "&+";
            HigherVolumeButton.UseVisualStyleBackColor = false;
            HigherVolumeButton.Click += HigherVolumeButton_Click;
            // 
            // RAMCleanupTimer
            // 
            RAMCleanupTimer.Enabled = true;
            RAMCleanupTimer.Interval = 10000;
            RAMCleanupTimer.Tick += RAMCleanupTimer_Tick;
            // 
            // SingleModeCheckBox
            // 
            SingleModeCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SingleModeCheckBox.Appearance = Appearance.Button;
            SingleModeCheckBox.BackColor = SystemColors.ControlDark;
            SingleModeCheckBox.Location = new Point(14, 415);
            SingleModeCheckBox.Name = "SingleModeCheckBox";
            SingleModeCheckBox.Size = new Size(200, 25);
            SingleModeCheckBox.TabIndex = 13;
            SingleModeCheckBox.Text = "Single Mode";
            SingleModeCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            SingleModeCheckBox.UseVisualStyleBackColor = false;
            SingleModeCheckBox.CheckedChanged += SingleModeCheckBox_CheckedChanged;
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            VersionLabel.Location = new Point(553, 494);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(70, 20);
            VersionLabel.TabIndex = 14;
            VersionLabel.Text = "version";
            VersionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(628, 521);
            Controls.Add(VersionLabel);
            Controls.Add(ShowHotKeysButton);
            Controls.Add(SingleModeCheckBox);
            Controls.Add(HigherVolumeButton);
            Controls.Add(LowerVolumeButton);
            Controls.Add(ButtonsPanel);
            Controls.Add(QueriedPanel);
            Controls.Add(StopLastButton);
            Controls.Add(SearchText);
            Controls.Add(ReloadButton);
            Controls.Add(AudioDirButton);
            Controls.Add(StopButton1);
            Controls.Add(CurrentPathLabel);
            Controls.Add(VolumeBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximumSize = new Size(931, 1148);
            MinimumSize = new Size(644, 560);
            Name = "Form1";
            Text = "HOSB";
            FormClosing += Form1_FormClosing;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)VolumeBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar VolumeBar;
        private FlowLayoutPanel ButtonsPanel;
        private Button AudioDirButton;
        private Label CurrentPathLabel;
        private Button StopButton1;
        private Button ReloadButton;
        private FlowLayoutPanel QueriedPanel;
        private TextBox SearchText;
        private Button ShowHotKeysButton;
        private Button StopLastButton;
        private Button LowerVolumeButton;
        private Button HigherVolumeButton;
        private System.Windows.Forms.Timer RAMCleanupTimer;
        private CheckBox SingleModeCheckBox;
        private Label VersionLabel;
    }
}

