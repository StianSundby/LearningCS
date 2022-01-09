using System;

namespace LearningCS
{
    public class WeekOne
    {
        static readonly Random random = new();
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nThat's it. Press any key to return");
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
            Console.WriteLine("Assignment 1 - Writing to console.\n");

            Console.WriteLine("Hello, what's your name?");
            var linje1 = Console.ReadLine();
            Console.WriteLine("Welcome, " + linje1);

            ReturnToPreviousMenu();
        }

        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine(
                "Assignment 2 - String Interpolation.\n" +
                "There was also an assignment about debugging arguments, but I can't showcase that here.\n"
            );

            int a = 5;
            int b = 30;
            int sum = a + b;

            Console.WriteLine(
                "Without string interpolation it took three lines to write this: \n" +
                "Input variable 'a': " + a + ". \n" +
                "Input bariable 'b': " + b + ". \n" +
                "The sum of these are: " + sum + ".\n"
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
                "Assignment 3 - Loops.\n" +
                "This assignment was all about understanding the different types of loops, which include: \n" +
                "While, Do-While, Foreach and For\n"
            );
            Console.WriteLine(
                "There isn't anything to show here, the code just printed out a word 10 times.\n" +
                "Which was done four diffrent times with four different types of loops.\n"
            );
            ReturnToPreviousMenu();
        }

        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine(
                "Assignment 4 - Letter counter.\n" +
                "Counts the number of each letter entered.\n" +
                "It left-aligns the text.\n" +
                "Also shows how much of the total percentage each letter used. If that makes any sense...\n"
            );

            int range = 255;
            int total = 0;
            var ASCIICode = new int[range];
            string input = "something";
            while (!string.IsNullOrWhiteSpace(input))
            {
                input = Console.ReadLine().ToLower();
                foreach (char character in input ?? string.Empty)
                {
                    ASCIICode[(int)character]++;
                    total++;
                }
                for (int i = 0; i < range; i++)
                {
                    if (ASCIICode[i] > 0)
                    {
                        char character = (char)i;
                        int totalPercentage = 100 * ASCIICode[i] / total;
                        string output = $"{character} - {ASCIICode[i]}. Or: {totalPercentage}%";
                        Console.CursorLeft = Console.BufferWidth - output.Length - 1;
                        Console.WriteLine(output);
                    }
                }
            }

            ReturnToPreviousMenu();

        }

        public static void Task5()
        {
            Console.Clear();
            Console.WriteLine(
                "Assignment 5 - Return value.\n" +
                "This assignment consists of two tasks, where I had to write two methods.\n" +
                "The first method should return the sum of two numbers.\n" +
                "The second method should write out that it doesnt return anything to the console.\n"
            );

            int numberOne = 10;
            int numberTwo = 20;
            Console.WriteLine(
                "This is the first method:\n" +
                $"The sum of {numberOne} and {numberTwo} is {methodOne(numberOne, numberTwo)}\n"
            );
            Console.WriteLine(
                "This is the second method:\n" +
                methodTwo()
            );

            static int methodOne(int a, int b)
            {
                int sum = a + b;
                return sum;
            }
            static string methodTwo()
            {
                string response = "This method doesn't return anything";
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
                    "PasswordGenerator \n" +
                    "  Options:\n" +
                    "  - l = lower case letter\n" +
                    "  - L = upper case letter\n" +
                    "  - d = digit\n" +
                    "  - s = special character (!#¤%&/(){}[]\n\n" +
                    "Example: 14 lLssdd\n" +
                    "  - Min. 1 lower case\n" +
                    "  - Min. 1 upper case\n" +
                    "  - Min. 2 special characters\n" +
                    "  - Min. 2 digits\n" +
                    "\nEnter your password parameters. If you can't think of any, just enter the ones in the example..."
                );
            }

            Console.Clear();
            Console.WriteLine(
                "Assignment 6 - Password generator.\n" +
                "This assignment was about making random password generator based on userinput.\n\n\n"
            );
            HelpText(null);

            string userinput = Console.ReadLine();
            string[] arguments = userinput.Split(' ');
            PasswordGenerator(arguments);

            static void PasswordGenerator(string[] args)
            {
                if (!checkInput(args))
                {
                    HelpText("clear");
                    Console.WriteLine("\nThere was an error with your input. Please try again...");
                    return;
                }
                string password = "";
                string passwordSettings = args[1];
                string passwordSettingsFilled = passwordSettings.PadRight(Convert.ToInt32(args[0]), 'l');
                while(passwordSettingsFilled.Length != 0)
                {
                    int randomIndex = random.Next(0, passwordSettingsFilled.Length - 1);
                    char setting = passwordSettingsFilled.ToCharArray()[randomIndex];
                    passwordSettingsFilled = passwordSettingsFilled.Remove(randomIndex, 1);

                    switch (setting)
                    {
                        case 'l':
                            password += returnCharacter('l');
                            break;
                        case 'L':
                            password += returnCharacter('L');
                            break;
                        case 'd':
                            password += returnCharacter('d');
                            break;
                        case 's':
                            password += returnCharacter('s');
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

            static char returnCharacter(char character)
            {
                if (character == 'l')
                {
                    return (char)random.Next('a', 'z');
                }
                if (character == 'L')
                {
                    return (char)random.Next('A', 'Z');
                }
                if (character == 'd')
                {
                    //random number between 0 and 9, converted to string
                    //returns the character from index 0 of the string
                    return random.Next(0, 9).ToString()[0];
                }
                if (character == 's')
                {
                    string specialCharacters = "!@£$\"#¤%&/(){;.,:-_'*¨^~´?`}[]";
                    int randomIndex = random.Next(0, specialCharacters.Length - 1);
                    return specialCharacters[randomIndex];
                }
                else return '\0';
            }

            static bool checkInput(string[] args)
            {
                if (args.Length == 0)
                {
                    return false;
                }
                else if (args.Length == 2)
                {
                    string passwordLength = args[0];
                    string passwordSettings = args[1];
                    bool checkOne = checkLength(passwordLength);
                    bool checkTwo = checkSettings(passwordSettings);
                    if (!checkOne || !checkTwo)
                    {
                        return false;
                    }  
                }
                return true;
            }

            static bool checkLength(string passwordLength)
            {
                foreach (char character in passwordLength)
                {
                    if (!char.IsDigit(character))
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool checkSettings(string passwordSettings)
            {
                foreach (char character in passwordSettings)
                {
                    string validCharacters = "lLds";
                    if (!validCharacters.Contains(character))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

