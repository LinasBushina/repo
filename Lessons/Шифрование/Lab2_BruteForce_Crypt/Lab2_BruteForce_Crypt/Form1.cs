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
using System.Diagnostics;

namespace Lab2_BruteForce_Crypt
{
    public partial class Form1 : Form
    {
        private const char FILLER = '☃';
        private HashSet<string> dict;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetDiagPath(TextBox box)
        {
            OpenFileDialog inpFD = new OpenFileDialog();
            if (inpFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { box.Text = inpFD.FileName; }
        }

        private void selectFileDecButton_Click(object sender, EventArgs e)
        { GetDiagPath(encInpFileBox); }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int size = 2; size < 16384; size++)
            {
                for (int rows = 1; rows < size - 1; rows++)
                {
                    int cols = size - rows;
                    using (StreamReader srf = new StreamReader(encInpFileBox.Text))
                    {
                        StringBuilder sb = new StringBuilder();
                        char[] buf = new char[rows * cols];
                        while (srf.Read(buf, 0, rows * cols) != 0)
                        {
                            for (int i = 0; i < rows; i++)
                            {
                                for (int j = 0; j < cols; j++)
                                {
                                    int index = j * rows + i;
                                    char letter = buf[index];
                                    if (letter != FILLER)
                                    { sb.Append(letter); }
                                }
                            }
                        }
                        string decstr = sb.ToString();
                        HashSet<string> decdict = new HashSet<string>(decstr.Split(new char[] { ' ' }));
                        bool isCorrect = true;
                        foreach (var word in dict)
                        {
                            if (!decdict.Contains(word))
                            { isCorrect = false; break; }
                        }
                        if (isCorrect)
                        {
                            sw.Stop();
                            MessageBox.Show(Path.GetFileNameWithoutExtension(encInpFileBox.Text) +
                                " deccrypted\n" + "keys = " + rows + " " + cols +
                                "\nelapsed time = " + sw.ElapsedMilliseconds);
                            return;
                        }
                    }
                }
            }
        }

        private void dictBtn_Click(object sender, EventArgs e)
        {
            GetDiagPath(dictBox);
            string path = dictBox.Text;
            string srcstr = File.ReadAllText(path);
            dict = new HashSet<string>(srcstr.Split(new char[] { ' ' }));
        }
    }
}
