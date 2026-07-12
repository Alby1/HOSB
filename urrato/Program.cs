using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using urrato.Properties;

namespace HOSB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            hotKeysForm = new SetHotKeysViewer();
            main = new Form1();
            using NotifyIcon icon = new();
            icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            ContextMenuStrip CMS = new();

            ToolStripMenuItem showItem = new("Show form");
            showItem.Click += (s, e) => { main.Show(); };

            ToolStripMenuItem quitItem = new("Quit");
            quitItem.Click += (s, e) =>
            {
                main.Close();
                icon.Visible = false;
                Application.Exit();
            };


            ToolStripMenuItem serverActiveItem = new("Server active")
            {
                CheckOnClick = true,
                Checked = Settings.Default.ServerEnabled
            };
            if (serverActiveItem.Checked)
            {
                Server.SetupServer();
            }
            serverActiveItem.CheckedChanged += (s, e) =>
            {
                if (serverActiveItem.Checked)
                {
                    Server.SetupServer();
                }
                else
                {
                    Server.CloseAllSockets();
                }

                Settings.Default.ServerEnabled = serverActiveItem.Checked;
                Settings.Default.Save();
            };

            ToolStripMenuItem startMinimizedItem = new("Start minimized")
            {
                CheckOnClick = true,
                Checked = Settings.Default.StartMinimized
            };
            startMinimizedItem.CheckedChanged += (s, e) =>
            {
                Settings.Default.StartMinimized = startMinimizedItem.Checked;
                Settings.Default.Save();
            };

            CMS.Items.Add(showItem);
            CMS.Items.Add(serverActiveItem);
            CMS.Items.Add(startMinimizedItem);
            CMS.Items.Add(quitItem);

            icon.ContextMenuStrip = CMS;
            icon.Visible = true;


            if (!Settings.Default.StartMinimized) main.Show();

            Application.Run();
        }

        public static SetHotKeysViewer? hotKeysForm;
        public static Form1? main;
    }
}
