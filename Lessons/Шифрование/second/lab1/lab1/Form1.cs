using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lab1
{
    public partial class Form1 : Form
    {
        private const char FILLER = '☃';

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // генерация ключа

        public static int m = 0;
        public static int n = 0;
        public char[,] array = new char[m, n];
        public void button3_Click(object sender, EventArgs e)
        {
          
            // запись ключа в отдельный файл 
            StreamWriter sw = new StreamWriter(@"F:\lab1\Key.txt");
            Random rnd = new Random();
            m = rnd.Next(5, 15);
            n = rnd.Next(5, 15);
            sw.WriteLine(m);
            sw.WriteLine(n);
            sw.Close();

            MessageBox.Show("Ключ сгенерирован!");
        }

        private void GetDiagPath(TextBox box)
        {
            OpenFileDialog inpFD = new OpenFileDialog();
            if (inpFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { box.Text = inpFD.FileName; }
        }

        public void ChooseFileToEncrypt(object sender, EventArgs e)
        {
            GetDiagPath(inpFileBox);
            string name = Path.GetFileNameWithoutExtension(inpFileBox.Text);
            string ext = Path.GetExtension(inpFileBox.Text);
            outFileBox.Text = Path.GetDirectoryName(inpFileBox.Text) +
                Path.DirectorySeparatorChar + name + "_encrypted" + ext;
        }
                //StreamReader sr =
                //    new StreamReader(inpFD.FileName);
                //string text = sr.ReadToEnd();
                //sr.Close();          

        private int[] GenKeys()
        {
            int[] keys = new int[2];
            Random rnd = new Random();
            //rows
            keys[0] = rnd.Next(5, 15);
            //cols
            keys[1] = rnd.Next(5, 15);
            return keys;
        }

        private void Transpose(char[] matrix, int rows)
        {
            int cols = matrix.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < cols; j++)
                {
                    int ind1 = i * cols + j;
                    int ind2 = j * cols + i;
                    char temp = matrix[ind1];
                    matrix[ind1] = matrix[ind2];
                    matrix[ind2] = temp;
                }
            }
        }

        private void FillMatrix(char[] matrix, int count)
        {
            for (int i = count; i < matrix.Length; i++)
            { matrix[i] = FILLER; }
        }

        public void encrypt(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(inpFileBox.Text))
            using (StreamWriter sw = new StreamWriter(outFileBox.Text))
            {
                int[] keys = GenKeys();
                int rows = keys[0];
                int cols = keys[1];

                int count;
                char[] buf = new char[rows * cols];
                while ((count = sr.Read(buf, 0, rows * cols)) != 0)
                {
                    FillMatrix(buf, count);
                    Transpose(buf, rows);
                    sw.Write(buf, 0, rows * cols);
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }        

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
