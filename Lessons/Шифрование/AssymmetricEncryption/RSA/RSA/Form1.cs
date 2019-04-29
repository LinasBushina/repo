﻿using System;
using System.Numerics;
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
            string dir = Directory.GetCurrentDirectory();
            outOpenKeyBox.Text = dir + Path.DirectorySeparatorChar + outOpenKeyBox.Text;
        }

        private bool GetDiagPath(TextBox box)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                box.Text = fd.FileName;
                return true;
            }
            return false;
        }

        private void selectУтсFileBtn_Click(object sender, EventArgs e)
        {
            if (!GetDiagPath(inpEncFileBox)) return;
            string name = Path.GetFileNameWithoutExtension(inpEncFileBox.Text);
            string ext = Path.GetExtension(inpEncFileBox.Text);
            outDecFileBox.Text = Path.GetDirectoryName(inpEncFileBox.Text) +
                   Path.DirectorySeparatorChar + name + "_decrypted" + ext;
        }

        int d = -1;
        int n = -1;
        private void ecnryptBtn_Click(object sender, EventArgs arg)
        {
            using (StreamWriter sw = new StreamWriter(outOpenKeyBox.Text))
            {
                int p = Helper.GetRandomPrime();
                int q = Helper.GetRandomPrime();
                n = p * q;
                int f = (p - 1) * (q - 1);
                int e = Helper.GetCoprime(f);
                d = Helper.GetMulInverse(e, f);
                sw.WriteLine(e);
                sw.WriteLine(n);
            }
        }

        private void selectOpenKeyBtn_Click(object sender, EventArgs e)
        {
            if (!GetDiagPath(inpOpenKeyBox)) return;
        }

        private void selectRawFileBtn_Click(object sender, EventArgs e)
        {
            if (!GetDiagPath(inpRawFileBox)) return;
            string name = Path.GetFileNameWithoutExtension(inpRawFileBox.Text);
            string ext = Path.GetExtension(inpRawFileBox.Text);
            outEncFileBox.Text = Path.GetDirectoryName(inpRawFileBox.Text) +
                   Path.DirectorySeparatorChar + name + "_encrypted" + ext;
        }

        private void encryptBtn_Click(object sender, EventArgs arg)
        {
            if (inpOpenKeyBox.Text.Length == 0)
            {
                MessageBox.Show("Please input the open key pair!");
                return;
            }
            if (inpRawFileBox.Text.Length == 0)
            {
                MessageBox.Show("Please input the raw file!");
                return;
            }
            using (StreamReader srKey = new StreamReader(inpOpenKeyBox.Text))
            using (StreamReader srRaw = new StreamReader(inpRawFileBox.Text))
            using (StreamWriter sw = new StreamWriter(outEncFileBox.Text))
            {
                int e = int.Parse(srKey.ReadLine());
                int n = int.Parse(srKey.ReadLine());

                BigInteger m;
                while ((m = srRaw.Read()) != -1)
                {
                    string c = BigInteger.ModPow(m, e, n).ToString();
                    sw.WriteLine(c);
                }
            }
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (d == -1)
            {
                MessageBox.Show("Please make open key pair!");
                return;
            }
            if (inpEncFileBox.Text.Length == 0)
            {
                MessageBox.Show("Please input the encrypted file!");
                return;
            }
            using (StreamReader sr = new StreamReader(inpEncFileBox.Text))
            using (StreamWriter sw = new StreamWriter(outDecFileBox.Text))
            {
                while (sr.Peek() >= 0)
                {
                    BigInteger c = BigInteger.Parse(sr.ReadLine());
                    int m = (int)BigInteger.ModPow(c, d, n);
                    sw.Write((char)m);
                }
            }
        }
    }
}
