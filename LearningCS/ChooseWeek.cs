using System;

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
                            "'1'",
                            "'2'",
                            "'3'",
                            "'4'",
                            "'5'",
                            "'6'",
                            "'7'",
                            "'8'",
                            "'back' to go back to the previous menu",
                            "'quit' to exit"
                            };
                        int i = 1;
                        foreach (string commands in allCommands)
                        {
                            Console.WriteLine(i + ". " + commands);
                            i++;
                        }
                        break;

                    case "1":
                        Console.Clear();
                        WeekOne.ChooseTask();
                        break;

                    case "2":
                        GoBack(NothingHere());
                        break;

                    case "3":
                        GoBack(NothingHere());
                        break;

                    case "4":
                        GoBack(NothingHere());
                        break;

                    case "5":
                        GoBack(NothingHere());
                        break;

                    case "6":
                        GoBack(NothingHere());
                        break;

                    case "7":
                        GoBack(NothingHere());
                        break;

                    case "8":
                        GoBack(NothingHere());
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

        private static string NothingHere()
        {
            Console.Clear();
            Console.WriteLine("Nothing here yet...");
            var input = Console.ReadLine();
            return input;
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
