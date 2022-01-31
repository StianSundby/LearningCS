using System;
using System.Linq;

namespace LearningCS.Resources.TaskClasses.AdventureGame
{
    internal class Model
    {
        public AdventurePlayer Player;
        public Room[] Rooms;
        public Door[] Doors;

        public Model()
        {
            Player = new AdventurePlayer();
            #region Rooms
            var roomA = new Room { Name = "A", Content = new[] { "Red key"}, Start = true};
            var roomB = new Room { Name = "B", Content = new[] { "Green key" }};
            var roomC = new Room { Name = "C", Content = new[] { "White key" }};
            var roomD = new Room { Name = "D", Content = new[] { "Blue key" }};
            var roomE = new Room { Name = "E", Content = new[] { "Grey key" }};
            var roomF = new Room { Name = "F", Content = Array.Empty<string>(), Won = true };
            Rooms = new[] {roomA, roomB, roomC, roomD, roomE, roomF};
            Player.Room = Rooms.FirstOrDefault(r => r.Start);
            #endregion
            Doors = new[]
            {
                new Door {A = roomB, B = roomA, color = "Red", open = false},
                new Door {A = roomD, B = roomA, color = "Green", open = false},
                new Door {A = roomC, B = roomB, color = "Grey", open = false},
                new Door {A = roomE, B = roomB, color = "Blue", open = false},
                new Door {A = roomF, B = roomE, color = "White", open = false},
            };
        }

        public string AvailableDoors()
        {
            var room = Player.Room;
            var doorsInRoom = Doors.Where(d => d.A == room || d.B == room);
            var txt = "";
            foreach (var door in doorsInRoom)
            {
                var to = door.A == room ? door.B : door.A;
                txt += door.open ? $"Go to {to.Name}\n" : $"Unlock {door.color}\n";
            }

            return txt;
        }
    }
}
