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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        OpenFileDialog input_file = new OpenFileDialog();
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


        public void button1_Click(object sender, EventArgs e)
        {
            if (input_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(input_file.FileName);
                textBox1.Text = input_file.FileName;
                string text = sr.ReadToEnd();
                MessageBox.Show(text);
                sr.Close();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
            string path = textBox1.Text;
            char[] m1 = new char[n];
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            do
            {
                file.Read(m1, 0, n);  
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = m1[j];
                    }
                }
            }
            while (file.ReadLine() != null);
            file.Close();
         
          

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

       
        OpenFileDialog input_file1 = new OpenFileDialog();
        public void button4_Click(object sender, EventArgs e)
        {
            if (input_file1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr1 = new System.IO.StreamReader(input_file1.FileName);
                textBox2.Text = input_file1.FileName;
                string text = sr1.ReadToEnd();
                MessageBox.Show(text);
                sr1.Close();
            }  
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

        
        
    }
}
