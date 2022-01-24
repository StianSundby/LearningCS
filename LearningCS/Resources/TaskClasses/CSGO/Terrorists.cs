using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCS.Resources.TaskClasses.CSGO
{
    internal class Terrorist : Player
    {

        public Terrorist(string name) : base(name)
        {

        }

        public static bool FindBombSite()
        {
            var success = CounterStrike.IsSuccessful(10);
            return success;
        }

        public static Task<Task> PlantBomb(List<Player> teamList)
        {
            var anyoneAlive = teamList.FindAll(x => x.IsDead == false).ToList();
            if (anyoneAlive.Count == 0) return Task.FromResult(Task.CompletedTask);
            Random random = new();
            if (FindBombSite() && !CounterStrike.IsPlanted)
            {
                Console.WriteLine("Bomb is being planted...");
            }
            if (CounterStrike.IsPlanted)
            {
                CounterStrike.BombTimer++;
                var tickOrTock = random.Next(0, 2);
                Console.WriteLine(tickOrTock == 1 ? "tick" : "tock");
            }

            if (CounterStrike.BombTimer == 5)
            {
                Console.WriteLine("Bomb has been planted.");
                CounterStrike.IsPlanted = true;
            }

            if (CounterStrike.IsDefused || !CounterStrike.IsPlanted || CounterStrike.BombTimer != 20)
                return Task.FromResult(Task.CompletedTask);
            Console.WriteLine("The bomb has exploded!\n" + "Terrorist wins!");
            CounterStrike.GameEnded = true;
            CounterStrike.IsDefused = true; //redundancy

            return Task.FromResult(Task.CompletedTask);
        }

        public static void KillCounterTerrorist(Player ct, bool allDead, bool enemiesAlive)
        {
            if (!enemiesAlive) return;
            switch (allDead)
            {
                case false when CounterStrike.IsSuccessful(7):
                    ct.IsDead = true;
                    Console.WriteLine(ct.Name + " was killed.");
                    return;
                case true:
                    Console.WriteLine("Terrorists win!");
                    CounterStrike.GameEnded = true;
                    return;
            }
        }


    }
}
