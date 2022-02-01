using System;

//Week 3 - Task 3
namespace LearningCS.Resources.TaskClasses.Standalone_classes
{
    internal class WelcomeMessage
    {
        public string Message { get; set; }
        public string Name { get; set; }

        public WelcomeMessage(string message)
        {
            Message = message + ", ";
        }

        public void PrintWelcomeMessage(string name)
        {
            Name = name;
            Console.WriteLine(Message + Name);
        }
    }
}
