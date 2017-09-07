using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CountUpperLettersInFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"sample.txt";
            int count = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    char ch = (char)sr.Read();
                    if (Char.IsUpper(ch)) count++;
                }
            }
            
            Console.WriteLine(count);
        }
    }
}
