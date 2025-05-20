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
    public partial class Form4 : Form
    {
        MainForm mainForm = null;
        public Form4(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            if (mainForm.GetValue3() == false)
            {
                resetData();
            }
            else
            {
                getData();
                Blocked();
            }
        }
        public void Blocked()
        {
            textBox3.ReadOnly = true;
            dateTimePicker2.Enabled = false;

        }
        public void resetData()
        {
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value3.txt", String.Join(Environment.NewLine, ""));
        }

        // this idea of the way how to save the textfiles data was taken from:
        // https://stackoverflow.com/questions/43913174/saving-textbox-values-for-next-time-i-run-an-application

        public void setData()
        {
            string[] allvalues = { textBox3.Text , dateTimePicker2.Text };
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value3.txt", String.Join(Environment.NewLine, allvalues));
        }
        public void getData()
        {
            string[] alllines = System.IO.File.ReadAllLines(Path.GetFullPath(mainForm.getPathName()) + "\\Value3.txt");

            textBox3.Text = alllines[0];
      
            dateTimePicker2.Value = DateTime.Parse(alllines[alllines.Length - 1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                this.mainForm.PassValueLabel3(true);
                setData();
                Close();
            }
            else
            {
                MessageBox.Show("Please sign before proceeding");
            }
        }
    }
}
