#nullable enable
using System;

namespace LearningCS.Resources.TaskClasses.Standalone_classes
{
    internal class Match
    {
        private int _homeGoals;
        private int _awayGoals;
        private readonly string _bet;
        public static bool GameRunning { get; private set; }

        public Match(string bet)
        {
            _bet = bet;
            GameRunning = true;
        }

        public void AddGoal(string? homeTeam)
        {
            if (Convert.ToBoolean(homeTeam)) _homeGoals++;
            else _awayGoals++;
        }

        public bool CorrectBet()
        {
            var result = _homeGoals == _awayGoals ? "D" : _homeGoals > _awayGoals ? "H" : "A";
            return _bet.Contains(result);
        }

        public virtual void Stop()
        {
            GameRunning = false;
        }

        public string GetScore()
        {
            return _homeGoals + " - " + _awayGoals;
        }
    }
}
