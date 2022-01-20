using System;

//Week 3 - Task 3
namespace LearningCS.TaskClasses
{
    internal class WelcomeMessage
    {
        public static string Name { get; set; }
        public static string Message { get; set; }

        public WelcomeMessage(string message)
        {
            Message = message;
        }

        public void PrintWelcomeMessage(string name)
        {
            Name = ", " + name;
            Console.WriteLine(Message + Name);
        }
    }
}
