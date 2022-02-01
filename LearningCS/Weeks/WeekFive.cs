using System;
using System.Linq;
using LearningCS.Resources.TaskClasses.BottleMath;

namespace LearningCS.Weeks
{
    internal class WeekFive
    {
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine(Properties.Resources.ReturnToPreviousMenu);
            Console.ReadKey(true);
            GoBack();
        }

        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekFive");
        }

        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFive_Task1_Intro);
            Console.ReadKey(true);
            ReturnToPreviousMenu();
        }

        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFive_Task2_Intro);
            Console.ReadKey(true);
            Console.WriteLine(Properties.Resources.WeekFive_Task2_Description);

            var input = Console.ReadLine().Split(' ');

            Console.Clear();

            var wantedResult = Convert.ToInt32(input[0]);
            var bottle1 = Convert.ToInt32(input[1]);
            var bottle2 = Convert.ToInt32(input[2]);
            var simulation = new Simulation(wantedResult, bottle1, bottle2);
            var operationSet = simulation.Run();

            Console.WriteLine(operationSet.GetDescription());
            Console.WriteLine("\n\nPress any key to return...");
            Console.ReadKey(true);
            ReturnToPreviousMenu();
        }

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFive_Task3_Intro);
            Console.ReadKey(true);
            ReturnToPreviousMenu();
        }
    }
}
