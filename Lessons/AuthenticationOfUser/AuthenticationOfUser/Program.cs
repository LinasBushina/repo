using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationOfUser
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "";
            string password = "";
            string correctlogin = "Fox";
            string correctpassword = "123";
            do
            { 
                Console.WriteLine("Enter the login: ");
                login = Console.ReadLine();
                Console.WriteLine("Enter the password: ");
                password = Console.ReadLine();
                if (login != correctlogin || password != correctpassword)
                { Console.WriteLine("Data is not correct. Try again"); }
            } while (login != correctlogin || password != correctpassword);
            Console.WriteLine("All is okey!");
        }
    }
}
