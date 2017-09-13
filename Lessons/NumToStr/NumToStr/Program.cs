using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumToStr
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 123;
            int flag = 0;
            string str = "";
            while(num>0)
            {
                flag = num % 10;
                str += flag;
                num /= 10;
            }
            string strdubl = "";
            for (int i = str.Length - 1; i >= 0  ; i-- )
            {
                strdubl += str[i];
            }
                Console.WriteLine(strdubl);
        }
    }
}
