using System.Collections.Generic;

namespace LearningCS.Resources.TaskClasses.AdventureGame
{
    internal class AdventurePlayer
    {
        public List<string> Have;
        public Room Room;

        public AdventurePlayer()
        {
            Have = new List<string>();
        }

        public string Inventory()
        {
            return string.Join("\n", Have);
        }
    }
}
