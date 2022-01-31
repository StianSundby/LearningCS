namespace LearningCS.Resources.TaskClasses.AdventureGame
{
    internal class Room
    {
        public string Name;
        public string[] Content;
        public bool Start;
        public bool Won;

        public string GetContent()
        {
            return string.Join("\n", Content);
        }
    }
}
