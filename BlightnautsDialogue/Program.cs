using System;
using System.Windows.Forms;

namespace BlightnautsDialogue
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
            //Application.Run(new FormTeam());
            // Disabled for now
            ProjectManager.LoadProject();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Exporter.DialogueExporter.Export(dialog.SelectedPath + "\\AnimationTemplates");
                Exporter.BehaviourExporter.Export(dialog.SelectedPath + "\\Behaviours");
                Exporter.MapExporter.Export(dialog.SelectedPath + "\\Maps\\externalToolTest\\Gameplay.xml");
            }
        }
    }
}
