using System;
using System.Threading;
using System.Threading.Tasks;
using LearningCS.Resources.TaskClasses;
using LearningCS.Resources.TaskClasses.Matches;

namespace LearningCS
{
    internal class WeekFour
    {
        private static void ReturnToPreviousMenu()
        {
            Console.WriteLine(Properties.Resources.ReturnToPreviousMenu);
            Console.ReadKey(true);
            GoBack();
        }

        public static void GoBack()
        {
            Console.Clear();
            Program.ChooseTask("WeekFour");
        }

        public static void Task1()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFour_Task1_Intro);
            Console.ReadKey(true);
            Console.WriteLine("Slight warning: this code is abit janky and may cause some exception errors... Best of luck :)");
            Console.Write("Valid bets: \r\n - H, D, A\r\n - split: HD, HA, DA\r\n - full: HDA\r\nEnter your 12 bets with a comma as a seperator:");
            var betsText = Console.ReadLine();
            var rounds = new Rounds(betsText);
            while (true)
            {
                Console.Write("Enter round number 1-12 for the score or X to exit\r\nEnter command:");
                var command = Console.ReadLine();
                if (command == "X") break;
                var roundNumber = Convert.ToInt32(command);
                Console.Write($"Scoring in round {roundNumber}. \r\nEnter H for hometeam or A for awayteam:");
                var team = Console.ReadLine();
                rounds.AddGoal(roundNumber, team == "H");
                rounds.Score();
                rounds.CheckWins();
            }
            ReturnToPreviousMenu();
        }

        public static async void Task2()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFour_Task2_Intro);
            Console.ReadKey(true);
            await Start();
            ReturnToPreviousMenu();


            async Task Start()
            {
                var hero = new BossFight("Hero", 100, 20, 40);
                var boss = new BossFight("Boss", 400, RandomStrength(0, 30), 10);
                Console.WriteLine("Press any key to start the fight...\n\n");
                Console.ReadKey(true);

                while (CheckWin(hero, boss))
                {
                    await Fight(hero, boss);
                    await Task.Delay(1000);
                    await Fight(boss, hero);
                }
                if (hero.Health <= 0) Console.WriteLine($"{boss.Name} has won!");
                else if (boss.Health <= 0) Console.WriteLine($"{hero.Name} has won!");
            }

            async Task Fight(BossFight character, BossFight enemy)
            {
                await Task.Delay(100);
                if (character.Name == "Boss") character.Strength = RandomStrength(0, 30);

                Console.WriteLine($"{character.Name} tries to attack {enemy.Name}!");
                await Task.Delay(1000);

                if (character.Stamina == 0)
                {
                    Console.WriteLine($"But {character.Name} is out of stamina and has to recharge...\n");
                    Recharge(character);
                    return;
                }

                enemy.Health -= character.Strength;
                Console.WriteLine($"{enemy.Name} is hit and takes {character.Strength} damage.\n{enemy.Name} has {enemy.Health} HP left...\n");
                character.Stamina -= 10;
            }

            bool CheckWin(BossFight hero, BossFight boss)
            {
                return hero.Health > 0 && boss.Health > 0;
            }

            void Recharge(BossFight character)
            {
                character.Stamina = character.Name switch
                {
                    "Hero" => 40,
                    "Boss" => 10,
                    _ => character.Stamina
                };
            }

             int RandomStrength(int min, int max)
            {
                var randomStrength = new Random().Next(min, max);
                return randomStrength;
            }
        }
    }
}
