using System;

namespace LearningCS
{
    internal class Program
    {
        public static void Main()
        {
            string command;
            string[] allCommands = {
                "'quit' to exit",
                "'weeks' to view all the weeks. From there you can view assignments..."};
            bool quitNow = false;
            Console.WriteLine("Welcome!");
            Console.WriteLine("Type 'help' for a list of available commands");
            while (!quitNow)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        Console.Clear();
                        Console.WriteLine("available commands: ");
                        int i = 1;
                        foreach (string commands in allCommands)
                        {
                            Console.WriteLine(i + ". " + commands);
                            i++;
                        }
                        break;

                    case "quit":
                        quitNow = true;
                        break;

                    case "weeks":
                        ChooseWeek.ChooseWeekLanding();
                        break;

                    default:
                        Console.WriteLine("Unknown Command " + command);
                        break;
                }
            }
        }
    }
}