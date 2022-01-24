using System;
using System.Threading.Channels;
using LearningCS.Resources.TaskClasses.Matches;

namespace LearningCS
{
    internal class WeekFour
    {
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine(Properties.Resources.ReturnToPreviousMenu);
            Console.ReadKey(true);
            GoBack();
        }

        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekFour");
        }

        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFour_Task1_Intro);
            Console.ReadKey(true);
            Console.WriteLine("Slight warning: this code is abit janky and may cause some exception errors... Best of luck :)");
            Console.Write("Valid bets: \r\n - H, D, A\r\n - split: HD, HA, DA\r\n - full: HDA\r\nEnter your 12 bets with a comma as a seperator:");
            var betsText = Console.ReadLine();
            var rounds = new Rounds(betsText);
            while (true)
            {
                Console.Write("Enter round number 1-12 for the score or X to exit\r\nEnter command:");
                var command = Console.ReadLine();
                if (command == "X") break;
                var roundNumber = Convert.ToInt32(command);
                Console.Write($"Scoring in round {roundNumber}. \r\nEnter H for hometeam or A for awayteam:");
                var team = Console.ReadLine();
                rounds.AddGoal(roundNumber, team == "H");
                rounds.Score();
                rounds.CheckWins();
            }
            ReturnToPreviousMenu();
        }
    }
}
