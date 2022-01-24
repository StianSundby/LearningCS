using System;
using System.Linq;

namespace LearningCS.Resources.TaskClasses.Matches
{
    internal class Rounds
    {
        public bool GameRunning { get; private set; }
        private readonly Match[] _rounds;

        public Rounds(string userBet)
        {
            GameRunning = true;
            var bets = userBet.Split(',');
            _rounds = new Match[12];
            for (var i = 0; i < 12; i++)
            {
                _rounds[i] = new Match(bets[i]);
            }
        }

        public bool Stop()
        {
            
            return GameRunning;
        }

        public void AddGoal(int roundNumber, bool homeTeam)
        {
            var index = roundNumber - 1;
            var currentRound = _rounds[index];
            currentRound.Goal(homeTeam);
        }

        public void Score()
        {
            for (var index = 0; index < _rounds.Length; index++)
            {
                var round = _rounds[index];
                var matchNo = index + 1;
                var checkBet = round.CheckBet();
                var checkBetOutput = checkBet ? "correct" : "wrong";
                Console.WriteLine($"Round {matchNo}: {round.GetScore()} - {checkBetOutput}");
            }
        }

        public void CheckWins()
        {
            var currentRound = _rounds.Count(round => round.CheckBet());
            Console.WriteLine($"You have {currentRound} correct bets.");
        }
    }
}
