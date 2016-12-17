using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char delimiterChars = '\n';
            string text = this.textBox1.Text;
            string[] words = text.Split(delimiterChars);
            float result = 0;
            foreach (string s in words)
            {
                // chang , to .
                string s_tmp = translate_comma(s);

                // chang to float
                float f_tmp = string_to_float(s_tmp);
                
                result += f_tmp;

                //** debug **//
                //label2.Text = s_tmp;
                //MessageBox.Show(s_tmp);
            }

            //** debug **//
            //label2.Text = ""+ result;
            this.textBox2.Text = "" + result;
        }

        private string translate_comma(string str)
        {
            str = str.Replace(",", "");
            //label2.Text = str;
            return str;
            
        }

        private float string_to_float(string str)
        {
            
            //MessageBox.Show(str);
            //Regex NumberPattern = new Regex("[^0-9.-]");
            Regex NumberPattern = new Regex(@"^[a-zA-Z]+$");
            if (NumberPattern.IsMatch(str))
                return 0;
            //if (NumberPattern.IsMatch(str) || String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
                return 0;
            float f_num = float.Parse(str);
            return f_num;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }
    }
}
