﻿using System;

namespace LearningCS
{
    internal class WeekTwo
    {
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nThat's it. Press any key to return");
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
            Console.WriteLine(
                "Assignment 7 - Debugging.\n" +
                "The code provided for this assignment is the same as in WeekOne, Task 4.\n" +
                "It was about teaching us debugging in Visual Studio. \n" +
                "Breakpoints, step-into, step-over and step-out. \n" +
                "There isn't alot to show here. But feel free to: \n\n" +
                "Type in some letters and the code will count the amount of each one..."
                );
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
    }
}
