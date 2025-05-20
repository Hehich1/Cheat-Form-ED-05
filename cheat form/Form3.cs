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
    public partial class Form3 : Form
    {
        MainForm mainForm = null;
        public Form3(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            textBox1.ReadOnly = true;
            if (mainForm.GetValue4() == false)
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
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            dateTimePicker1.Enabled = false;

        }
        public void resetData()
        {
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value4.txt", String.Join(Environment.NewLine, ""));
        }

        // this idea of the way how to save the textfiles data was taken from:
        // https://stackoverflow.com/questions/43913174/saving-textbox-values-for-next-time-i-run-an-application

        public void setData()
        {
            List<string> allvalues = this.Controls.OfType<System.Windows.Forms.TextBox>().Select(x => x.Text).ToList();
            if (radioButton1.Checked)
            {
                allvalues.Add(radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                allvalues.Add(radioButton2.Text);
            }
            allvalues.Add(dateTimePicker1.Text);
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value4.txt", String.Join(Environment.NewLine, allvalues));
        }
        public void getData()
        {
            string[] alllines = System.IO.File.ReadAllLines(Path.GetFullPath(mainForm.getPathName()) + "\\Value4.txt");

            List<System.Windows.Forms.TextBox> allTextboxes = this.Controls.OfType<System.Windows.Forms.TextBox>().ToList();
            for (int i = 0; i < allTextboxes.Count; i++)
            {
                allTextboxes[i].Text = alllines[i];
            }
            if (alllines[alllines.Length - 2] == "Yes")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            dateTimePicker1.Value = DateTime.Parse(alllines[alllines.Length - 1]);
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked || radioButton2.Checked) && textBox3.Text != "")
            {
                this.mainForm.PassValueLabel4(true);
                setData();
                Close();
            }
            else
            {
                MessageBox.Show("Please answer the question and try again.");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
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
