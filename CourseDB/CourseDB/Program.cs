using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuLibrary;
using AuthorizationLibrary;

namespace CourseDB
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            while (true) 
            {
                int choice = 1;
                Console.WriteLine("1 - Консоль меню");
                Console.WriteLine("2 - Консоль авторизации");
                Console.WriteLine("0 - Выход");


                Console.Write("Ввод: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ConsoleInterface.Run();
                }
                else if (choice == 2)
                {
                    Authorization name = new Authorization();
                    AuthorizationInterface.Run(name);
                }
                else if (choice == 0)
                {
                    break;
                }
            }
            
        }
    }
}
