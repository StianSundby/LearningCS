using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningCS
{
    public class WeekOne
    {
        private static readonly Random Random = new();
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine(@"\nThat's it. Press any key to return");
            Console.ReadKey(true);
            GoBack();
        }
        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekOne");
        }
        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine("Task 1:\n"+
                              "Writing to console.\n");

            Console.WriteLine("Hello, what's your name?");
            var linje1 = Console.ReadLine();
            Console.WriteLine("Welcome, " + linje1);

            ReturnToPreviousMenu();
        }

        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine(
                "Task 2:\n"+
                "Input variables and string interpolation."
            );

            const int a = 5;
            const int b = 30;
            const int sum = a + b;

            Console.WriteLine(
                "Without string interpolation it took three lines to write this: \n" +
                "Input variable 'a': " + a + @". \n" +
                "Input bariable 'b': " + b + @". \n" +
                "The sum of these are: " + sum + @".\n"
            );
            Console.WriteLine(
                "With string interpolation it was written in one line: \n" +
                $"Input variable 'a': {a}. Input variable 'b': {b}. The sum of these are: {sum}.\n"
            );

            ReturnToPreviousMenu();
        }

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekOne_Task3_Intro
            );
            ReturnToPreviousMenu();
        }

        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekOne_Task4_Intro
            );

            const int range = 255;
            var total = 0;
            var asciiCode = new int[range];
            var input = "something";
            while (!string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine()?.ToLower();
                foreach (var character in input ?? string.Empty)
                {
                    asciiCode[(int)character]++;
                    total++;
                }
                for (var i = 0; i < range; i++)
                {
                    if (asciiCode[i] <= 0) continue;
                    var character = (char)i;
                    var totalPercentage = 100 * asciiCode[i] / total;
                    var output = $"{character} - {asciiCode[i]}. Or: {totalPercentage}%";
                    Console.CursorLeft = Console.BufferWidth - output.Length - 1;
                    Console.WriteLine(output);
                }
            }

            ReturnToPreviousMenu();

        }

        public static void Task5()
        {
            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekOne_Task5_Intro
            );

            const int numberOne = 10;
            const int numberTwo = 20;
            Console.WriteLine(
                "This is the first method:\n" +
                $"The sum of {numberOne} and {numberTwo} is {MethodOne(numberOne, numberTwo)}\n"
            );
            Console.WriteLine(
                "This is the second method:\n" +
                MethodTwo()
            );

            static int MethodOne(int a, int b)
            {
                var sum = a + b;
                return sum;
            }
            static string MethodTwo()
            {
                const string response = "This method doesn't return anything";
                return response;
            }

            ReturnToPreviousMenu();
        }

        public static void Task6()
        {
            static void HelpText(string clear)
            {
                if (clear == "clear")
                {
                    Console.Clear();
                }
                Console.WriteLine(
                    Properties.Resources.WeekOne_Task6_PasswordRequirements
                );
            }

            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekOne_Task6_Intro
            );
            HelpText(null);

            var userinput = Console.ReadLine();
            if (userinput != null)
            {
                var arguments = userinput.Split(' ');
                PasswordGenerator(arguments);
            }

            static void PasswordGenerator(IReadOnlyList<string> args)
            {
                if (!CheckInput(args))
                {
                    HelpText("clear");
                    Console.WriteLine("\nThere was an error with your input. Please try again...");
                    return;
                }
                var password = "";
                var passwordSettings = args[1];
                var passwordSettingsFilled = passwordSettings.PadRight(Convert.ToInt32(args[0]), 'l');
                while(passwordSettingsFilled.Length != 0)
                {
                    var randomIndex = Random.Next(0, passwordSettingsFilled.Length - 1);
                    var setting = passwordSettingsFilled.ToCharArray()[randomIndex];
                    passwordSettingsFilled = passwordSettingsFilled.Remove(randomIndex, 1);

                    switch (setting)
                    {
                        case 'l':
                            password += ReturnCharacter('l');
                            break;
                        case 'L':
                            password += ReturnCharacter('L');
                            break;
                        case 'd':
                            password += ReturnCharacter('d');
                            break;
                        case 's':
                            password += ReturnCharacter('s');
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Unrecognized character found. Please try again...\n Press any key to continue");
                            Console.ReadKey(true);
                            HelpText("clear");
                            break;
                    }
                }
                Console.WriteLine("\n Password generated:");
                Console.Write(password +
                    "\n\nThat was it." +
                    "\npress any key to go back to the menu...");
                Console.ReadKey(true);
                GoBack();
            }

            static char ReturnCharacter(char character)
            {
                switch (character)
                {
                    case 'l':
                        return (char)Random.Next('a', 'z');
                    case 'L':
                        return (char)Random.Next('A', 'Z');
                    case 'd':
                        //random number between 0 and 9, converted to string
                        //returns the character from index 0 of the string
                        return Random.Next(0, 9).ToString()[0];
                    case 's':
                    {
                        var specialCharacters = "!@£$\"#¤%&/(){;.,:-_'*¨^~´?`}[]";
                        var randomIndex = Random.Next(0, specialCharacters.Length - 1);
                        return specialCharacters[randomIndex];
                    }
                    default:
                        return '\0';
                }
            }

            static bool CheckInput(IReadOnlyList<string> args)
            {
                switch (args.Count)
                {
                    case 0:
                        return false;
                    case 2:
                    {
                        var passwordLength = args[0];
                        var passwordSettings = args[1];
                        var checkOne = CheckLength(passwordLength);
                        var checkTwo = CheckSettings(passwordSettings);
                        if (!checkOne || !checkTwo)
                        {
                            return false;
                        }

                        break;
                    }
                }

                return true;
            }

            static bool CheckLength(string passwordLength)
            {
                return passwordLength.All(char.IsDigit);
            }

            static bool CheckSettings(string passwordSettings)
            {
                return !(from character in passwordSettings let validCharacters = "lLds" 
                    where !validCharacters.Contains(character) select character).Any();
            }
        }
    }
}

