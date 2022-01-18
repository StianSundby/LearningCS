using System;
using System.Collections.Generic;
using System.Linq;
using LearningCS.Properties;

namespace LearningCS
{
    public class Program : Declarations
    {
        private static string HelpText()
        {
            string[] allCommands = {
                "'View weeks' to go to the next menu.",
                "'help' to view a list of all availble commands.",
                "'Exit' to exit the application."
            };
            var availableCommands = allCommands.Aggregate("", (current, command) => current + ("     " + command + "\n"));
            Console.Clear();
            var stringToReturn = "Available commands: \n" + availableCommands;
            return stringToReturn;
        }
        public static void Main()
        {
            Options = new List<Option>
            {
                new("View weeks", ChooseWeek),
                new("Help", () =>  Console.WriteLine(HelpText())),
                new("Exit", () => Environment.Exit(0)),
            };

            var index = 0;
            WriteMenu(Options, Options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey(true);
                switch (keyinfo.Key)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (index + 1 < Options.Count)
                        {
                            index++;
                            WriteMenu(Options, Options[index]);
                        }

                        break;
                    }
                    case ConsoleKey.UpArrow:
                    {
                        if (index - 1 >= 0)
                        {
                            index--;
                            WriteMenu(Options, Options[index]);
                        }

                        break;
                    }
                    case ConsoleKey.Enter:
                        Options[index].Selected.Invoke();
                        index = 0;
                        break;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey(true);

        }

        private static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            foreach (var option in options)
            {
                Console.Write(option == selectedOption ? @"> " : @" ");
                Console.WriteLine(option.Name);
            }
        }
        public static void ChooseWeek()
        {
            Console.Clear();
            Options = new List<Option>
            {
                new("Week 1", () => ChooseTask("WeekOne")),
                new("Week 2", () => ChooseTask("WeekTwo")),
                new("Week 3", () => ChooseTask("WeekThree")),
                new("Help", () =>  Console.WriteLine(HelpText())),
                new("Exit", () => Environment.Exit(0)),
            };
            const int index = 0;
            WriteMenu(Options, Options[index]);
            Console.WriteLine(Resources.Program_ChooseWeek_);
        }
        public static void ChooseTask(string weekNumber)
        {
            Console.Clear();
            Options = weekNumber switch
            {
                "WeekOne" => new List<Option>
                {
                    new("Task 1", WeekOne.Task1),
                    new("Task 2", WeekOne.Task2),
                    new("Task 3", WeekOne.Task3),
                    new("Task 4", WeekOne.Task4),
                    new("Task 5", WeekOne.Task5),
                    new("Task 6", WeekOne.Task6),
                    new("Help", () => Console.WriteLine(HelpText())),
                    new("Back", ChooseWeek),
                    new("Exit", () => Environment.Exit(0)),
                },
                "WeekTwo" => new List<Option>
                {
                    new("Task 1", WeekTwo.Task1),
                    new("Task 2", WeekTwo.Task2),
                    new("Task 3", WeekTwo.Task3),
                    new("Help", () => Console.WriteLine(HelpText())),
                    new("Back", ChooseWeek),
                    new("Exit", () => Environment.Exit(0)),
                },
                "WeekThree" => new List<Option>
                {
                    new("Task 1", WeekThree.Task1),
                },
                _ => Options
            };
            const int index = 0;
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