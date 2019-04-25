using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool GetDiagPath(TextBox box)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                box.Text = fd.FileName;
                return true;
            }
            return false;
        }

        private void selectRawFileBtn_Click(object sender, EventArgs e)
        {
            if (!GetDiagPath(inpRawFileBox)) return;
            string name = Path.GetFileNameWithoutExtension(inpRawFileBox.Text);
            string ext = Path.GetExtension(inpRawFileBox.Text);
            outEncFileBox.Text = Path.GetDirectoryName(inpRawFileBox.Text) +
                   Path.DirectorySeparatorChar + name + "_encrypted" + ext;
        }

        private void ecnryptBtn_Click(object sender, EventArgs arg)
        {
            if (inpRawFileBox.Text.Length == 0)
            {
                MessageBox.Show("Please input the file!");
                return;
            }
            using (StreamReader sr = new StreamReader(inpRawFileBox.Text))
            using (StreamWriter sw = new StreamWriter(outEncFileBox.Text))
            {
                int ch;
                while ((ch = sr.Read()) != -1)
                {
                    int p = Helper.GetRandomPrime();
                    int q = Helper.GetRandomPrime();
                    int n = p * q;
                    int f = (p - 1) * (q - 1);
                    int e = Helper.GetCoprime(f);
                    int d = Helper.GetMulInverse(e, f);

                    int a = 1;
                }
            }
        }
    }
}
