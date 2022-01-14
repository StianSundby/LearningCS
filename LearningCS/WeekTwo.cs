using System;
using System.Collections.Generic;
using System.Linq;
using LearningCS.Properties;

namespace LearningCS
{
    internal class WeekTwo
    {
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
            Console.WriteLine(Resources.WeekTwo_Task1_);
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
                "Assignment 8 - Puzzles.\n" +
                "We were given 4 puzzles that we had to solve.\n" +
                "The first three was about printing out some '#' to the console in a given pattern.\n" +
                "Pattern one being the easiest and three being the hardest.\n" +
                "The rules were as follows:\n" +
                "I can only write Console.Write('#'), Console.Write(' ') and Console.WriteLine.\n\n" +
                "The last puzzle was to count the number of words in the users input.\n" +
                "In addition to that it should count the amount of characters in the longest word.\n" +
                "The amount of vowels and any other statistic we could thing of.\n\n" +
                "Press any key to view the first puzzle..."
            );
            Console.ReadKey(true);

            ShapeOne(); //puzzle one
            Console.WriteLine(Resources.WeekTwo_Task2_Next);
            Console.ReadKey(true);

            ShapeTwo(); //puzzle two
            Console.WriteLine(Resources.WeekTwo_Task2_Next);
            Console.ReadKey(true);

            ShapeThree(); //puzzle three
            Console.WriteLine(Resources.WeekTwo_Task2_Next);
            Console.ReadKey(true);

            Console.WriteLine("\n\n Enter some text...\n"); //puzzle four
            var userinput = Console.ReadLine();
            var stringToCheck = userinput.ToLower();
            Console.WriteLine("\nThe text you entered can be broken down like this:");
            Console.WriteLine("Words: " + CountWords(stringToCheck));
            Console.WriteLine("Longest word: " + LongestWord(stringToCheck));
            Console.WriteLine("Amount of vowels used: " + VowelCount(stringToCheck) + "\n");

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

            string VowelCount(string stringToCheck)
            {
                var count = 0;
                char[] vowelChars = { 'a', 'e', 'i', 'o', 'u', 'y' };
                var substring = stringToCheck.Split(' ');
                foreach (var word in substring)
                {
                    foreach (var character in word)
                    {
                        if (vowelChars.Contains(character))
                        {
                            count++;
                        }
                    }
                }

                return Convert.ToString(count);
            }

            string LongestWord(string? stringToCheck)
            {
                if (stringToCheck == null) return string.Empty;

                var substring = stringToCheck.Split(' ');
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

            int CountWords(string? stringToCheck)
            {
                if (stringToCheck == null) return 0;
                var substring = stringToCheck.Split(' ');
                var count = Convert.ToInt32(substring.Length);
                return count;

            }
        }
        
        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine(
                "Assignment 9 - Arrays.\n" +
                "We were given 5 puzzles that we had to solve.\n" +
                "Each one was to be solved using arrays in one way or another.\n" +
                "Press any key to view the first puzzle...\n"
            );
            Console.ReadKey(true);
            ProblemOne();
            ProblemTwo();
            static void ProblemOne()
            {
                Console.Clear();
                Console.WriteLine(
                    "The problem:\n" +
                    "Write a bool function that is passed an array and the number of elements in\n" +
                    "that array and determines whether the data in the array is sorted.This should\n" +
                    "require only one pass!\n");
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
                    "The problem:\n" +
                    "Here’s a variation on the array of const values. Write a program for creating a\n" +
                    "substitution cipher problem.In a substitution cipher problem, all messages\n" +
                    "are made of uppercase letters and punctuation.The original message is called\n" +
                    "the plaintext, and you create the ciphertext by substituting each letter with\n" +
                    "another letter(for example, each C could become an X).For this problem,\n" +
                    "hard-code a const array of 26 char elements for the cipher, and have your\n" +
                    "program read a plaintext message and output the equivalent ciphertext.\n"
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
                    "The problem:\n" +
                    "Have the previous program convert the ciphertext back to the plaintext to\n" +
                    "verify the encoding and decoding.\n"
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
        }
    }
}