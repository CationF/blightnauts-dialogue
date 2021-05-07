using System;
using System.Windows.Forms;

namespace BlightnautsDialogue
{
    public partial class FormTeam : Form
    {
        Area[] areas;
        int currentArea, currentDialogue;

        public FormTeam()
        {
            InitializeComponent();
            GenerateAreas();
            currentArea = 0;
            LoadArea();
        }

        private void GenerateAreas()
        {
            areas = new Area[38];
            areas[0] = new Area("Intro_Solo");
            areas[1] = new Area("Intro_Team");
            areas[2] = new Area("Intro2_Team");
            areas[3] = new Area("Intro3_Team");
            areas[4] = new Area("Obelisk_Solo");
            areas[5] = new Area("Obelisk_Team");
            areas[6] = new Area("Obelisk2_Team");
            areas[7] = new Area("Spitblight_Solo");
            areas[8] = new Area("Spitblight_Team");
            areas[9] = new Area("Spitblight2_Team");
            areas[10] = new Area("Key1_Solo");
            areas[11] = new Area("Key1_Team");
            areas[12] = new Area("Turret_Solo");
            areas[13] = new Area("Turret_Team");
            areas[14] = new Area("Turret2_Team");
            areas[15] = new Area("Water_Solo");
            areas[16] = new Area("Water_Team");
            areas[17] = new Area("Treasure_Solo");
            areas[18] = new Area("Treasure_Team");
            areas[19] = new Area("Key2_Solo");
            areas[20] = new Area("Key2_Team");
            areas[21] = new Area("Switches_Solo");
            areas[22] = new Area("Switches_Team");
            areas[23] = new Area("Switches2_Team");
            areas[24] = new Area("Bottom_Solo");
            areas[25] = new Area("Bottom_Team");
            areas[26] = new Area("Bottom2_Team");
            areas[27] = new Area("SawPuzzle_Solo");
            areas[28] = new Area("SawPuzzle_Team");
            areas[29] = new Area("SawPuzzle2_Team");
            areas[30] = new Area("SawTrap_Solo");
            areas[31] = new Area("SawTrap_Team");
            areas[32] = new Area("FinalIntro_Solo");
            areas[33] = new Area("FinalIntro_Team");
            areas[34] = new Area("FinalIntro2_Team");
            areas[35] = new Area("FinalIntro3_Team");
            areas[36] = new Area("FinalShield_Solo");
            areas[37] = new Area("FinalShield_Team");

            areas[32].Dialogues[0].Start = 0;
            areas[32].Dialogues[0].End = 4;
            areas[32].Dialogues.Add(new Area.Dialogue { Start = 7, End = 11 });
            areas[32].Dialogues.Add(new Area.Dialogue { Start = 21, End = 27 });
        }

        private void textBoxPortrait_TextChanged(object sender, EventArgs e)
        {
            areas[currentArea].Dialogues[currentDialogue].Portrait = textBoxPortrait.Text;
        }

        private void textBoxDialogue_TextChanged(object sender, EventArgs e)
        {
            areas[currentArea].Dialogues[currentDialogue].Content = textBoxDialogue.Text;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentArea++;
            if (currentArea > areas.Length - 1)
            {
                currentArea = 0;
            }
            currentDialogue = 0;
            LoadArea();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentArea--;
            if (currentArea < 0)
            {
                currentArea = areas.Length - 1;
            }
            currentDialogue = 0;
            LoadArea();
        }

        private void LoadArea()
        {
            labelArea.Text = areas[currentArea].Name;
            currentDialogue = 0;
            LoadDialogue();
        }

        private void buttonAddDialogue_Click(object sender, EventArgs e)
        {
            areas[currentArea].Dialogues.Add(new Area.Dialogue());
            currentDialogue = areas[currentArea].Dialogues.Count - 1;
            LoadDialogue();
        }

        private void buttonNextDialogue_Click(object sender, EventArgs e)
        {
            currentDialogue++;
            if (currentDialogue > areas[currentArea].Dialogues.Count - 1)
            {
                currentDialogue = 0;
            }
            LoadDialogue();
        }

        private void buttonPreviousDialogue_Click(object sender, EventArgs e)
        {
            currentDialogue--;
            if (currentDialogue < 0)
            {
                currentDialogue = areas[currentArea].Dialogues.Count - 1;
            }
            LoadDialogue();
        }

        private void buttonRemoveDialogue_Click(object sender, EventArgs e)
        {
            if (areas[currentArea].Dialogues.Count <= 1)
            {
                return;
            }

            areas[currentArea].Dialogues.RemoveAt(currentDialogue);
            currentDialogue--;
            if (currentDialogue < 0)
            {
                currentDialogue = 0;
            }
            LoadDialogue();
        }

        private void numericUpDownStart_ValueChanged(object sender, EventArgs e)
        {
            areas[currentArea].Dialogues[currentDialogue].Start = numericUpDownStart.Value;
            LoadDialogue();
        }

        private void numericUpDownEnd_ValueChanged(object sender, EventArgs e)
        {
            areas[currentArea].Dialogues[currentDialogue].End = numericUpDownEnd.Value;
            LoadDialogue();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowser.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int export = Exporter.Export(folderBrowser.SelectedPath, comboBoxCharacter.Text, areas);
                if (export == 0)
                {
                    MessageBox.Show
                        (
                        "Export successful.",
                        "Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                else if (export == 1)
                {
                    MessageBox.Show
                        (
                        "Export failed: Directory does not exist.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else if (export == 2)
                {
                    MessageBox.Show
                        (
                        "Export failed: An exception has occurred.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear all dialogues from all areas?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            foreach (Area area in areas)
            {
                if (area.Name == "FinalIntro_Solo")
                {
                    foreach (Area.Dialogue dialogue in area.Dialogues)
                    {
                        dialogue.Portrait = string.Empty;
                        dialogue.Content = string.Empty;
                    }
                }
                else
                {
                    area.Dialogues.Clear();
                    area.Dialogues.Add(new Area.Dialogue());
                }
            }
            LoadArea();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Blightnauts Dialogue (*.bnd)|*.bnd";
            fileDialog.DefaultExt = "bnd";
            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = true;
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int result = SaveManager.Save(fileDialog.FileName, areas, comboBoxCharacter.Text);
                if (result == 1)
                {
                    MessageBox.Show
                        (
                        "Save failed: An exception has occurred.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Blightnauts Dialogue (*.bnd)|*.bnd";
            fileDialog.DefaultExt = "bnd";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string character;
                int result = SaveManager.Load(fileDialog.FileName, out areas, out character);
                currentArea = 0;
                currentDialogue = 0;
                if (result != 0)
                {
                    GenerateAreas();

                    if (result == 1)
                    {
                        MessageBox.Show
                        (
                        "Load failed: An exception has occurred.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                    else if (result == 2)
                    {
                        MessageBox.Show
                        (
                        "Load failed: File not found.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    }
                }

                comboBoxCharacter.Text = character;
                LoadArea();
            }
        }

        private void LoadDialogue()
        {
            labelCurrentDialogue.Text = string.Format("Dialogue {0}", currentDialogue + 1);
            textBoxPortrait.Text = areas[currentArea].Dialogues[currentDialogue].Portrait;
            textBoxDialogue.Text = areas[currentArea].Dialogues[currentDialogue].Content;

            numericUpDownEnd.Value = areas[currentArea].Dialogues[currentDialogue].End;
            numericUpDownStart.Value = areas[currentArea].Dialogues[currentDialogue].Start;

            labelDuration.Text = string.Format("Dialogue duration: {0}s\nTotal duration: {1}s",
                areas[currentArea].Dialogues[currentDialogue].Duration,
                areas[currentArea].TotalDuration);

            if (areas[currentArea].Name == "FinalIntro_Solo")
            {
                buttonNextDialogue.Enabled = true;
                buttonPreviousDialogue.Enabled = true;
                buttonAddDialogue.Enabled = false;
                buttonRemoveDialogue.Enabled = false;
                numericUpDownStart.Enabled = false;
                numericUpDownEnd.Enabled = false;
            }
            else
            {
                buttonAddDialogue.Enabled = true;
                numericUpDownStart.Enabled = true;
                numericUpDownEnd.Enabled = true;

                if (areas[currentArea].Dialogues.Count > 1)
                {
                    buttonRemoveDialogue.Enabled = true;
                    buttonNextDialogue.Enabled = true;
                    buttonPreviousDialogue.Enabled = true;
                }
                else
                {
                    buttonRemoveDialogue.Enabled = false;
                    buttonNextDialogue.Enabled = false;
                    buttonPreviousDialogue.Enabled = false;
                }
            }
        }
    }
}
