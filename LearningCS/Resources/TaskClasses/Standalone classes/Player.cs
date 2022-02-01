using System;

namespace LearningCS.Resources.TaskClasses.Standalone_classes
{
    internal class Player
    {
        private readonly string _name;
        public int Score;
        private readonly Random _random;

        public Player(string name, int score, Random random)
        {
            _name = name;
            Score = score;
            _random = random;
        }

        public void Play(Player player1, Player player2)
        {
            var winner = _random.Next(2) == 0 ? player1 : player2;
            var loser = winner == this ? player2 : player1;
            winner.Score += 1;
            loser.Score -= 1;
            ShowNameAndPoints(winner._name == "One");
        }

        public void ShowNameAndPoints(bool playerOneWins)
        {
            switch (playerOneWins)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Player " + _name.PadRight(5) + Score.ToString().PadLeft(2) + " pts");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player " + _name.PadRight(5) + Score.ToString().PadLeft(2) + " pts");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
