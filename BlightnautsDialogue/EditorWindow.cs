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
        private string filePath, modPath;

        public EditorWindow()
        {
            InitializeComponent();
            initializing = true;

            foreach (var naut in ProjectManager.Characters)
            {
                dropdownCharacters.Items.Add(naut.IndexedName + " (" + naut.RealName + ")");
            }
            dropdownCharacters.SelectedIndex = 0;
            ProjectManager.LoadProject();
            foreach (var area in ProjectManager.Areas)
            {
                dropdownTriggers.Items.Add(area.Name);
            }
            dropdownTriggers.SelectedIndex = 0;
            zoom = 12;
            SetFontSize(zoom);
            initializing = false;
            RefreshWindow();
        }

        private List<Area.Dialogue> GetDialogues(int index)
        {
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

            // Dialogue
            var dialogues = GetDialogues(dropdownDialogues.SelectedIndex - 1);

            if (dialogues.Count > 0)
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

        }

        private void topBarOpen_Click(object sender, EventArgs e)
        {

        }

        private void topBarSave_Click(object sender, EventArgs e)
        {

        }

        private void topBarSaveAs_Click(object sender, EventArgs e)
        {

        }

        private void topBarExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topBarSetDirectory_Click(object sender, EventArgs e)
        {

        }

        private void topBarNewTrigger_Click(object sender, EventArgs e)
        {
            // For now.
            ProjectManager.Areas.Add(new Area("test", 3));
            dropdownTriggers.Items.Add("test");
            if (dropdownTriggers.Items.Count == 1)
                dropdownTriggers.SelectedIndex = 0;
            RefreshWindow();
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
            RefreshWindow();
        }

        private void buttonSequenceNext_Click(object sender, EventArgs e)
        {
            if (sequence >= ProjectManager.Areas[dropdownTriggers.SelectedIndex].
                CharacterDialogue[dropdownCharacters.SelectedIndex].
                SoloDialogue.Count - 1)
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
            RefreshWindow();
        }

        private void buttonSequencePlus_Click(object sender, EventArgs e)
        {
            GetDialogues(dropdownDialogues.SelectedIndex - 1).Add(new Area.Dialogue());
            sequence = GetDialogues(dropdownDialogues.SelectedIndex - 1).Count - 1;
            RefreshWindow();
        }

        private void textBoxPortrait_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Portrait = textBoxPortrait.Text;
        }

        private void dropdownTexture_TextUpdate(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Texture = dropdownTexture.Text;
        }

        private void textBoxDuration_TextChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
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
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].Content = textBoxMain.Text;
        }

        private void checkBoxGenerateAnimationTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (refreshing)
                return;
            GetDialogues(dropdownDialogues.SelectedIndex - 1)[sequence].GenerateAnimationTemplate = checkBoxGenerateAnimationTemplate.Checked;
        }
    }
}
