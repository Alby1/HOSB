using System.Data;
using System.Diagnostics;
using WMPLib;
using Hotkeys;
using urrato.Properties;
using System;

/*
 * TODO:
 * - whole thing again but for android
*/

namespace HOSB
{
    public partial class Form1 : Form
    {

        List<WindowsMediaPlayer> wmps = new List<WindowsMediaPlayer>();

        WindowsMediaPlayer SingleWMP = new WindowsMediaPlayer();

        GlobalHotkeys[] hk = new GlobalHotkeys[10];
        GlobalHotkeys stop;

        List<string>? GlobTracks;
        List<CustomSoundButton>? GlobButtons;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < hk.Length - 1; i++)
            {
                hk[i] = new GlobalHotkeys(Constants.CTRL + Constants.SHIFT, (Keys)(49 + i), this);
            }

            hk[9] = new GlobalHotkeys(Constants.CTRL + Constants.SHIFT, (Keys)(48), this);

            stop = new GlobalHotkeys(Constants.CTRL + Constants.SHIFT, Keys.OemPipe, this);

            Program.main = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int volume = Settings.Default.Volume;
            volumeBar.Value = volume;
            SingleWMP.settings.volume = volume;

            SingleModeCheckBox.Checked = Settings.Default.SingleModeActive;

            VersionLabel.Text = Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion")?.ToString();

            foreach (GlobalHotkeys g in hk)
            {
                g.Register();
            }

            stop.Register();

            LoadTracks();
        }

        private void LoadTracks()
        {
            CurrentPathLabel.Text = Settings.Default.SoundsDir;
            CurrentPathLabel.ForeColor = Color.Black;
            ButtonsPanel.Controls.Clear();

            try
            {
                GlobTracks = new List<string>(Directory.GetFiles(Settings.Default.SoundsDir));
            }
            catch
            {
                CurrentPathLabel.Text = "Path selected does not exist, please choose another one!";
                CurrentPathLabel.ForeColor = Color.Red;
                return;
            }

            GlobButtons = CreateButtons(tracks: GlobTracks);

            DrawButtons(CreateButtons(GlobTracks), ButtonsPanel);

            SearchText_TextChanged(null!, null!);
        }

        private List<CustomSoundButton> CreateButtons(List<string> tracks)
        {
            List<CustomSoundButton> ciao = new List<CustomSoundButton>();
            foreach (string track in tracks)
            {
                if (track.EndsWith("mp3") || track.EndsWith("mp4") || track.EndsWith("wav") || track.EndsWith("m4a"))
                {
                    CustomSoundButton b = new CustomSoundButton(track.Substring(track.LastIndexOf("\\") + 1)) { Text = track.Substring(track.LastIndexOf("\\") + 1), Size = new Size(131, 45), BackColor = System.Drawing.Color.FromKnownColor(KnownColor.ControlDark) };
                    b.MouseClick += SongButtons_OnClick!;

                    ciao.Add(b);
                }
            }
            return ciao;
        }

        private static void DrawButtons(List<CustomSoundButton> buttons, FlowLayoutPanel panel)
        {
            panel.Controls.AddRange(buttons.ToArray());
        }

        private void volumeBar_ValueChanged(object sender, EventArgs e)
        {
            int volume = Convert.ToInt32(volumeBar.Value);
            if (SingleModeCheckBox.Checked)
            {
                SingleWMP.settings.volume = volume;
                return;
            }
            foreach (WindowsMediaPlayer player in wmps)
            {
                player.settings.volume = volume;
            }
            Settings.Default.Volume = volume;
            Settings.Default.Save();
        }

        public void SongButtons_OnClick(object sender, MouseEventArgs e)
        {
            CustomSoundButton? b = sender as CustomSoundButton;
            if (b!.fileName == null || b!.fileName == string.Empty) return;
            PlaySong(b!.fileName, false);
        }

        public void PlaySong(string filePath, bool isHotKey)
        {
            filePath = $"{Settings.Default.SoundsDir}\\{filePath}";
            if (!File.Exists(filePath))
            {
                if (!isHotKey) LoadTracks();
                return;
            }
            if (SingleModeCheckBox.Checked)
            {
                SingleWMP.URL = filePath;
                return;
            }
            WindowsMediaPlayer player;
            while (true)
            {
                try
                {
                    player = new WindowsMediaPlayer();
                    wmps.Add(player);
                    player.settings.volume = Settings.Default.Volume;
                    player.URL = filePath;
                    break;

                } catch { }
            }
            RAMCleanupTimer.Start();
        }

        public void StopSong(bool sc)
        {
            if (sc || SingleModeCheckBox.Checked)
            {
                SingleWMP.controls.stop();
                return;
            }
            foreach (var player in wmps.ToArray()) player.controls.stop();
            RAMCleanupTimer_Tick(null!, null!);
        }

        public void StopLastSong()
        {
            if (wmps.Count < 1) return;
            wmps.Last().controls.stop();

            RAMCleanupTimer_Tick(null!, null!);
        }

        private void AudioDirButton_Click(object sender, EventArgs e)
        {
            ChooseFolder(Settings.Default.SoundsDir);
        }

        private void ChooseFolder(string initialPath)
        {
            if (initialPath.Length == 0)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.SoundsDir = fbd.SelectedPath;
                        Settings.Default.Save();
                    }
                }

            }
            else
            {
                try
                {
                    using (FolderBrowserDialog fbd = new FolderBrowserDialog() { SelectedPath = initialPath })
                    {
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            Settings.Default.SoundsDir = fbd.SelectedPath;
                            Settings.Default.Save();
                        }
                    }
                }
                catch
                {
                    ChooseFolder("");
                    return;
                }
            }

            StopSong(false);
            LoadTracks();
        }

        private void CurrentPathLabel_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", CurrentPathLabel.Text);
            }
            catch
            {
                return;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopSong(false);
        }

        private void StopLastButton_Click(object sender, EventArgs e)
        {
            StopLastSong();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        private static Keys GetKey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }
        private void HandleHotkey(Message m)
        {
            if (GetKey(m.LParam) == Keys.OemPipe)
            {
                if (Settings.Default.SingleModeActive)
                {
                    StopSong(true);
                    return;
                }
                StopLastSong();
                return;
            }

            if ((int)GetKey(m.LParam) < 48 || (int)GetKey(m.LParam) > 57) return;

            int i = (int)GetKey(m.LParam) - 48;

            string song = Settings.Default[$"hot{i}"].ToString()!;

            PlaySong(song, true);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                HandleHotkey(m);
            }
            base.WndProc(ref m);
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            LoadTracks();
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            QueriedPanel.Controls.Clear();

            //IEnumerable<CustomSoundButton> result = tracks.Where(s => ButtonsPanel.Controls.Text.ToLower().Contains(SearchText.Text.ToLower()));

            IEnumerable<CustomSoundButton> result = from CustomSoundButton b in GlobButtons! where b.Text.ToLower().Contains(SearchText.Text.ToLower()) select b;

            DrawButtons(buttons: result.ToList(), QueriedPanel);
        }

        private void ShowHotKeysButton_Click(object sender, EventArgs e)
        {
            Program.hotKeysForm!.Show();
            Program.hotKeysForm.WindowState = FormWindowState.Normal;
            Program.hotKeysForm.Location = new Point(Location.X + Width, Location.Y);
        }

        private void LowerVolumeButton_Click(object sender, EventArgs e)
        {
            try
            {

                volumeBar.Value -= 5;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void HigherVolumeButton_Click(object sender, EventArgs e)
        {
            try
            {
                volumeBar.Value += 5;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void RAMCleanupTimer_Tick(object sender, EventArgs e)
        {
            if (wmps.Count > 0)
            {
                foreach (var player in wmps.ToArray())
                {
                    if (player.playState != WMPPlayState.wmppsStopped) continue;

                    wmps.Remove(player);

                }
                GC.Collect();
            }
            else
            {
                GC.Collect();
                RAMCleanupTimer.Stop();
            }
        }

        private void SingleModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            StopLastButton.Enabled = !StopLastButton.Enabled;
            Settings.Default.SingleModeActive = SingleModeCheckBox.Checked;
            Settings.Default.Save();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (GlobalHotkeys g in hk)
            {
                g.Unregister();
            }

            stop.Unregister();


            Server.CloseAllSockets();
        }
    }
}
