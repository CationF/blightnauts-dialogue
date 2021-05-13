using System;
using System.Windows.Forms;

namespace BlightnautsDialogue
{
    public partial class NewTriggerWindow : Form
    {
        public NewTriggerWindow()
        {
            InitializeComponent();
        }

        public static string ValidateAreaName(string name)
        {
            string result = string.Empty;
            foreach (char letter in name)
            {
                switch (letter.ToString().ToUpper())
                {
                    case "A":
                        result += letter;
                        break;

                    case "B":
                        result += letter;
                        break;

                    case "C":
                        result += letter;
                        break;

                    case "D":
                        result += letter;
                        break;

                    case "E":
                        result += letter;
                        break;

                    case "F":
                        result += letter;
                        break;

                    case "G":
                        result += letter;
                        break;

                    case "H":
                        result += letter;
                        break;

                    case "I":
                        result += letter;
                        break;

                    case "J":
                        result += letter;
                        break;

                    case "K":
                        result += letter;
                        break;

                    case "L":
                        result += letter;
                        break;

                    case "M":
                        result += letter;
                        break;

                    case "N":
                        result += letter;
                        break;

                    case "O":
                        result += letter;
                        break;

                    case "P":
                        result += letter;
                        break;

                    case "Q":
                        result += letter;
                        break;

                    case "R":
                        result += letter;
                        break;

                    case "S":
                        result += letter;
                        break;

                    case "T":
                        result += letter;
                        break;

                    case "U":
                        result += letter;
                        break;

                    case "V":
                        result += letter;
                        break;

                    case "W":
                        result += letter;
                        break;

                    case "X":
                        result += letter;
                        break;

                    case "Y":
                        result += letter;
                        break;

                    case "Z":
                        result += letter;
                        break;

                    case "0":
                        result += letter;
                        break;

                    case "1":
                        result += letter;
                        break;

                    case "2":
                        result += letter;
                        break;

                    case "3":
                        result += letter;
                        break;

                    case "4":
                        result += letter;
                        break;

                    case "5":
                        result += letter;
                        break;

                    case "6":
                        result += letter;
                        break;

                    case "7":
                        result += letter;
                        break;

                    case "8":
                        result += letter;
                        break;

                    case "9":
                        result += letter;
                        break;
                }
            }
            return result;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string validatedName = ValidateAreaName(textBoxTriggerName.Text);
            if (validatedName == string.Empty)
            {
                MessageBox.Show("Trigger needs a name.", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProjectManager.Areas.Add(new Area(validatedName, Convert.ToInt32(numericUpDownTeamDialogues.Value)));
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
