using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using LearningCS.Resources.TaskClasses;

namespace LearningCS
{
    internal class WeekThree
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
            Program.ChooseTask("WeekThree");
        }

        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekThree_Task1_Intro);
            var words = ImportWords();
            var count = 200;
            while (count > 0)
            {
                var findPair = FindPair(words);
                if (findPair) count--;
            }

            ReturnToPreviousMenu();

            static string[] ImportWords()
            {
                var previousWord = string.Empty;
                const string filePath = @"D:\Repos\LearningCS\LearningCS\Resources\wordlist.txt";
                var words = new List<string>();
                foreach (var line in File.ReadLines(filePath, Encoding.UTF8))
                {
                    var segment = line.Split('\t');
                    var word = segment[1];
                    if (word != previousWord && word.Length is > 6 and < 10 && !word.Contains("-"))
                    {
                        words.Add(word);
                    }

                    previousWord = word;
                }

                return words.ToArray();
            }

            static bool FindPair(IReadOnlyList<string> words)
            {
                var randomIndex = Random.Next(words.Count);
                var currentWord = words[randomIndex];
                Console.Write(currentWord + " - ");
                foreach (var word in words)
                {
                    if (!LastEqualFirst(currentWord, word)) continue;
                    Console.Write(word);
                    Console.WriteLine();
                    return true;
                }

                Console.WriteLine("Couldn't find a matching pair");
                return false;
            }

            static bool LastEqualFirst(string currentWord, string word)
            {
                return CheckForMatch(4, currentWord, word) || CheckForMatch(5, currentWord, word);
            }

            static bool CheckForMatch(int length, string currentWord, string word)
            {
                var currentWordLastPart = currentWord.Substring(currentWord.Length - length, length);
                var wordFirstPart = word[..length];
                return currentWordLastPart == wordFirstPart;
            }
        }

        public static void Task2()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekThree_Task2_Intro);

            Console.ReadKey(true);
            var textPrinter = new TextPrinter("Stian", 10);
            textPrinter.PrintName();
            ReturnToPreviousMenu();
        }


        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine("Task 3:\n" +
                              "This task is similar to the last one, but we were to overload methods in the class.\n" +
                              "Our default method was to print 'Hello and welcome'\n"+
                              "And we were to overload that method with a string parameter. So it would print\n" +
                              "'Hello and welcome, [name]' instead.\n"+
                              "Press any key to continue...\n");
            Console.ReadKey(true);
            var welcomeMessage = new WelcomeMessage("Hello and welcome");
            welcomeMessage.PrintWelcomeMessage("Terje");
            ReturnToPreviousMenu();
        }
    }
}