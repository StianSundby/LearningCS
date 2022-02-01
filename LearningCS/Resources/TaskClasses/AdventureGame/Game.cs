using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningCS.Resources.TaskClasses.AdventureGame
{
    internal class Game
    {
        private static Model _model;

        public static void AdventureGame()
        {
            _model = new Model();
            while (true)
            {
                UpdateView();
                Console.Write("Enter command: ");
                var command = Console.ReadLine();
                if (command != string.Empty && command != " ")
                {
                    if (command.ToLower().StartsWith("Pick up"))
                    {
                        if (_model.Player.Room.Content.Length >= 1)
                        {
                            var content = _model.Player.Room.Content;

                            var itemToCopy = content[0];
                            _model.Player.Have.Add(itemToCopy);

                            var tempList = new List<string>(content);
                            tempList.RemoveAt(0);
                            tempList.ToArray();
                            //return?
                        }
                        else{ Console.WriteLine("You search the room but find nothing...");}
                    }

                    if (command.ToLower().StartsWith("Unlock"))
                    {
                        if (_model.Player.Have.Count > 0)
                        {
                            var playerInventory = _model.Player.Have;
                            foreach (var item in playerInventory)
                            {
                                var keyColor = item.Split(' ');
                                var room = _model.Player.Room;
                                var doors = _model.Doors.Where(d => d.A == room || d.B == room);
                                foreach (var door in doors)
                                {
                                    if (keyColor[0] == door.color)
                                    {
                                        playerInventory.Remove(item);
                                        door.open = true;
                                        Console.WriteLine($"You open the door with your {item}");
                                        //return?
                                    }
                                }
                            }
                        }
                    }

                    if (command.ToLower().StartsWith("Enter"))
                    {
                        var room = _model.Player.Room;
                        var doorsInRoom = _model.Doors.Where(d => d.A == room || d.B == room);
                        var openDoors = doorsInRoom.Count(door => door.open);

                        if (openDoors <= 0)
                        {
                            Console.WriteLine("There arren't any open doors in this room");
                            return;
                        }
                        if (openDoors ! > 1)
                        {
                            foreach (var door in doorsInRoom)
                            {
                                //if door is open and the name of the door matches one of the doors in the room
                                    //move player location to that room
                                    //return and update view
                            }
                        }

                        if (openDoors > 1)
                        {
                            Console.WriteLine("Which door do you want to enter?");
                            var whichDoor = Console.ReadLine();
                            //if the door  with the same name as whichDoor is open
                                //go through
                                //return and update view
                            //if the door is locked
                                //cw
                                //return and update view
                        }
                    }
                }
            }
        }

        private static void UpdateView()
        {
            var player = _model.Player;
            var room = player.Room;
            var header = room.Won ? "Congratulations! You finished the game!" : $"You are in room {room.Name}";
            var inventory = player != null && player.Inventory() == null ? "no items" : player.Inventory();
            Console.WriteLine($"{header}\n\nInside the room, you see: {room.GetContent()}\n\n" +
                              $"You have: {inventory}\n\nDoors:\n{_model.AvailableDoors()}");
        }
    }
}
