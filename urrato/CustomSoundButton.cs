using urrato.Properties;

namespace HOSB
{
    class CustomSoundButton : Button
    {

        public string Filename;
        public string Label;


        public CustomSoundButton(string fileName)
        {
            ContextMenuStrip giorgio = new();
            ToolStripMenuItem luca = new("Set as...");

            Label = fileName[(fileName.LastIndexOf('\\') + 1)..];
            Filename = fileName;
            Text = Label;

            for (int i = 1; i<=9; i++)
            {
                int n = i;
                luca.DropDownItems.Add($"{n}", null, (sender, e) => HotkeySet(n));
            }
            luca.DropDownItems.Add("0", null, (sender, e) => HotkeySet(0));
            giorgio.Items.Add(luca);

            luca.MouseHover += (sender, e) => luca.ShowDropDown();

            ToolStripMenuItem clipboard = new("Copy to clipboard");
            clipboard.Click += (sender, e) =>
            {
                Clipboard.SetText(Label!);
            };
            giorgio.Items.Add(clipboard);

            ContextMenuStrip = giorgio;
        }

        private void HotkeySet(int a)
        {
            Settings.Default[$"hot{a}"] = Filename;
            Settings.Default.Save();

            Program.hotKeysForm!.ShowHotKeys();
        }
    }
}
