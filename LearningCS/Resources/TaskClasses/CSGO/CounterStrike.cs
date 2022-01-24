using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningCS.Resources.TaskClasses.CSGO
{
    internal class CounterStrike
    {
        private static readonly List<Player> T = new();
        private static readonly List<Player> Ct = new();
        public static bool IsPlanted = false;
        public static bool IsDefused = false;
        public static bool GameEnded = false;
        public static int BombTimer = 0;

        // Main
        public static async Task StartGame()
        {
            AddTeamMembers();
            Console.WriteLine("Game started.");
            while (!GameEnded)
            {
                await Terrorist.PlantBomb(T);
                await PickRandomPlayer(Ct, T, "CT dies");
                await PickRandomPlayer(T, Ct, "T dies");
                await Task.Delay(1000);
            }

            Console.WriteLine("\nGame over.\n");
        }

        private static async Task PickRandomPlayer(List<Player> playerList, List<Player> enemyList, string team)
        {
            Random rnd = new();
            var teamAliveList = playerList.FindAll(x => x.IsDead == false).ToList();
            var enemyAliveList = enemyList.FindAll(x => x.IsDead == false).ToList();
            var index = rnd.Next(0, teamAliveList.Count);
            var playerToKill = 0;
            if (teamAliveList.Count > 0) playerToKill = playerList.FindIndex(x => x.Name == teamAliveList[index].Name);
            var enemiesAlive = enemyAliveList.Count > 0;
            switch (team, teamAliveList.Count > 0)
            {
                case ("CT dies", true):
                    Terrorist.KillCounterTerrorist(Ct[playerToKill], false, enemiesAlive);
                    break;
                case ("T dies", true):
                    await CounterTerrorist.KillTerrorist(T[playerToKill], false, enemiesAlive);
                    break;
                case ("T dies", false):
                    await CounterTerrorist.KillTerrorist(T[playerToKill], true, enemiesAlive);
                    break;
                case ("CT dies", false):
                    Terrorist.KillCounterTerrorist(Ct[playerToKill], true, enemiesAlive);
                    break;
            }
        }

        public static bool IsSuccessful(int maxValue)
        {
            var random = new Random();
            return random.Next(0, maxValue) == 2;
        }

        private static void AddTeamMembers()
        {
            T.AddRange(new List<Player>()
            {
                new Terrorist("T-Derk"),
                new Terrorist("T-Gnerk"),
                new Terrorist("T-Hurk"),
                new Terrorist("T-Burk"),
                new Terrorist("T-Snurk"),
            });
            Ct.AddRange(new List<Player>()
            {
                new CounterTerrorist("CT-Gnikk"),
                new CounterTerrorist("CT-Gnukk"),
                new CounterTerrorist("CT-Gnakk"),
                new CounterTerrorist("CT-Grakk"),
                new CounterTerrorist("CT-Glakk"),
            });
        }
    }
}
