using System;
using System.Collections.Generic;

namespace LearningCS
{
    public class Program : Declarations
    {
        static string HelpText()
        {
            string[] allCommands = {
                "'View weeks' to go to the next menu.",
                "'help' to view a list of all availble commands.",
                "'Exit' to exit the application."
            };
            string availableCommands = "";
            foreach (string command in allCommands)
            {
                availableCommands += "     " + command + "\n";
            }
            Console.Clear();
            string stringToReturn = "Available commands: \n" + availableCommands;
            return stringToReturn;
        }
        public static void Main()
        {
            Options = new List<Option>
            {
                new Option("View weeks", () => ChooseWeek()),
                new Option("Help", () =>  Console.WriteLine(HelpText())),
                new Option("Exit", () => Environment.Exit(0)),
            };

            int index = 0;
            WriteMenu(Options, Options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < Options.Count)
                    {
                        index++;
                        WriteMenu(Options, Options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(Options, Options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    Options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey(true);

        }
        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
        public static void ChooseWeek()
        {
            Console.Clear();
            Options = new List<Option>
            {
                new Option("Week 1", () => ChooseTask("WeekOne")),
                new Option("Week 2", () => ChooseTask("WeekTwo")),
                new Option("Help", () =>  Console.WriteLine(HelpText())),
                new Option("Exit", () => Environment.Exit(0)),
            };
            int index = 0;
            WriteMenu(Options, Options[index]);
            Console.WriteLine("\nThe weeks will be added when needed.");
        }
        public static void ChooseTask(string weekNumber)
        {
            Console.Clear();
            switch (weekNumber)
            {
                case "WeekOne":
                    Options = new List<Option>
                        {
                            new Option("Task 1", () => WeekOne.Task1()),
                            new Option("Task 2", () => WeekOne.Task2()),
                            new Option("Task 3", () => WeekOne.Task3()),
                            new Option("Task 4", () => WeekOne.Task4()),
                            new Option("Task 5", () => WeekOne.Task5()),
                            new Option("Task 6", () => WeekOne.Task6()),
                            new Option("Help", () =>  Console.WriteLine(HelpText())),
                            new Option("Back", () => ChooseWeek()),
                            new Option("Exit", () => Environment.Exit(0)),
                        };
                    break;
                case "WeekTwo":
                    Options = new List<Option>
                        {
                            new Option("Task 1", () => WeekTwo.Task1()),
                            new Option("Help", () =>  Console.WriteLine(HelpText())),
                            new Option("Back", () => ChooseWeek()),
                            new Option("Exit", () => Environment.Exit(0)),
                        };
                    break;
            }
            int index = 0;
            WriteMenu(Options, Options[index]);
        }
    }

    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }
}