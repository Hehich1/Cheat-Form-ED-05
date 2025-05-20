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
    public partial class Form2 : Form
    {
        MainForm mainForm = null;
        public Form2(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            if(mainForm.GetValue2() == false) 
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
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            YesButton.Enabled = false;
            NoButton.Enabled = false;
            dateTimePicker1.Enabled = false;

        }
        public void resetData()
        {
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value2.txt", String.Join(Environment.NewLine, ""));
        }

        // this idea of the way how to save the textfiles data was taken from:
        // https://stackoverflow.com/questions/43913174/saving-textbox-values-for-next-time-i-run-an-application

        public void setData()
        {
            List<string> allvalues = this.Controls.OfType<TextBox>().Select(x => x.Text).ToList();
            if(YesButton.Checked)
            {
                allvalues.Add(YesButton.Text);
            }
            else if(NoButton.Checked)
            {
                allvalues.Add(NoButton.Text);
            }
            allvalues.Add(dateTimePicker1.Text);
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value2.txt", String.Join(Environment.NewLine, allvalues));
        }
        public void getData() 
        {
            string[] alllines = System.IO.File.ReadAllLines(Path.GetFullPath(mainForm.getPathName()) + "\\Value2.txt");

            List<TextBox> allTextboxes = this.Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < allTextboxes.Count; i++)
            {
                allTextboxes[i].Text = alllines[i];
            }
            if (alllines[alllines.Length-2] == "Yes") 
            {
                YesButton.Checked = true;
            }
            else
            {
                NoButton.Checked = true;
            }
            dateTimePicker1.Value = DateTime.Parse(alllines[alllines.Length-1]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((NoButton.Checked == true || YesButton.Checked == true) && textBox1.Text != "" && textBox2.Text != "")
            {
                this.mainForm.PassValueLabel2(true);
                setData();
                Close();
            }
            else
            {
                MessageBox.Show("Please answer the question and mark all checkboxes.");
            }
        }
    }
}
