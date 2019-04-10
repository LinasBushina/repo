using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void take_dictionary()
        {
            using (StreamReader reader = new StreamReader(@".\Словарь.txt", System.Text.Encoding.Default))
            {
                while (!reader.EndOfStream)
                {
                    string buf = reader.ReadLine();
                    char[] splitchar = { ';', '\n', ' ', '.', '\0', '\r', ',' };
                    List<string> foo = new List<string>(buf.Split(splitchar));
                    foreach (string str in foo)
                    {
                        if (str.Length == 0 || str == " ")
                            continue;
                        char w = str[0];
                        if (!MyDictionary.ContainsKey(w))
                        {
                            MyDictionary[w] = new List<string>();
                            MyDictionary[w].Add(str);
                        }
                        else
                            MyDictionary[w].Add(str);
                    }
                }
            }
        }
        private void button_input_Click(object sender, EventArgs e)
        {
            var dialogResult = input_Dialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                return;
            }
            Input.Text = input_Dialog.FileName;
        }
        List<string> list = new List<string>();
        Dictionary<char, List<string>> MyDictionary = new Dictionary<char, List<string>>();
        static Random rnd = new Random();
        
        int[] key_sell_m;
        int[] key_row_m;
        string DecipherBuf = "";
        int vagno;

        public void helper_function(int m, int n, List<string> list)
        {
            //m - строки n - столбцы
            string[] a_s = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < Math.Pow(m, n); i++)
            {
                List<string> list_h = new List<string>();
                string s = "";
                int ii = i;
                bool f = false;
                for (int j1 = 0; j1 < n; j1++)
                {
                        s = a_s[ii % m] + " " + s;
                        if (list_h.Count !=0 && list_h.Contains(a_s[ii % m]))
                        {
                            f = true;
                            break;                           
                        }
                        list_h.Add(a_s[ii % m]);
                        ii /= m;
                }
                if(!f)
                    list.Add(s);
            }
        }
        int count_1 = 2;
        int count_2 = 2;
        static bool fl = false;
        static bool flag = false;
        static int cou = 0;
        Timer timer1 = new Timer();
        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter text_itog = null; 
            StreamWriter key = null;
            
          //  timer1.Interval = (45 * 60 * 1000);//45min
         //   timer1.Interval = 5000;
            
            try
            {
              //  timer1.Start();
             //   timer1.Tick += new EventHandler(timer1_Tick);
                take_dictionary();
           //     key = new StreamWriter(@".\Найденный ключ.txt", true, System.Text.Encoding.Default);
                List<string> DecipherWords = new List<string>();
                int j = 0;
                do
                {
                    List<string> count1 = new List<string>();
                    List<string> count2 = new List<string>();
                    List<int> key_sell = new List<int>();
                    List<int> key_row = new List<int>();
                    helper_function(9, count_1, count1);
                    helper_function(9, count_2, count2);
                    
                    for (int s = 0; s < count1.Count; s++)
                    {
                        if (fl)
                            break;
                        key_row_m = new int[count_1];
                        key_row.Clear();
                        string[] stroka = count1.ElementAt(s).Split(' ');
                        for (int varg = 0; varg < stroka.Length - 1; varg++)
                        {
                            key_row.Add(Convert.ToInt16(stroka[varg]));
                            key_row_m[varg] = Convert.ToInt16(stroka[varg]);
                        }
                        for (int ss = 0; ss < count2.Count; ss++)
                        {
                            key_sell.Clear();
                            key_sell_m = new int[count_2];
                            string[] stroka1 = count2.ElementAt(ss).Split(' ');
                            for (int varg = 0; varg < stroka1.Length - 1; varg++)
                            {
                                key_sell.Add(Convert.ToInt16(stroka1[varg]));
                                key_sell_m[varg] = Convert.ToInt16(stroka1[varg]);
                            }

                            rashifr(key_row, key_sell);
                            j = 0;
                            char[] splitchar = { ';', '\n', ' ', '.', '\0', '\r', ',' };
                            DecipherWords = new List<string>(DecipherBuf.Split(splitchar));
                            while (DecipherWords.Contains(""))
                                DecipherWords.Remove("");
                            foreach (string str in DecipherWords)
                            {
                                if (!MyDictionary.ContainsKey(str[0]))
                                    continue;
                                if (MyDictionary[str[0]].Contains(str))
                                {
                                    j++;
                                }
                            }
                      
                            if (j >= DecipherWords.Count/2)
                            {
                                cou++;
                               MessageBox.Show("Нашла");
                                text_itog = new StreamWriter(@".\Полученный файл.txt", false, System.Text.Encoding.Default);
                                key = new StreamWriter(@".\Найденный ключ.txt", true, System.Text.Encoding.Default);

                                text_itog.Write(DecipherBuf);
                                text_itog.Close();
                                string sss = "пароль № " + Convert.ToString(cou);
                                key.WriteLine(sss);
                                for (int i = 0; i < key_row_m.Length; i++)
                                {
                                    key.Write(Convert.ToString(key_row_m[i]) + " ");
                                }
                                key.WriteLine();
                                for (int i = 0; i < key_sell_m.Length; i++)
                                {
                                    key.Write(Convert.ToString(key_sell_m[i]) + " ");
                                }
                                key.WriteLine();
                                key.Close();
                                fl = true;
                               break;
                            }
                           


                        /*    TimerCallback timeCB = new TimerCallback(PrintTime);
                            System.Threading.Timer time;
                            // создаем таймер
                            if(!flag)
                                time = new System.Threading.Timer(timeCB, null, 60000, 0);*/
                        }
                        
                    }
                    count_2++;
                    if (count_2 == 8)
                    {
                        count_2 = 2;
                        count_1++;
                    }

                }
                while (j < DecipherWords.Count/2);
             }
             catch
             {
                 MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             finally
             {
                  MessageBox.Show("Взлом прошел успешно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }

      /*  static void PrintTime(object state)
        {
            MessageBox.Show("Найдено паролей " + Convert.ToString(cou));
            flag = true;
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sender==timer1)
                MessageBox.Show("Найдено паролей " + Convert.ToString(cou));
            flag = true;
        }

        string itog = "";
        public void rashifr(List<int> key_row, List<int> key_sell)
        {
            StreamReader text = null;           
            string[,] shirt_sells = null;
            string[,] shirt_rows = null;
            string[,] matr = null;
            try
            {
                DecipherBuf = "";
                text = new StreamReader(Input.Text, System.Text.Encoding.Default);
                char[] t = null;
                string s;
                do
                {
                    itog = "";
                    int l = 0;
                    t = new char[key_sell.Count * key_row.Count];
                    text.Read(t, 0, t.Length);
                    s = new String(t);
                    key_row.Sort();
                    key_sell.Sort();
                    matr = new string[key_row.Count + 1, key_sell.Count + 1];
                    for (int j = 1, i = 0; j < key_sell.Count + 1 & i < key_sell.Count; j++, i++)
                    {
                        matr[0, j] = Convert.ToString(key_sell.ElementAt(i));
                    }
                    for (int j = 1, i = 0; j < key_row.Count + 1 & i < key_row.Count; j++, i++)
                    {
                        matr[j, 0] = Convert.ToString(key_row.ElementAt(i));
                    }
                    for (int i = 1; i < key_sell.Count + 1; i++)
                    {
                        for (int j = 1; j < key_row.Count + 1; j++)
                        {
                            matr[j, i] = Convert.ToString(s[l]);
                            l++;
                        }
                    }
                    shirt_rows = new string[key_row.Count + 1, key_sell.Count + 1];
                    int k = 1;
                    for (int j = 0; j < key_row_m.Length; j++)
                    {
                        for (int i = 1; i < key_row.Count + 1; i++)
                        {
                            if (key_row_m[j] == Convert.ToInt16(matr[i, 0]))
                            {
                                for (int r = 0; r < key_sell.Count + 1; r++)
                                {
                                    shirt_rows[k, r] = matr[i, r];
                                }
                            }
                        }
                        k++;
                    }
                    for (int r = 0; r <  key_sell.Count + 1; r++)
                    {
                        shirt_rows[0, r] = matr[0, r];
                    }
                    matr = shirt_rows;
                    shirt_sells = new string[key_row.Count + 1, key_sell.Count + 1];
                    k = 1;
                    for (int j = 0; j < key_sell_m.Length; j++)
                    {
                        for (int i = 1; i < key_sell.Count + 1; i++)
                        {
                            if (key_sell_m[j] == Convert.ToInt16(matr[0, i]))
                            {
                                for (int r = 0; r < key_row.Count + 1; r++)
                                {
                                    shirt_sells[r, k] = matr[r, i];
                                }
                            }
                        }
                        k++;
                    }
                    for (int r = 0; r < key_row.Count + 1; r++)
                    {
                        shirt_sells[r, 0] = matr[r, 0];
                    }

                    for (int i = 1; i < key_row.Count + 1; i++)
                    {
                        for (int j = 1; j < key_sell.Count + 1; j++)
                        {
                            itog += shirt_sells[i, j];
                            DecipherBuf += shirt_sells[i, j];
                        }
                    } 
                }
                while (text.Peek() >= 0);
          
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (text != null) text.Close();
            }
        }


        
        
    }
}
