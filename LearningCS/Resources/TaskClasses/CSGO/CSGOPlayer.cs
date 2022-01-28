namespace LearningCS.Resources.TaskClasses.CSGO
{
    internal class CSGOPlayer
    {
        public string Name { get; set; }
        public bool IsDead { get; set; }
        public CSGOPlayer(string name)
        {
            Name = name;
            IsDead = false;
        }
    }
}
