using System;
using System.Threading.Tasks;

namespace LearningCS.Resources.TaskClasses.CSGO
{
    internal class CounterTerrorist : CSGOPlayer
    {
        public CounterTerrorist(string name) : base(name)
        {

        }

        public static async Task DefuseBomb()
        {
            Console.WriteLine("The bomb is being defused...");
            await Task.Delay(5000);
            Console.WriteLine("The bomb has been defused...");
            Console.WriteLine("Counter-terrorists win!");
            CounterStrike.IsDefused = true;
            CounterStrike.GameEnded = true;
        }

        public static async Task KillTerrorist(CSGOPlayer t, bool allDead, bool enemiesAlive)
        {
            if (!enemiesAlive) return;
            switch (CounterStrike.IsPlanted)
            {
                case false when !allDead && CounterStrike.IsSuccessful(5):
                    t.IsDead = true;
                    Console.WriteLine(t.Name + " was killed.");
                    return;
                case true when allDead:
                    await DefuseBomb();
                    return;
                default:
                {
                    switch (allDead)
                    {
                        case true when !CounterStrike.IsPlanted:
                            Console.WriteLine("Counter-Terrorists win!");
                            CounterStrike.GameEnded = true;
                            return;
                        case false when CounterStrike.IsSuccessful(3):
                            t.IsDead = true;
                            Console.WriteLine(t.Name + " was killed.");
                            return;
                    }
                    break;
                }
            }
        }
    }
}
