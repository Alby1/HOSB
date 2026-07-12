
namespace HOSB
{
    partial class SetHotKeysViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetHotKeysViewer));
            ResetHotKeysButton = new Button();
            QueriedPanel = new FlowLayoutPanel();
            StopButtonHK = new Button();
            StopLastButtonHK = new Button();
            SuspendLayout();
            // 
            // ResetHotKeysButton
            // 
            ResetHotKeysButton.BackColor = SystemColors.ControlDark;
            ResetHotKeysButton.Location = new Point(13, 289);
            ResetHotKeysButton.Margin = new Padding(4, 3, 4, 3);
            ResetHotKeysButton.Name = "ResetHotKeysButton";
            ResetHotKeysButton.Size = new Size(103, 46);
            ResetHotKeysButton.TabIndex = 1;
            ResetHotKeysButton.Text = "R&eset All";
            ResetHotKeysButton.UseVisualStyleBackColor = false;
            ResetHotKeysButton.Click += ResetHotKeysButton_Click;
            // 
            // QueriedPanel
            // 
            QueriedPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            QueriedPanel.AutoScroll = true;
            QueriedPanel.BackColor = SystemColors.ControlDarkDark;
            QueriedPanel.FlowDirection = FlowDirection.TopDown;
            QueriedPanel.Location = new Point(124, 10);
            QueriedPanel.Margin = new Padding(4, 3, 4, 3);
            QueriedPanel.Name = "QueriedPanel";
            QueriedPanel.Size = new Size(544, 325);
            QueriedPanel.TabIndex = 4;
            // 
            // StopButtonHK
            // 
            StopButtonHK.BackColor = SystemColors.ControlDark;
            StopButtonHK.Location = new Point(13, 237);
            StopButtonHK.Margin = new Padding(4, 3, 4, 3);
            StopButtonHK.Name = "StopButtonHK";
            StopButtonHK.Size = new Size(103, 46);
            StopButtonHK.TabIndex = 5;
            StopButtonHK.Text = "&Stop Playback";
            StopButtonHK.UseVisualStyleBackColor = false;
            StopButtonHK.Click += StopButtonHK_Click;
            // 
            // StopLastButtonHK
            // 
            StopLastButtonHK.BackColor = SystemColors.ControlDark;
            StopLastButtonHK.Location = new Point(13, 185);
            StopLastButtonHK.Margin = new Padding(4, 3, 4, 3);
            StopLastButtonHK.Name = "StopLastButtonHK";
            StopLastButtonHK.Size = new Size(103, 46);
            StopLastButtonHK.TabIndex = 6;
            StopLastButtonHK.Text = "S&top Last";
            StopLastButtonHK.UseVisualStyleBackColor = false;
            StopLastButtonHK.Click += StopLastButtonHK_Click;
            // 
            // SetHotKeysViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(681, 347);
            Controls.Add(StopLastButtonHK);
            Controls.Add(StopButtonHK);
            Controls.Add(QueriedPanel);
            Controls.Add(ResetHotKeysButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(697, 386);
            MinimumSize = new Size(697, 386);
            Name = "SetHotKeysViewer";
            Text = "Hot Keys";
            FormClosing += SetHotKeysViewer_FormClosing;
            Load += SetHotKeysViewer_Load;
            Resize += SetHotKeysViewer_Resize;
            ResumeLayout(false);
        }

        #endregion
        private Button ResetHotKeysButton;
        private FlowLayoutPanel QueriedPanel;
        private Button StopButtonHK;
        private Button StopLastButtonHK;
    }
}