namespace LearningCS.Resources.TaskClasses.Standalone_classes
{
    internal class BossFight
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }

        public BossFight(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
        }
    }
}
