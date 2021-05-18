﻿using Legacy;
using System;
using System.Windows.Forms;

namespace BlightnautsDialogue
{
    public partial class LegacyImportWindow : Form
    {
        public LegacyImportWindow()
        {
            InitializeComponent();
            foreach (var naut in ProjectManager.Characters)
            {
                dropdownCharacters.Items.Add(naut.IndexedName + " (" + naut.RealName + ")");
            }
            dropdownCharacters.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int result = LegacyLoader.Load(textBoxFile.Text, dropdownCharacters.SelectedIndex);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Import successful.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    break;

                case 1:
                    MessageBox.Show("An error has occurred while importing.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case 2:
                    MessageBox.Show("File does not exist.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case 3:
                    MessageBox.Show("Triggers do not match.\n" +
                    "Triggers must match the Areas generated by the original tool. They are:\n\n" +
                    "intro (3 team dialogues)\nobelisk (2 team dialogues)\n" +
                    "spitblight (2 team dialogues)\nkey1 (1 team dialogue)\nturret (2 team dialogues)\n" +
                    "water (1 team dialogue)\ntreasure (1 team dialogue)\nkey2 (1 team dialogue)\n" +
                    "switches (2 team dialogues)\nbottom (2 team dialogues)\nsawPuzzle (2 team dialogues)\n" +
                    "sawTrap (1 team dialogue)\nfinalIntro (3 team dialogues)\nfinalShield (1 team dialogues)\n\n" +
                    "in that order.",
                    "Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFile.Text = openFileDialog.FileName;
            }
        }
    }
}
