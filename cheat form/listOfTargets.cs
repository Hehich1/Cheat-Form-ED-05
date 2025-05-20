using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cheat_form
{
    public partial class listOfTargets : Form
    {
        MainForm mainForm;
        public listOfTargets(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // line under was taken from: https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
            string[] filePaths = Directory.GetDirectories("Targets");

            foreach (string filePath in filePaths)
            {
                comboBox1.Items.Add(filePath.Substring(filePath.IndexOf("\\")+1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a student from the list");
            }
            else
            {
                mainForm.setPathName("Targets\\" + comboBox1.GetItemText(this.comboBox1.SelectedItem));
                mainForm.setValue();
                mainForm.setName(comboBox1.GetItemText(this.comboBox1.SelectedItem));
                Close();
            }
        }
    }
}
