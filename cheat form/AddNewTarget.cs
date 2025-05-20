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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace cheat_form
{
    public partial class AddNewTarget : Form
    {
        MainForm mainform = null;   
        public AddNewTarget(MainForm mainForm)
        {
            InitializeComponent();
            this.mainform = mainForm;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            // line under was taken from: https://stackoverflow.com/questions/929276/how-to-recursively-list-all-the-files-in-a-directory-in-c
            string[] filePaths = Directory.GetDirectories("Targets");

            string name = textBox1.Text;
            foreach (string filePath in filePaths)
            {
                if (filePath.Substring(filePath.IndexOf("\\") + 1) == name) {
                    name = name + "_form";
                }
            }
            String fullpath = Path.GetFullPath("Targets")+"\\"+name;
            
            bool[] Value = { false, false, false, false, false };
            System.IO.Directory.CreateDirectory(fullpath);
            File.WriteAllText(Path.Combine(fullpath, "Value1.txt"), "");
            File.WriteAllText(Path.Combine(fullpath, "Value2.txt"), "");
            File.WriteAllText(Path.Combine(fullpath, "Value3.txt"), "");
            File.WriteAllText(Path.Combine(fullpath, "Value4.txt"), "");
            File.WriteAllText(Path.Combine(fullpath, "Value5.txt"), "");
            File.WriteAllText(Path.Combine(fullpath, "Valuebool.txt"), String.Join(Environment.NewLine, Value));
            mainform.setPathName(fullpath);
            mainform.setValue();
            mainform.setName(textBox1.Text);
            Close();
        }
    }
}
