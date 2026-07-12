using urrato.Properties;

namespace HOSB
{
    public partial class SetHotKeysViewer : Form
    {
        public SetHotKeysViewer()
        {
            InitializeComponent();
        }

        private void SetHotKeysViewer_Load(object sender, EventArgs e)
        {
            ShowHotKeys();
        }

        public void ShowHotKeys()
        {
            Pulsantati();
            for (int i = 0; i <= 9; i++)
            {
                string text = Settings.Default[$"hot{i}"].ToString()!;
                text = $"Hot Key {i}: " + (text == string.Empty ? "!EMPTY!" : text);
                QueriedPanel.Controls[$"buton{i}"]!.Text = text;
            }
        }

        private void ResetHotKeysButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 9; i++)
            {
                Settings.Default[$"hot{i}"] = "";
                Settings.Default.Save();
            }
            ShowHotKeys();
        }

        private void SetHotKeysViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void SetHotKeysViewer_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                Program.main!.WindowState = FormWindowState.Normal;
        }

        private void Pulsantati()
        {
            QueriedPanel.Controls.Clear();
            for (int i = 1; i <= 9; i++)
            {
                string text = Settings.Default[$"hot{i}"].ToString()!;
                CustomSoundButton button = new CustomSoundButton(text);
                text = $"Hot Key {i}: " + (text == string.Empty ? "!EMPTY!" : text);
                button.Name = $"buton{i}";
                button.AutoSize = true;
                button.Text = text;
                button.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
                button.MouseClick += Program.main!.SongButtons_OnClick!;
                QueriedPanel.Controls.Add(button);
            }

            string te = Settings.Default.hot0.ToString()!;
            CustomSoundButton bu = new CustomSoundButton(te);
            te = $"Hot Key 0: " + (te == string.Empty ? "!EMPTY!" : te);
            bu.Name = $"buton0";
            bu.AutoSize = true;
            bu.Text = te;
            bu.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            bu.MouseClick += Program.main!.SongButtons_OnClick!;
            QueriedPanel.Controls.Add(bu);
        }

        private void StopButtonHK_Click(object sender, EventArgs e)
        {
            Program.main!.StopSong(false);
        }

        private void StopLastButtonHK_Click(object sender, EventArgs e)
        {
            if(Settings.Default.SingleModeActive)
            {
                Program.main!.StopSong(true);
                return;
            }
            Program.main!.StopLastSong();
        }
    }
}
