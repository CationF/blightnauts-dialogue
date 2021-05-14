using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlightnautsDialogue
{
    public partial class EditorWindow : Form
    {
        private bool initializing;
        private bool refreshing;
        private int sequence;
        private float zoom;
        private bool unsaved;

        public EditorWindow()
        {
            InitializeComponent();
            initializing = true;

            foreach (var naut in ProjectManager.Characters)
            {
                dropdownCharacters.Items.Add(naut.IndexedName + " (" + naut.RealName + ")");
            }
            dropdownCharacters.SelectedIndex = 0;
            ProjectManager.NewProject();
            zoom = 12;
            SetFontSize(zoom);
            initializing = false;
            RefreshWindow();
        }

        private List<Area.Dialogue> GetDialogues(int index)
        {
            if (dropdownTriggers.Items.Count == 0 || ProjectManager.Areas.Count == 0)
            {
                return null;
            }

            if (index < 0)
            {
                return ProjectManager.Areas[dropdownTriggers.SelectedIndex].
                    CharacterDialogue[dropdownCharacters.SelectedIndex].
                    SoloDialogue;
            }
            else
            {
                return ProjectManager.Areas[dropdownTriggers.SelectedIndex].
                    CharacterDialogue[dropdownCharacters.SelectedIndex].
                    TeamDialogues[index].Dialogues;
            }
        }

        private void SetFontSize(float size)
        {
            textBoxMain.Font = new Font(textBoxMain.Font.FontFamily, size, textBoxMain.Font.Style, textBoxMain.Font.Unit);
        }

        private void RefreshWindow()
        {
            refreshing = true;

            // Character
            checkBoxUseDefault.Checked = ProjectManager.Characters[dropdownCharacters.SelectedIndex].UseDefaultSkin;
            if (ProjectManager.Characters[dropdownCharacters.SelectedIndex].SkinIndex == 1)
                checkBoxUseDefault.Enabled = false;
            else
                checkBoxUseDefault.Enabled = true;

            if (dropdownTriggers.Items.Count == 0)
            {
                dropdownTriggers.Enabled = false;
                buttonSequencePlus.Enabled = false;
                dropdownDialogues.Enabled = false;
            }
            else
            {
                dropdownTriggers.Enabled = true;
                buttonSequencePlus.Enabled = true;
                dropdownDialogues.Enabled = true;
            }

            // Dialogue
            var dialogues = GetDialogues(dropdownDialogues.SelectedIndex - 1);

            if (dialogues == null)
            {
                textBoxPortrait.Text = string.Empty;
                textBoxPortrait.Enabled = false;

                dropdownTexture.Text = string.Empty;
                dropdownTexture.Enabled = false;

                textBoxDuration.Text = string.Empty;
                textBoxDuration.Enabled = false;

                textBoxDelay.Text = string.Empty;
                textBoxDelay.Enabled = false;

                checkBoxGenerateAnimationTemplate.Checked = true;
                checkBoxGenerateAnimationTemplate.Enabled = false;

                textBoxMain.Text = string.Empty;
                textBoxMain.Enabled = false;

                labelSequence.Text = "No dialogue";

                buttonSequencePrevious.Enabled = false;
                buttonSequenceNext.Enabled = false;
                buttonSequenceMinus.Enabled = false;

                textBoxDuration.Text = "0";
                textBoxDelay.Text = "0";
                refreshing = false;
                return;
            }
            else if (dialogues.Count > 0)
            {
                textBoxPortrait.Text = dialogues[sequence].Portrait;
                textBoxPortrait.Enabled = true;

                dropdownTexture.Text = dialogues[sequence].Texture;
                dropdownTexture.Enabled = true;

                // TODO - numeric input validation.
                textBoxDuration.Text = dialogues[sequence].Duration.ToString();
                textBoxDuration.Enabled = true;

                textBoxDelay.Text = dialogues[sequence].Delay.ToString();
                textBoxDelay.Enabled = true;

                checkBoxGenerateAnimationTemplate.Checked = dialogues[sequence].GenerateAnimationTemplate;
                checkBoxGenerateAnimationTemplate.Enabled = true;

                textBoxMain.Text = dialogues[sequence].Content;
                textBoxMain.Enabled = true;

                labelSequence.Text = "Sequence: " + (sequence + 1) + " of " + dialogues.Count;
            }
            else
            {
                textBoxPortrait.Text = string.Empty;
                textBoxPortrait.Enabled = false;

                dropdownTexture.Text = string.Empty;
                dropdownTexture.Enabled = false;

                textBoxDuration.Text = string.Empty;
                textBoxDuration.Enabled = false;

                textBoxDelay.Text = string.Empty;
                textBoxDelay.Enabled = false;

                checkBoxGenerateAnimationTemplate.Checked = true;
                checkBoxGenerateAnimationTemplate.Enabled = false;

                textBoxMain.Text = string.Empty;
                textBoxMain.Enabled = false;

                labelSequence.Text = "No dialogue";
            }

            buttonSequencePrevious.Enabled = sequence > 0 ? true : false;
            buttonSequenceNext.Enabled = sequence < dialogues.Count - 1 ? true : false;
            buttonSequenceMinus.Enabled = dialogues.Count > 0 ? true : false;

            textBoxDuration.Text = ValidateNumericInput(textBoxDuration.Text);
            textBoxDelay.Text = ValidateNumericInput(textBoxDelay.Text);

            if (ProjectManager.Characters[dropdownCharacters.SelectedIndex].UseDefaultSkin && ProjectManager.Characters[dropdownCharacters.SelectedIndex].SkinIndex != 1)
            {
                textBoxPortrait.Enabled = false;
                dropdownTexture.Enabled = false;
                textBoxDuration.Enabled = false;
                textBoxDelay.Enabled = false;
                textBoxMain.Enabled = false;
                checkBoxGenerateAnimationTemplate.Enabled = false;
                buttonSequenceMinus.Enabled = false;
                buttonSequencePlus.Enabled = false;
            }

            refreshing = false;
        }

        private string ValidateNumericInput(string numericText)
        {
            string result = string.Empty;
            foreach (char number in numericText)
            {
                switch (number)
                {
                    case '0':
                        result += number;
                        break;

                    case '1':
                        result += number;
                        break;

                    case '2':
                        result += number;
                        break;

                    case '3':
                        result += number;
                        break;

                    case '4':
                        result += number;
                        break;

                    case '5':
                        result += number;
                        break;

                    case '6':
                        result += number;
                        break;

                    case '7':
                        result += number;
                        break;

                    case '8':
                        result += number;
                        break;

                    case '9':
                        result += number;
                        break;

                    case '.':
                        result += number;
                        break;

                    case ',':
                        result += number;
                        break;
                }
            }

            return result.Replace(',', '.');
        }

        private void topBarNew_Click(object sender, EventArgs e)
        {
            if (unsaved)
            {
                DialogResult result = MessageBox.Show("All unsaved changes will be lost, do you want to save them before creating a new project?", "New Project",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;
                // else if yes, save.
            }
            ProjectManager.NewProject();
            dropdownTriggers.Items.Clear();
            dropdownDialogues.Items.Clear();
            dropdownTexture.Items.Clear();
            sequence = 0;
            initializing = true;
            dropdownCharacters.SelectedIndex = 0;
            initializing = false;
            unsaved = false;
            RefreshWindow();
        }

        private void topBarOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (ProjectManager.LoadProject(openFileDialog.FileName))
                {
                    case 1:
                        MessageBox.Show("An error has occurred while opening the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            dropdownTriggers.Items.Clear();
            dropdownDialogues.Items.Clear();
            dropdownTexture.Items.Clear();
            sequence = 0;
            initializing = true;
            dropdownCharacters.SelectedIndex = 0;
            initializing = false;
            foreach (Area area in ProjectManager.Areas)
            {
                dropdownTriggers.Items.Add(area.Name);
            }
            if (dropdownTriggers.Items.Count > 0)
            {
                refreshing = true;
                dropdownTriggers.SelectedIndex = 0;
                refreshing = false;
            }
            unsaved = false;
            RefreshWindow();
        }

        private void topBarSave_Click(object sender, EventArgs e)
        {
            if (ProjectManager.SaveFileExists)
            {
                switch (ProjectManager.SaveProject(ProjectManager.FilePath))
                {
                    case 1:
                        MessageBox.Show("Specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    case 2:
                        MessageBox.Show("An error has occurred during saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                unsaved = false;
                return;
            }
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (ProjectManager.SaveProject(saveFileDialog.FileName))
                {
                    case 1:
                        MessageBox.Show("Specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    case 2:
                        MessageBox.Show("An error has occurred during saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                unsaved = false;
            }
        }

        private void topBarSaveAs_Click(object sender, EventArgs e)
        {
            if (ProjectManager.SaveFileExists)
            {
                saveFileDialog.InitialDirectory = ProjectManager.FilePath;
            }
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (ProjectManager.SaveProject(saveFileDialog.FileName))
                {
                    case 1:
                        MessageBox.Show("Specified directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    case 2:
                        MessageBox.Show("An error has occurred during saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                unsaved = false;
            }
        }

        private void topBarExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topBarSetDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogModDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                ProjectManager.ModPath = folderBrowserDialogModDirectory.SelectedPath;
                unsaved = true;
            }
        }

        private void topBarNewTrigger_Click(object sender, EventArgs e)
        {
            DialogResult result = new NewTriggerWindow().ShowDialog();
            if (result == DialogResult.OK)
            {
                dropdownTriggers.Items.Clear();
                foreach (var area in ProjectManager.Areas)
                {
                    dropdownTriggers.Items.Add(area.Name);
                }
                dropdownTriggers.SelectedIndex = dropdownTriggers.Items.Count - 1;
                unsaved = true;
                RefreshWindow();
            }
        }

        private void topBarTextboxZoomIn_Click(object sender, EventArgs e)
        {
            if (zoom < 40)
            {
                zoom += 4;
                SetFontSize(zoom);
            }
        }

        private void topBarTextboxZoomOut_Click(object sender, EventArgs e)
        {
            if (zoom > 8)
            {
                zoom -= 4;
                SetFontSize(zoom);
            }
        }

        private void topBarTextboxBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialogTextboxMain.ShowDialog();
            textBoxMain.BackColor = colorDialogTextboxMain.Color;
        }

        private void topBarTextboxForegroundColor_Click(object sender, EventArgs e)
        {
            colorDialogTextboxMain.ShowDialog();
            textBoxMain.ForeColor = colorDialogTextboxMain.Color;
        }

        private void dropdownCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing)
                return;
            sequence = 0;
            RefreshWindow();
        }

        private void checkBoxUseDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            ProjectManager.Characters[dropdownCharacters.SelectedIndex].UseDefaultSkin = checkBoxUseDefault.Checked;
            unsaved = true;
            RefreshWindow();
        }

        private void dropdownTriggers_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropdownDialogues.Items.Clear();
            dropdownDialogues.Items.Add("solo");
            for (int i = 0; i < ProjectManager.Areas[dropdownTriggers.SelectedIndex].TeamDialogues; i++)
            {
                dropdownDialogues.Items.Add("team" + i.ToString());
            }
            dropdownDialogues.SelectedIndex = 0;
            sequence = 0;
            RefreshWindow();
        }

        private void dropdownDialogues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initializing)
                return;
            sequence = 0;
            RefreshWindow();
        }

        private void buttonSequenceNext_Click(object sender, EventArgs e)
        {
            int type = dropdownDialogues.SelectedIndex - 1;
            if (type < 0 && sequence >= ProjectManager.Areas[dropdownTriggers.SelectedIndex].
                CharacterDialogue[dropdownCharacters.SelectedIndex].
                SoloDialogue.Count - 1)
                return;
            else if (type >= 0 && sequence >= ProjectManager.Areas[dropdownTriggers.SelectedIndex].
                CharacterDialogue[dropdownCharacters.SelectedIndex].
                TeamDialogues[type].Dialogues.Count - 1)
                return;

            sequence++;
            RefreshWindow();
        }

        private void buttonSequencePrevious_Click(object sender, EventArgs e)
        {
            if (sequence <= 0)
                return;

            sequence--;
            RefreshWindow();
        }

        private void buttonSequenceMinus_Click(object sender, EventArgs e)
        {
            GetDialogues(dropdownDialogues.SelectedIndex - 1).RemoveAt(sequence);
            sequence--;
            if (sequence < 0)
                sequence = 0;
            unsaved = true;
            RefreshWindow();
        }

        private void buttonSequencePlus_Click(object sender, EventArgs e)
        {
            GetDialogues(dropdownDialogues.SelectedIndex - 1).Add(new Area.Dialogue());
            sequence = GetDialogues(dropdownDialogues.SelectedIndex - 1).Count - 1;
            unsaved = true;
            RefreshWindow();
        }

        private void textBoxPortrait_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Portrait = textBoxPortrait.Text;
        }

        private void dropdownTexture_TextUpdate(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Texture = dropdownTexture.Text;
        }

        private void textBoxDuration_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            try
            {
                GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Duration = float.Parse(ValidateNumericInput(textBoxDuration.Text));
            }
            catch
            {
                textBoxDuration.Text = "0";
            }
        }

        private void textBoxDelay_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            try
            {
                GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Delay = float.Parse(ValidateNumericInput(textBoxDelay.Text));
            }
            catch
            {
                textBoxDelay.Text = "0";
            }
        }

        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Content = textBoxMain.Text;
        }

        private void checkBoxGenerateAnimationTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            unsaved = true;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].GenerateAnimationTemplate = checkBoxGenerateAnimationTemplate.Checked;
        }

        private void topBarAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Blightnauts Dialogue Editor version 0.1\n" +
                "Tool developed by Cláudio Fernandes A.K.A. CationF\n" +
                "No license, do whatever you want with this.\n\n" +
                "Windows Forms and .NET framework are property of Microsoft Corporation",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.None
            );
        }

        private void topBarExport_Click(object sender, EventArgs e)
        {
            if (!ProjectManager.ModPathValid)
            {
                MessageBox.Show("The mod directory is not valid, please check mod directory.\nAlso check maps to see if the names match.",
                "Invalid Mod Directory",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            Exporter.DialogueExporter.Export(ProjectManager.ModPath + "\\AnimationTemplates");
            Exporter.BehaviourExporter.Export(ProjectManager.ModPath + "\\Behaviours");
            foreach (string map in ProjectManager.Maps)
            {
                Exporter.MapExporter.Export(ProjectManager.ModPath + "\\Maps\\" + map + "\\Gameplay.xml");
            }
        }

        private void topBarSetMaps_Click(object sender, EventArgs e)
        {
            DialogResult result = new MapList().ShowDialog();
            if (result == DialogResult.OK)
            {
                unsaved = true;
            }
        }
    }
}
