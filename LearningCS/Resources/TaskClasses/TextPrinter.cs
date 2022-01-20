using System;

//Week 3 - Task 2
namespace LearningCS.Resources.TaskClasses
{
    internal class TextPrinter
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public TextPrinter(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public void PrintName()
        {
            Console.WriteLine("Name variable: " + Name);
            PrintName(Amount);
        }

        public void PrintName(int amount)
        {
            for (var i = 1; i < amount + 1; i++)
            {
                Console.WriteLine("Round number: " + i);
            }
        }
    }
}
