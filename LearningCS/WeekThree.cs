using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCS
{
    internal class WeekThree
    {
        private static readonly Random Random = new();

        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nThat's it. Press any key to return...");
            Console.ReadKey(true);
            GoBack();
        }

        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekThree");
        }

        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine("Task 1:\n" +
                              "We were tasked with making a program that reads and handles data from a text file.\n"+
                              "And with this data we were to make a word-riddle generator. All of the riddles are in"+
                              "Norwegian.");

        }
    }
}
