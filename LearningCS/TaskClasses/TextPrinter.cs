//Week 3 - Task 2

using System;

namespace LearningCS.TaskClasses
{
    public class TextPrinter
    {
        public static string Name { get; set; }
        public static int Amount { get; set; }

        public TextPrinter(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
        public void PrintName()
        {
            Console.WriteLine(Name);
            PrintText(Amount);
        }

        private static void PrintText(int amount)
        {
            for (var i = 1; i < amount + 1; i++)
            {
                Console.WriteLine("Round number: " + i);
            }
        }
    }
}