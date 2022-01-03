using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCS
{
    public class ChooseWeek
    {
        public static void ChooseWeekLanding()
        {
            bool quitNow = false;
            Console.Clear();
            Console.WriteLine("Weeks");
            Console.WriteLine();
            Console.WriteLine("Please select the week you would like to see assignments from...");
            Console.WriteLine("Enter 'help' for a list of available commands.");
            while (!quitNow)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "help":
                        Console.WriteLine("available commands: ");

                        string[] allCommands = {
                            "'weekone'",
                            "'weektwo'",
                            "'weekthree'",
                            "'weekfour'",
                            "'weekfive'",
                            "'weeksix'",
                            "'weekseven'",
                            "'weekeight'",
                            "'back' to go back to the previous menu",
                            "'quit' to exit"
                            };
                        int i = 1;
                        foreach (string commands in allCommands)
                        {
                            Console.WriteLine(i + "." + commands);
                            i++;
                        }
                        break;

                    case "weekone":
                        WeekChosen(command);
                        break;

                    case "weektwo":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "weekthree":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "quit":
                        quitNow = true;
                        break;

                    case "back":
                        Program.Main();
                        break;

                    default:
                        Console.WriteLine("Unknown Command " + command);
                        break;
                }
            }
        }
        public static void WeekChosen(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                Console.Clear();
                Program.Main();
            }
            else if (param == "weekone")
            {
                Console.Clear();
                WeekOne.ChooseTask();
            }
            else if (param == "weektwo")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weekthree")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weekfour")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weekfive")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weeksix")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weekseven")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
            else if (param == "weekeight")
            {
                Console.Clear();
                Console.WriteLine("Nothing here yet...");
                var input = Console.ReadLine();
                GoBack(input);
            }
        }
        public static void GoBack(string param)
        {
            switch (param)
            {
                case "back":
                    ChooseWeekLanding();
                    break;
                default:
                    Console.WriteLine("Unknown Command " + param);
                    break;
            };
        }
    }
}
