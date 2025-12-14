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
            int choice = 1;
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
        }
    }
}
