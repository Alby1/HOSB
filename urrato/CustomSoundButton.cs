using urrato.Properties;

namespace HOSB
{
    class CustomSoundButton : Button
    {

        public string fileName;

        public CustomSoundButton(string? fileName = null)
        {
            ContextMenuStrip giorgio = new();
            ToolStripMenuItem luca = new("Set as...");
            for(int i = 1; i<=9; i++)
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
                Clipboard.SetText(fileName!);
            };
            giorgio.Items.Add(clipboard);

            ContextMenuStrip = giorgio;

            this.fileName = fileName!;
        }

        private void HotkeySet(int a)
        {
            Settings.Default[$"hot{a}"] = fileName;
            Settings.Default.Save();

            Program.hotKeysForm!.ShowHotKeys();
        }
    }
}
