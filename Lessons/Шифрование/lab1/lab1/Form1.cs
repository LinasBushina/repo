﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
            string line;
            string path = textBox1.Text;
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            while ((line = file.ReadLine()) != null)
            {
                MessageBox.Show(line);
            }
            
            file.Close();  
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        OpenFileDialog input_file1 = new OpenFileDialog();
        private void button4_Click(object sender, EventArgs e)
        {
            if (input_file1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(input_file1.FileName);
                textBox2.Text = input_file1.FileName;
                string text = sr.ReadToEnd();
                MessageBox.Show(text);
                sr.Close();
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
