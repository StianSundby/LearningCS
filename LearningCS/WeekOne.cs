using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCS
{
    public class WeekOne
    {
        public static void ChooseTask()
        {
            Console.Clear();
            Console.WriteLine("Assignments");
            Console.WriteLine();
            Console.WriteLine("Please enter the assignment you would like to view...");
            Console.WriteLine("Type 'help' for a list of available commands.");

            bool quitNow = false;
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
                            "'back' to go back to the previous menu...",
                            "'quit' to exit..."
                            };
                        int i = 1;
                        foreach (string commands in allCommands)
                        {
                            Console.WriteLine(i + "." + commands);
                            i++;
                        }
                        break;

                    case "1":
                        Task1();
                        break;

                    case "2":
                        Task2();
                        break;

                    case "3":
                        Task3();
                        break;

                    case "4":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "5":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "6":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "7":
                        Console.WriteLine("Nothing here yet...");
                        break;

                    case "8":
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
        public static void GoBack(string param)
        {
            switch (param)
            {
                case "back":
                    ChooseTask();
                    break;
                default:
                    Console.WriteLine("Unknown Command " + param);
                    break;
            };
        }
        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine("Assignment 1 - Writing to console.");
            Console.WriteLine(" ");

            Console.WriteLine("Hello, what's your name?");
            var linje1 = Console.ReadLine();
            Console.WriteLine("Welcome, " + linje1);

            Console.WriteLine(" ");
            Console.WriteLine("That's it. Enter 'back' to go back...");
            var input = Console.ReadLine();
            GoBack(input);
        }

        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine("Assignment 2 - String Interpolation.");
            Console.WriteLine("There was also an assignment about debugging arguments, but I can't showcase that here.");
            Console.WriteLine();

            int a = 5;
            int b = 30;
            int sum = a + b;

            Console.WriteLine("Without string interpolation it took three lines to write this: ");
            Console.Write("Input variable 'a': " + a + ". ");
            Console.Write("Input bariable 'b': " + b + ". ");
            Console.Write("The sum of these are: " + sum + ".");
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("With string interpolation it was written in one line: ");
            Console.Write($"Input variable 'a': {a}. Input variable 'b': {b}. The sum of these are: {sum}.");

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("That's it. Enter 'back' to go back...");
            var input = Console.ReadLine();
            GoBack(input);
        }

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine("Assignment 3 - Loops.");
            Console.WriteLine("This assignment was all about understanding the different types of loops, which include: ");
            Console.WriteLine("While, Do-While, Foreach and For");
            Console.WriteLine();
            Console.WriteLine("There isn't anything to show here, the code just printed out a word 10 times.");
            Console.WriteLine("Which was done four diffrent times with four different types of loops.");

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("That's it. Enter 'back' to go back...");
            var input = Console.ReadLine();
            GoBack(input);
        }
        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine("Assignment 4 - Letter counter.");
            Console.WriteLine("Counts the number of each letter entered.");
            Console.WriteLine("Also shows how much of the total percentage each letter used. If that makes any sense...");
            Console.WriteLine(); Console.WriteLine();
            var range = 255;
            var ASCIICode = new int[range];
            string text = "something";
            var totalLength = 0;
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine().ToLower();
                foreach (var character in text ?? string.Empty)
                {
                    if (character == ' ')
                    {
                        continue;
                    }
                    ASCIICode[character]++;
                }
                //de første 32 tegnene i ASCII er "non-printing", så vi starter på 33
                for (var i = 33; i < range; i++)
                {
                    if (ASCIICode[i] >= 33)
                    {
                        totalLength += ASCIICode[i];
                    }
                }
                for (var i = 33; i < range; i++)
                {
                    if (ASCIICode[i] >= 33)
                    {
                        var character = (char)i;
                        var percentage = ASCIICode[i] / totalLength * 100;
                        Console.WriteLine(character + " - " + ASCIICode[i] + ". Which is: " + percentage + "%");
                    }
                }
            }
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("That's it. Enter 'back' to go back...");
            var input = Console.ReadLine();
            GoBack(input);

        }
    }
}