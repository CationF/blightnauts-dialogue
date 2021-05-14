using System;
using System.Windows.Forms;

namespace BlightnautsDialogue
{
    static class Program
    {
        public static string Path { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.Run(new EditorWindow());
        }
    }
}
