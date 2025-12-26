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
            Authorization authorization = new Authorization();
            Dictionary<int, MenuState> baseDict = new Dictionary<int, MenuState>();

            Dictionary<int, MenuState> dictB = new Dictionary<int, MenuState>();
            Dictionary<int, MenuState> dictMen = new Dictionary<int, MenuState>();
            Dictionary<int, MenuState> dictD = new Dictionary<int, MenuState>();
            Dictionary<int, MenuState> dictI = new Dictionary<int, MenuState>();


            MenuState menuState = new MenuState()
            {
                W = 1,
                E = 1,
                D = 1,
                R = 1
            };

            baseDict[2] = menuState;
            baseDict[3] = menuState;
            baseDict[4] = menuState;
            baseDict[5] = menuState;
            baseDict[6] = menuState;
            baseDict[7] = menuState;
            baseDict[29] = menuState;
            foreach (var item in baseDict)
            {
                dictB[item.Key] = item.Value;
                dictMen[item.Key] = item.Value;
                dictD[item.Key] = item.Value;
                dictI[item.Key] = item.Value;

            }

            dictB[9] = menuState;
            dictB[13] = menuState;
            dictB[16] = menuState;
            dictB[17] = menuState;
            dictB[18] = menuState;
            dictB[19] = menuState;
            dictB[20] = menuState;
            dictB[25] = new MenuState() {W = 0, R = 1, E = 0, D = 0 };
            dictB[26] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictB[27] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };


            dictMen[14] = menuState;
            dictMen[20] = menuState;
            dictMen[27] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictMen[31] = menuState;


            dictD[8] = menuState;
            dictD[9] = menuState;
            dictD[10] = menuState;
            dictD[11] = menuState;
            dictD[12] = menuState;
            dictD[15] = new MenuState() { W = 0, R = 0, E = 0, D = 0 }; 
            dictD[16] = new MenuState() { W = 0, R = 0, E = 0, D = 0 };
            dictD[17] = new MenuState() { W = 0, R = 0, E = 0, D = 0 };
            dictD[18] = new MenuState() { W = 0, R = 0, E = 0, D = 0 };
            dictD[19] = new MenuState() { W = 0, R = 0, E = 0, D = 0 };
            dictD[20] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[21] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[22] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[24] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[25] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[26] = menuState;
            dictD[27] = new MenuState() { W = 0, R = 1, E = 0, D = 0 };
            dictD[28] = menuState;

            dictI[20] = menuState;
            dictI[21] = menuState;
            dictI[22] = menuState;
            dictI[24] = menuState;
            dictI[25] = menuState;


            authorization.EditUserRights("Диспетчер", dictD);
            authorization.EditUserRights("Инженер", dictI);
            //authorization.EditUserRights("Бухгалтер", dictB);
            //authorization.EditUserRights("Менеджер", dictMen);


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
