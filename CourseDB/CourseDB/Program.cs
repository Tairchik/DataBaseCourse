using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace CourseDB
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Schedule schedule1 = new Schedule(0, 4, 10);
            Schedule schedule2 = new Schedule(8, 9, 22);


            IRout rout = new Rout();
            rout.Schedule.Add(schedule1);
            rout.Schedule.Add(schedule2);
            rout.StartTimeDirectRout = new TimeSpan(8, 24, 0);
            rout.EndTimeDirectRout = new TimeSpan(3, -30, 0);
            rout.StartTimeReversDirectRout = new TimeSpan(1, 30, 0);
            rout.EndTimeReversDirectRout = new TimeSpan(9, 00, 0);

            int count = 1;  

            foreach (var val in rout.GetStartTimesString(true))
            {
                Console.Write(val + ", ");
                if (count == 10) 
                {
                    Console.Write('\n');
                    count = 0;
                }
                count++;
            }

            Console.WriteLine();

            count = 1;

            foreach (var val in rout.GetStartTimesString(false))
            {
                Console.Write(val + ", ");
                if (count == 10)
                {
                    Console.Write('\n');
                    count = 0;
                }
                count++;
            }
        }
    }
}
