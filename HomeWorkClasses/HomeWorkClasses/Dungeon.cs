using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkClasses
{
    public class Dungeon
    {
        Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[] {
                new Room(new Unit("Soldier", 7, 16), new Weapon("Sword", 10, 17)),
                new Room(new Unit("Poet", 10, 20), new Weapon("Lira", 1, 5)),
                new Room(new Unit("King", 5, 15), new Weapon("Magic Sword", 23, 35)),
                new Room(new Unit("Wizard", 7, 17), new Weapon("Staff", 2, 7)) };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++) 
            {
                var room = rooms[i];

                Console.WriteLine();
                Console.WriteLine("Unit of room " + i + ": " + room.Unit.Name);
                Console.WriteLine("Weapon of room " + i + ": " + room.Weapon.Name);
                Console.WriteLine("Weapon damage " + i + ": " + room.Weapon.Damage);
                Console.WriteLine("Health Unit of room " + i + ": " + room.Unit.Health);
                Console.WriteLine("Damage to Unit of room " + i + ": " + room.Unit.DamageToPlayer);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}
