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
    public partial class Form5 : Form
    {
        MainForm mainForm = null;
        public Form5(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            textBox1.ReadOnly = true;
            if (mainForm.GetValue5() == false)
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
            textBox3.ReadOnly = true;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            dateTimePicker2.Enabled = false;

        }
        public void resetData()
        {
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value5.txt", String.Join(Environment.NewLine, ""));
        }


        // this idea of the way how to save the textfiles data was taken from:
        // https://stackoverflow.com/questions/43913174/saving-textbox-values-for-next-time-i-run-an-application

        public void setData()
        {
            List<string> allvalues = this.Controls.OfType<TextBox>().Select(x => x.Text).ToList();
            if (radioButton3.Checked)
            {
                allvalues.Add(radioButton3.Text);
            }
            else if (radioButton4.Checked)
            {
                allvalues.Add(radioButton4.Text);
            }
            allvalues.Add(dateTimePicker2.Text);
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value5.txt", String.Join(Environment.NewLine, allvalues));
        }
        public void getData()
        {
            string[] alllines = System.IO.File.ReadAllLines(Path.GetFullPath(mainForm.getPathName()) + "\\Value5.txt");

            List<TextBox> allTextboxes = this.Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < allTextboxes.Count; i++)
            {
                allTextboxes[i].Text = alllines[i];
            }
            if (alllines[alllines.Length - 2] == "Yes")
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
            dateTimePicker2.Value = DateTime.Parse(alllines[alllines.Length - 1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked || radioButton4.Checked || textBox3.Text != null)
            {
                this.mainForm.PassValueLabel5(true);
                setData();
                Close();
            }
        }

        

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true;
            }
        }
    }
}
