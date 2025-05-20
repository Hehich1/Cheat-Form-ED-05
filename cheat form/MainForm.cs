using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cheat_form
{
    public partial class MainForm : Form
    {
        bool[] Value = { false, false, false, false, false };
        
        string path = "";
        string name = "";
        
        
        public void PassValueLabel1(bool Value)
        {
            this.Value[0] = Value;
            System.IO.File.WriteAllText(Path.GetFullPath(path) + "\\Valuebool.txt", string.Join(Environment.NewLine, this.Value));
            if (Value == true)
            {
                label1.Text = "Form 1 completed";
            }
            else if (Value == false)
            {
                label1.Text = "Form 1 incomplete.";
            }
        }
        public bool GetValue1() { return Value[0]; }
        public void PassValueLabel2(bool Value)
        {
            this.Value[1] = Value;
            System.IO.File.WriteAllText(Path.GetFullPath(path) + "\\Valuebool.txt", string.Join(Environment.NewLine, this.Value));
            if (Value == true)
            {
                
                label2.Text = "Form 2 completed";
            }
            else if (Value == false)
            {
                label2.Text = "Form 2 incomplete.";
            }
        }
        public bool GetValue2() { return Value[1]; }
        public void PassValueLabel3(bool Value)
        {
            this.Value[2] = Value;
            System.IO.File.WriteAllText(Path.GetFullPath(path) + "\\Valuebool.txt", string.Join(Environment.NewLine, this.Value));
            if (Value == true)
            {
                
                label3.Text = "Form 3 completed";
            }
            else if (Value == false)
            {
                label3.Text = "Form 3 incomplete.";
            }
        }
        public bool GetValue3() { return Value[2]; }
        public void PassValueLabel4(bool Value)
        {
            this.Value[3] = Value;
            System.IO.File.WriteAllText(Path.GetFullPath(path) + "\\Valuebool.txt", String.Join(Environment.NewLine, this.Value));
            if (Value == true)
            {
                
                label4.Text = "Form 4 completed";
            }
            else if (Value == false)
            {
                label4.Text = "Form 4 incomplete.";
            }
        }
        public bool GetValue4() { return Value[3]; }
        public void PassValueLabel5(bool Value)
        {
            this.Value[4] = Value;
            System.IO.File.WriteAllText(Path.GetFullPath(path) + "\\Valuebool.txt", string.Join(Environment.NewLine, this.Value));
            if (Value == true)
            {
                
                label5.Text = "Form 5 completed";
            }
            else if (Value == false)
            {
                label5.Text = "Form 5 incomplete.";
            }
        }
        public bool GetValue5() { return Value[4]; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name != "")
            {
                using (Form1 f1 = new Form1(this))
                {
                    f1.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Please create a new or load a report.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Value[0] == true)
            {
                using (Form2 f2 = new Form2(this))
                {
                    f2.ShowDialog(this);
                }
            }
            else if (Value[0] == false)
            {
                MessageBox.Show("Please fill out the form 1.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Value[1] == true)
            {
                using (Form4 f4 = new Form4(this))
                {
                    f4.ShowDialog(this);
                }
            }
            else if(Value[1] == false)
            {
                MessageBox.Show("Please fill out the form 2.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Value[2] == true)
            {
                using (Form3 f3 = new Form3(this))
                {
                    f3.ShowDialog(this);
                }
            }
            else if (Value[2] == false)
            {
                MessageBox.Show("Please fill out the form 3.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Value[3] == true)
            {
                using (Form5 f5 = new Form5(this))
                {
                    f5.ShowDialog(this);
                }
            }
            else if(Value[3] == false)
            {
                MessageBox.Show("Please fill out the form 4.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using(AddNewTarget adn = new AddNewTarget(this))
            {
                adn.ShowDialog(this);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (listOfTargets lot = new listOfTargets(this))
            {
                lot.ShowDialog(this);
            }
        }
        
        public void setPathName(string path)
        {
            this.path = path;
        }
        public string getPathName() { return this.path; }
        public void setValue()
        {
            using (var sr = new StreamReader(Path.GetFullPath(path) + "\\Valuebool.txt"))
            {
                for (int i = 0; i < Value.Length; i++)
                    Value[i] = bool.Parse(sr.ReadLine());

            }

            PassValueLabel1(GetValue1());
            PassValueLabel2(GetValue2());
            PassValueLabel3(GetValue3());
            PassValueLabel4(GetValue4());
            PassValueLabel5(GetValue5());
        }
        public void setName(string name)
        {
            this.name = name;
            label6.Text = "Student name: " + name;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (name != "")
            {
                ProcessStartInfo pstartinfo = new ProcessStartInfo();
                pstartinfo.FileName = "python";

                string word = textBox1.Text;

                string output = "";
                pstartinfo.Arguments = $"main.py \"{Path.GetFullPath(path)}\" \"{word}\"";

                pstartinfo.UseShellExecute = false;
                pstartinfo.CreateNoWindow = true;
                pstartinfo.RedirectStandardOutput = true;
                pstartinfo.RedirectStandardError = true;
                using (Process process = Process.Start(pstartinfo))
                {
                    string stdOutput = process.StandardOutput.ReadToEnd();


                    output = stdOutput.Trim();
                }
                label7.Text = "Words found: " + output;
            }
            else
            {
                MessageBox.Show("Please create a new or load a report.");
            }
        }
    }
}
