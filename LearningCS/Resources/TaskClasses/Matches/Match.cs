namespace LearningCS.Resources.TaskClasses.Matches
{
    internal class Match
    {
        private int _homeGoals;
        private int _awayGoals;
        private readonly string _bet;
        

        public Match(string bet)
        {
            _bet = bet;
        }

        public void Goal(bool homeTeam)
        {
            if (homeTeam) _homeGoals++;
            else _awayGoals++;
        }

        public bool CheckBet()
        {
            var result = _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "A";
            return _bet.Contains(result);
        }

        public string GetScore()
        {
            return _homeGoals + "-" + _awayGoals;
        }
    }
}
