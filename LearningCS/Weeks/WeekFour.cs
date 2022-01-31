using System;
using System.Threading;
using System.Threading.Tasks;
using LearningCS.Resources.TaskClasses;
using LearningCS.Resources.TaskClasses.AdventureGame;
using LearningCS.Resources.TaskClasses.Matches;

namespace LearningCS.Weeks
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

        public static void Task3()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFour_Task3_Intro);
            Console.ReadKey(true);

            #region Initialize
            int mode;
            char xo;
            char computerChar;
            InitializeGame();

            char[] a = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            var turn = 1;
            var gameStatus = 0;
            #endregion
            do
            {
                #region AlwaysOnScreen
                Console.Clear();
                switch (mode)
                {
                    case 1:
                        Console.WriteLine("Player:X and Computer:O");
                        Console.WriteLine("\n");
                        Console.WriteLine(turn % 2 == 0 ? "Computers turn" : "Players turn");
                        break;
                    case 2:
                        Console.WriteLine("Player1:X and Player2:O");
                        Console.WriteLine("\n");
                        Console.WriteLine(turn % 2 == 0 ? "Player 2' turn" : "Player 1's turn");
                        break;
                }
                Board();
                #endregion

                int selectedSquare;
                switch (mode)
                {
                    case 1:
                        #region PlayersTurn

                        if (turn % 2 == 0) goto case 2;
                        Console.WriteLine("Where do you want to place your piece?");
                        selectedSquare = int.Parse(Console.ReadLine() ?? string.Empty);

                        if (a[selectedSquare] != 'X' && a[selectedSquare] != 'O')
                        {
                            a[selectedSquare] = char.ToUpper(xo);
                            turn++;
                        }
                        else
                        {
                            Console.WriteLine("Square number {0} is already marked with an {1}", selectedSquare, a[selectedSquare]);
                            Console.WriteLine("Please wait while the board reloads...");
                            Thread.Sleep(1000);
                        }
                        #endregion
                        gameStatus = CheckWin();
                        break;

                    case 2:
                        #region ComputersTurn
                        selectedSquare = new Random().Next(1, 9);
                        while (a[selectedSquare] == 'X' || a[selectedSquare] == 'O')
                        {
                            selectedSquare = new Random().Next(1, 9);
                        }

                        a[selectedSquare] = char.ToUpper(computerChar);
                        turn++;
                        #endregion
                        gameStatus = CheckWin();
                        break;
                }
            } while (gameStatus != 1 && gameStatus != -1);

            Console.Clear();
            Board();

            #region EndOfGameMessage
            switch (gameStatus)
            {
                case 1:
                    switch ((turn % 2) + 1)
                    {
                        case 1:
                            Console.WriteLine("You won!");
                            break;
                        case 2:
                            Console.WriteLine("The computer won!");
                            break;
                    }

                    break;
                case -1:
                    Console.WriteLine("Draw!");
                    break;
            }
            #endregion

            ReturnToPreviousMenu();

            void Board()
            {
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", a[1], a[2], a[3]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", a[4], a[5], a[6]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", a[7], a[8], a[9]);
                Console.WriteLine("     |     |      ");
            }

            int CheckWin()
            {
                #region Horizontal
                if (a[1] == a[2] && a[2] == a[3]) return 1;
                if (a[4] == a[5] && a[5] == a[6]) return 1;
                if (a[6] == a[7] && a[7] == a[8]) return 1;
                #endregion
                #region Vertical
                if (a[1] == a[4] && a[4] == a[7]) return 1;
                if (a[2] == a[5] && a[5] == a[8]) return 1;
                if (a[3] == a[6] && a[6] == a[9]) return 1;
                #endregion
                #region Diagonal
                if (a[1] == a[5] && a[5] == a[9]) return 1;
                if (a[3] == a[5] && a[5] == a[7]) return 1;
                #endregion
                #region Draw
                if (a[1] != '1' && a[2] != '2' && a[3] != '3'
                    && a[4] != '4' && a[5] != '5' && a[6] != '6'
                    && a[7] != '7' && a[8] != '8' && a[9] != '9') return -1;



                #endregion
                return 0;
            }

            void InitializeGame()
            {
                computerChar = '\0';

                #region WriteLine
                Console.WriteLine(
                    "Choose a mode:\n" +
                    "    1 - Player vs. Computer\n" +
                    "    2 - Player1 vs. Player2\n\n" +
                    "Enter your choice:"
                );
                #endregion
                mode = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.WriteLine("Do you want to be X or O?");
                xo = Convert.ToChar(Console.ReadLine()?.ToUpper()!);
                computerChar = xo switch
                {
                    'X' => 'O',
                    'O' => 'X',
                    _ => computerChar
                };
            }
        }

        public static void Task4()
        {
            Console.Clear();
            Console.WriteLine(Properties.Resources.WeekFour_Task4_Intro);
            Console.ReadKey();

            Random random = new();
            var players = new[] {
                new Player("One", 10, random), 
                new Player("Two", 10, random),
            };
            Player player1;
            Player player2;
            do
            {
                var playerIndex1 = random.Next(players.Length);
                var playerIndex2 = (playerIndex1 + 1 + random.Next(2)) % players.Length;
                player1 = players[playerIndex1];
                player2 = players[playerIndex2];
                player1.Play(player1, player2);
                Thread.Sleep(250);
            } 
            while (player1._score != 0 || player2._score != 0);
        }

        public static void Task5() //TODO
        {
            Game.AdventureGame();
        }
    }
}
