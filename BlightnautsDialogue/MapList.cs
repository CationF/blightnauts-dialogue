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
    public partial class MapList : Form
    {
        public MapList()
        {
            InitializeComponent();
            textBoxMaps.Text = string.Empty;
            for (int i = 0; i < ProjectManager.Maps.Length; i++)
            {
                if (i == 0)
                {
                    textBoxMaps.Text += ProjectManager.Maps[i];
                }
                else
                {
                    textBoxMaps.Text += ";" + ProjectManager.Maps[i];
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ProjectManager.RegisterMaps(textBoxMaps.Text);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
