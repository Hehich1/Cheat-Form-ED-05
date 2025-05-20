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
    public partial class Form1 : Form
    {
        
        MainForm mainForm = null;

        public Form1(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            if (mainForm.GetValue1() == false)
            {
                resetData();
            }
            else
            {
                getData();
            }
            BlockView(mainForm.GetValue1());
            
        }
        private void BlockView(bool block)
        {
            if (block)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox10.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox9.ReadOnly = true;
                checkBox1.AutoCheck = false; 
                checkBox2.AutoCheck = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBox1.Enabled = false;
            }
        }
        public void resetData()
        {
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value1.txt", String.Join(Environment.NewLine, "")); 
        }


        // this idea of the way how to save the textfiles data was taken from:
        // https://stackoverflow.com/questions/43913174/saving-textbox-values-for-next-time-i-run-an-application

        public void setData() 
        {
            // first collect all values
            List<string> allvalues = this.Controls.OfType<TextBox>().Select(x => x.Text).ToList(); 
            int a = comboBox1.SelectedIndex;
            allvalues.Add(a.ToString());
            allvalues.Add(dateTimePicker1.Text);
            allvalues.Add(dateTimePicker2.Text);
            // write to file
            System.IO.File.WriteAllText(Path.GetFullPath(mainForm.getPathName()) + "\\Value1.txt", String.Join(Environment.NewLine, allvalues));
            
        }
        public void getData() 
        {
            //load the values:
            string[] alllines = System.IO.File.ReadAllLines(Path.GetFullPath(mainForm.getPathName()) + "\\Value1.txt");

            List<TextBox> allTextboxes = this.Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < allTextboxes.Count; i++)
            {
                allTextboxes[i].Text = alllines[i];
            }
            if (alllines.Length > 0)
            {
                comboBox1.SelectedIndex = Convert.ToInt32(alllines[alllines.Length - 3]);
                dateTimePicker1.Value = DateTime.Parse(alllines[alllines.Length - 2]);
                dateTimePicker2.Value = DateTime.Parse(alllines[alllines.Length - 1]);
            }
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true && textBox10.Text != "") 
            {
                this.mainForm.PassValueLabel1(true);
                setData();
                Close();
            }
            else
            {
                MessageBox.Show("Check the boxes before proceeding.");
            }
        }

        
    }
}
