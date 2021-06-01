using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BlightnautsDialogue
{
    public static class Settings
    {
        private static string Path { get => Program.Path + "\\config.ini"; }
        private const string font = "FONT=";
        private const string foregroundColor = "FOREGROUNDCOLOR=";
        private const string backgroundColor = "BACKGROUNDCOLOR=";
        private const string lastSaveFile = "LASTFILE=";

        public static int Save(Font font, Color fore, Color back)
        {
            int effect = 0;
            if (font.Bold && font.Italic)
                effect = 3;
            else if (font.Bold)
                effect = 1;
            else if (font.Italic)
                effect = 2;

            string content = string.Format("{0}{1};{2};{3}",
            Settings.font,
            font.FontFamily.Name,
            font.Size.ToString("F2", CultureInfo.InvariantCulture),
            effect.ToString(CultureInfo.InvariantCulture));

            content += string.Format
            (
                "\n{0}{1} {2} {3}",
                foregroundColor,
                fore.R.ToString(CultureInfo.InvariantCulture),
                fore.G.ToString(CultureInfo.InvariantCulture),
                fore.B.ToString(CultureInfo.InvariantCulture)
            );
            content += string.Format
            (
                "\n{0}{1} {2} {3}",
                backgroundColor,
                back.R.ToString(CultureInfo.InvariantCulture),
                back.G.ToString(CultureInfo.InvariantCulture),
                back.B.ToString(CultureInfo.InvariantCulture)
            );
            content += string.Format
            (
                "\n{0}{1}",
                lastSaveFile,
                ProjectManager.LastFilePath
            );

            try
            {
                File.WriteAllText(Path, content);
            }
            catch
            {
                return 1;
            }

            return 0;
        }

        public static int Load(out Font font, out Color fore, out Color back)
        {
            font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular, GraphicsUnit.Point);
            fore = SystemColors.WindowText;
            back = SystemColors.Window;

            if (!File.Exists(Path))
                return 1;

            try
            {
                string[] content = File.ReadAllLines(Path);

                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i].StartsWith(Settings.font))
                    {
                        string[] info = content[i].Substring(Settings.font.Length).Split(';');
                        FontFamily fontFamily = FontFamily.Families.FirstOrDefault(n => n.Name == info[0]);
                        float fontSize = float.Parse(info[1], CultureInfo.InvariantCulture);
                        FontStyle fontStyle = FontStyle.Regular;
                        if (info[2] == "1")
                            fontStyle = FontStyle.Bold;
                        else if (info[2] == "2")
                            fontStyle = FontStyle.Italic;
                        else if (info[2] == "3")
                            fontStyle = FontStyle.Bold | FontStyle.Italic;
                        font = new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Point);
                    }
                    else if (content[i].StartsWith(foregroundColor))
                    {
                        string[] colors = content[i].Substring(foregroundColor.Length).Split(' ');
                        int r = int.Parse(colors[0], CultureInfo.InvariantCulture);
                        int g = int.Parse(colors[1], CultureInfo.InvariantCulture);
                        int b = int.Parse(colors[2], CultureInfo.InvariantCulture);
                        fore = Color.FromArgb(r, g, b);
                    }
                    else if (content[i].StartsWith(backgroundColor))
                    {
                        string[] colors = content[i].Substring(backgroundColor.Length).Split(' ');
                        int r = int.Parse(colors[0], CultureInfo.InvariantCulture);
                        int g = int.Parse(colors[1], CultureInfo.InvariantCulture);
                        int b = int.Parse(colors[2], CultureInfo.InvariantCulture);
                        back = Color.FromArgb(r, g, b);
                    }
                    else if (content[i].StartsWith(lastSaveFile))
                    {
                        ProjectManager.TestLastSaveFile(content[i].Substring(lastSaveFile.Length));
                    }
                }
            }
            catch
            {
                return 2;
            }

            return 0;
        }
    }
}
