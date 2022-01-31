using System;

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
    }
}
