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
    public partial class NewTriggerWindow : Form
    {
        public NewTriggerWindow()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ProjectManager.Areas.Add(new Area(textBoxTriggerName.Text, Convert.ToInt32(numericUpDownTeamDialogues.Value)));
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
