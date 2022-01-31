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
            Program.ChooseTask("WeekFour");
        }

        public static void Task1()
        {
            Console.Clear();
        }
    }
}
