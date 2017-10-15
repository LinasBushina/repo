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
            Console.WriteLine("Enter the login: ");
            string login = Console.ReadLine();
            Console.WriteLine("Enter the password: ");
            string password = Console.ReadLine();
            string correctlogin = "Fox";
            string correctpassword = "123";
            while(true)
            {
                if(login != correctlogin)
                 { 
                    Console.WriteLine("Login is not correct. Try again");
                 Console.WriteLine("Enter the login: ");
                  login = Console.ReadLine();
                 Console.WriteLine("Enter the password: ");
                 password = Console.ReadLine();
                 }
                if (password != correctpassword)
                { 
                Console.WriteLine("Password is not correct. Try again");
                Console.WriteLine("Enter the login: ");
                login = Console.ReadLine();
                Console.WriteLine("Enter the password: ");
                password = Console.ReadLine();
                }
                Console.WriteLine("All is okey!");
                return;
            }

        }
    }
}
