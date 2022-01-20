using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Transactions;

namespace LearningCS
{
    internal class WeekTwo
    {
        private static readonly Random Random = new();
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nThat's it. Press any key to return...");
            Console.ReadKey(true);
            GoBack();
        }
        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekTwo");
        }
        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekTwo_Task1_Intro);
            Console.WriteLine("Type in some text and have the program count each character...");
            const int range = 255;
            var asciiTable = new int[range];
            var text = "something";
            while (!string.IsNullOrWhiteSpace(text))
            {
                text = Console.ReadLine();
                foreach (var character in text ?? string.Empty)
                {
                    asciiTable[(int)character]++;
                }
                for (var i = 0; i < range; i++)
                {
                    if (asciiTable[i] <= 0) continue;
                    var character = (char)i;
                    Console.WriteLine(character + @" - " + asciiTable[i]);
                }
            }
            ReturnToPreviousMenu();
        }
        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekTwo_Task2_Intro
            );
            Console.ReadKey(true);

            ShapeOne(); //puzzle one
            NextPuzzle();
            ShapeTwo(); //puzzle two
            NextPuzzle();
            ShapeThree(); //puzzle three
            NextPuzzle();

            Console.WriteLine("\n\n Enter some text...\n"); //puzzle four
            var userinput = Console.ReadLine();
            if (userinput != null)
            {
                var stringToCheck = userinput.ToLower();
                Console.WriteLine("\nThe text you entered can be broken down like this:");
                Console.WriteLine("Words: " + CountWords(stringToCheck));
                Console.WriteLine("Longest word: " + LongestWord(stringToCheck));
                Console.WriteLine("Amount of vowels used: " + VowelCount(stringToCheck) + "\n");
            }
            else
            {
                Console.WriteLine("\n\n Error: Didnt see any text entered. Returning to the menu...\n");
                Console.ReadKey(true);
                ReturnToPreviousMenu();
            }

            ReturnToPreviousMenu();

            void ShapeOne()
            {
                Console.WriteLine("\nShape number one:\n");
                WriteLine(8, 0, false);
                WriteLine(6, 0, true);
                WriteLine(4, 2, true);
                WriteLine(2, 3, true);
            }

            void ShapeTwo()
            {
                Console.WriteLine("\nShape number two:\n");
                WriteLine(2, 4, true);
                WriteLine(4, 3, true);
                WriteLine(6, 2, true);
                WriteLine(8, 0, true);
                WriteLine(8, 0, true);
                WriteLine(6, 2, true);
                WriteLine(4, 3, true);
                WriteLine(2, 4, true);
            }

            void ShapeThree()
            {
                Console.WriteLine("\nShape number three:\n");
                Console.WriteLine(WriteLineX(0, 1, 12, 1));
                Console.WriteLine(WriteLineX(1, 2, 8, 2));
                Console.WriteLine(WriteLineX(2, 3, 4, 3));
                Console.WriteLine(WriteLineX(3, 8, 0, 0));
                Console.WriteLine(WriteLineX(3, 8, 0, 0));
                Console.WriteLine(WriteLineX(2, 3, 4, 3));
                Console.WriteLine(WriteLineX(1, 2, 8, 2));
                Console.WriteLine(WriteLineX(0, 1, 12, 1));

            }

            void WriteLine(int hashTagAmount, int whiteSpaceAmount, bool whiteSpaceFirst)
            {
                if (whiteSpaceFirst)
                {
                    Console.Write(WhiteSpace(whiteSpaceAmount));
                    Console.Write(HashTag(hashTagAmount));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(HashTag(hashTagAmount));
                    Console.Write(WhiteSpace(whiteSpaceAmount));
                    Console.WriteLine();
                }
            }

            string WriteLineX(int whiteSpace1, int hashTag1, int whiteSpace2, int hashTag2)
            {
                var stringToReturn = "";
                if (whiteSpace1 >= 1)
                {
                    for (var i = 0; i < whiteSpace1; i++)
                    {
                        stringToReturn = stringToReturn.Insert(stringToReturn.Length, " ");
                    }
                }

                if (hashTag1 >= 1)
                {
                    for (var i = 0; i < hashTag1; i++)
                    {
                        stringToReturn = stringToReturn.Insert(stringToReturn.Length, "#");
                    }
                }

                if (whiteSpace2 >= 1)
                {
                    for (var i = 0; i < whiteSpace2; i++)
                    {
                        stringToReturn = stringToReturn.Insert(stringToReturn.Length, " ");
                    }
                }

                if (hashTag2 < 1) return stringToReturn;
                {
                    for (var i = 0; i < hashTag2; i++)
                    {
                        stringToReturn = stringToReturn.Insert(stringToReturn.Length, "#");
                    }
                }
                return stringToReturn;
            }

            string HashTag(int amount)
            {
                const string hashTag = "#";
                var padRight = string.Empty;
                for (var i = 0; i < amount; i++)
                {
                    padRight += hashTag.PadRight(1, '#');
                }

                return padRight;
            }

            string WhiteSpace(int amount)
            {
                const string whiteSpace = " ";
                var padLeft = whiteSpace.PadLeft(amount);
                return padLeft;
            }

            string VowelCount(string inputString)
            {
                char[] vowelChars = { 'a', 'e', 'i', 'o', 'u', 'y' };
                var substring = inputString.Split(' ');
                var count = substring.SelectMany(word => word).Count(character => vowelChars.Contains(character));

                return Convert.ToString(count);
            }

            string LongestWord(string inputString)
            {
                if (inputString == null) return string.Empty;

                var substring = inputString.Split(' ');
                var wordlength = 0;
                foreach (var word in substring)
                {
                    if (wordlength == 0) wordlength = word.Length;
                    else if (word.Length > wordlength)
                    {
                        wordlength = word.Length;
                    }
                }
                return Convert.ToString(wordlength);
            }

            int CountWords(string inputString)
            {
                if (inputString == null) return 0;
                var substring = inputString.Split(' ');
                var count = Convert.ToInt32(substring.Length);
                return count;

            }

            void NextPuzzle()
            {
                Console.WriteLine(Properties.Resources.WeekTwo_Task2_NextPuzzle);
                Console.ReadKey(true);
            }
        }

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine(
                Properties.Resources.WeekTwo_Task3_Intro
            );
            Console.ReadKey(true);
            ProblemOne();
            ProblemTwo();
            //ProblemThree() called from inside ProblemTwo()
            ProblemFour();
            ProblemFive();
            ReturnToPreviousMenu();
            static void ProblemOne()
            {
                Console.Clear();
                Console.WriteLine(
                    Properties.Resources.WeekTwo_Task3_ProblemOne_Intro);
                int[] array = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
                Console.WriteLine("Checking if array is sorted, which it should be...");
                Console.WriteLine(IsSorted(array, array.Length) 
                    ? "The array is sorted." 
                    : "The array is not sorted.");
                Console.WriteLine("\nPress any key to view the next puzzle...");
                Console.ReadKey(true);
                bool IsSorted(IReadOnlyList<int> arrayToCheck, int length)
                {
                    for (var i = 0; i < length; i++)
                    {
                        if (arrayToCheck[i] > length)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            static void ProblemTwo()
            {
                Console.Clear();
                Console.WriteLine(
                    Properties.Resources.WeekTwo_Task3_ProblemTwo_Intro
                );
                
                Console.WriteLine("Enter some text to have it be converted ciphertext...");
                var userInput = Console.ReadLine();
                var output = ConvertText(userInput);
                Console.WriteLine(output);
                Console.WriteLine("\nPress any key to view the next puzzle...");
                Console.ReadKey(true);
                ProblemThree(output);
                static string ConvertText(string input)
                {
                    const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                    const string cipherCode = "HVSEÆKXCOUDAJQGØNZTMYRÅFPIWBL";
                    var result = ConvertToCipher(input);

                    string ConvertToCipher(string input)
                    {
                        var converted = "";
                        foreach (var character in input)
                        {
                            converted += ChangeChar(character, alphabet, cipherCode);
                        }
                        return converted;
                    }

                    char ChangeChar(char character, string alphabet, string cipherCode)
                    {
                        for (var i = 0; i < alphabet.Length; i++)
                        {
                            if (char.ToUpper(character) == alphabet[i])
                            {
                                return cipherCode[i];
                            }
                        }
                        return character;
                    }

                    return result;
                }
            }

            static void ProblemThree(string cipherText)
            {
                Console.WriteLine(
                    Properties.Resources.WeekTwo_Task3_ProblemThree_Intro
                );
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                const string cipherCode = "HVSEÆKXCOUDAJQGØNZTMYRÅFPIWBL";
                
                Console.WriteLine("Press any key to convert the ciphertext back into plaintext...");
                Console.ReadKey(true);
                var result = ConvertToCipher(cipherText);

                string ConvertToCipher(string input)
                {
                    var converted = "";
                    foreach (var character in input)
                    {
                        converted += ChangeChar(character, alphabet, cipherCode);
                    }
                    return converted;
                }

                char ChangeChar(char character, string alphabet, string cipherCode)
                {
                    for (var i = 0; i < alphabet.Length; i++)
                    {
                        if (char.ToUpper(character) == cipherCode[i])
                        {
                            return alphabet[i];
                        }
                    }
                    return character;
                }
                Console.WriteLine(result);
            }

            static void ProblemFour()
            {
                Console.Clear();
                Console.WriteLine(
                    Properties.Resources.WeekTwo_Task3_ProblemFour_Intro
                );

                Console.WriteLine("Press any key to view the ciphercode...");
                Console.ReadKey(true);
                const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
                var cipherCode = ConvertToCipher(alphabet);
                Console.WriteLine(cipherCode);
                Console.WriteLine("\nPress any key to view the next problem...");
                Console.ReadKey(true);

                static string ConvertToCipher(string alphabet)
                {
                    var cipherCode = alphabet.ToCharArray();
                    for (var i = 0; i < alphabet.Length; i++)
                    {
                        int randomIndex2;
                        int avoidIndex2;
                        do
                        {
                            var randomChar1 = cipherCode[i];
                            var avoidChar1 = alphabet.IndexOf(randomChar1);
                            randomIndex2 = Random.Next(0, alphabet.Length - 1);

                            if (randomIndex2 >= avoidChar1) randomIndex2++;
                            var randomChar2 = cipherCode[randomIndex2];
                            avoidIndex2 = alphabet.IndexOf(randomChar2);
                        } while (avoidIndex2 == i);

                        (cipherCode[i], cipherCode[randomIndex2]) = (cipherCode[randomIndex2], cipherCode[i]);
                    }

                    return new string(cipherCode);
                }


            }

            static void ProblemFive()
            {
                Console.Clear();
                Console.WriteLine(
                    Properties.Resources.WeekTwo_Task3_ProblemFive_Intro
                );
                var intArray = new[] { 8, 7, 3, 9, 2, 1, 7, 5, 4, 5, 4, 7, 3, 2, 1, 7, 3, 7, 8};
                Array.Sort(intArray);
                int maxCount = 1, res = intArray[0];
                var currentCount = 1;
                for (var i = 1; i < intArray.Length; i++)
                {
                    if (intArray[i] == intArray[i - 1]) currentCount++;
                    else
                    {
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            res = intArray[i - 1];
                        }

                        currentCount = 1;
                    }
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    res = intArray[^1];
                }

                var occurrences = intArray.Count(x => x == res);
                Console.WriteLine("The array we're checking looks like this:\n");
                foreach (var item in intArray)
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine("\nPress any key to get the mode\n");
                Console.ReadKey(true);
                Console.WriteLine("\nThe mode is: " + res + ".\nIt appears " + occurrences + " times in the array\n\n");
            }
        }
    }
}