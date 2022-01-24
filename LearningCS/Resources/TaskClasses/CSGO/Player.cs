namespace LearningCS.Resources.TaskClasses.CSGO
{
    internal class Player
    {
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public Player(string name)
        {
            Name = name;
            IsDead = false;
        }
    }
}
