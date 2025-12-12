using System.Xml.Linq;

namespace HomeWorkClasses
{
    public class Unit
    {
        public string Name { get; }

        private float health;
        public float Health { get => health; }

        public Interval DamageToPlayer { get; }

        public float Armor { get; }

        //#1 #3
        public Unit() : this("Unknown Unit") 
        {
            
        }

        //#2
        public Unit(string name)
        {
            Name = name;
            DamageToPlayer = new Interval(0, 20);
            Armor = 0.6f;
            health = 100f;
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(int value)
        {

            health = Health - value * Armor;

            if (Health <= 0f)
            {
                health = 0f;
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class Weapon
    {
        public string Name { get; }

        //public int MinDamage {  get; private set; }

        //public int MaxDamage { get; private set; }

        public Interval Damage { get; }

        public float Durability { get; }

        public Weapon() : this("Unkown weapon", new Interval(1, 10))
        {

        }

        public Weapon(string name, Interval damage/*int minDamage, int maxDamage*/)
        {
            Name = name;
            //MinDamage = minDamage;
            //MaxDamage = maxDamage;
            Damage = damage;
            Durability = 1f;
            
            //SetDamageParams (MinDamage, MaxDamage);
        }

        //public void SetDamageParams(int minDamage, int maxDamage)
        //{
        //    int f = 1;
        //    if (minDamage > maxDamage)
        //    {
        //        int swap;
        //        swap = minDamage;
        //        minDamage = maxDamage;
        //        maxDamage = swap;

        //        Console.WriteLine("\r\nIncorrect input data for the weapon: " + Name);
        //    }
        //    else
        //    {
        //        if (minDamage < 1)
        //        {
        //            minDamage = f;
        //            Console.WriteLine($"Forced setting of the minimum value for a weapon: {Name}");
        //        }
        //        if (maxDamage <= 1)
        //        {
        //            maxDamage = 10;
        //        }
        //    }

        //    MinDamage = minDamage;
        //    MaxDamage = maxDamage;

        //}

        public /*int*/ Interval GetDamage()
        {
            return Damage/*(MaxDamage +  MinDamage)/2*/;
        }

    }

    public struct Interval
    {
        public int Min { get; }
        public int Max { get; }

        Random random = new Random();

        public int Get { get; set; }

        public Interval(int minValue, int maxValue) 
        {
            if (minValue > maxValue)
            {
                int swap;
                swap = minValue;
                minValue = maxValue;
                maxValue = swap;

                Console.WriteLine("Incorrect input data");
            }
            else
            {
                if (minValue < 0)
                {
                    minValue = 0;
                    Console.WriteLine("Incorrect input data");

                }

                if (maxValue < 0)
                {
                    maxValue = 0;
                    Console.WriteLine("Incorrect input data");
                }

                if (minValue ==  maxValue)
                {
                    maxValue = minValue + 10;
                    Console.WriteLine("Incorrect input data");
                }

                
            }

            Min = minValue; 
            Max = maxValue;

            Get = random.Next(minValue, maxValue);
        } 

    }

    public struct Room
    {
        public Unit Unit;

        public Weapon Weapon;

        public Room(Unit unit, Weapon wepon)
        {
            Unit = unit;
            Weapon = wepon;
        }
    }

    public class Dungeon
    {
        Room[] rooms;

        public Dungeon()
        {
            rooms = new Room[] { 
                new Room(new Unit("Soldier"), new Weapon("Sword", new Interval(10, 17))), 
                new Room(new Unit("Poet"), new Weapon("Lira", new Interval(1, 5))), 
                new Room(new Unit("King"), new Weapon("Magic Sword", new Interval(23, 35))), 
                new Room(new Unit("Wizard"), new Weapon("Staff", new Interval(2, 7))) };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < rooms.Length; i++) // поле типа Room[]
            {
                var room = rooms[i];

                Console.WriteLine();
                Console.WriteLine("Unit of room " + i + ": " + room.Unit.Name);
                Console.WriteLine("Weapon of room " + i + ": " + room.Weapon.Name);
                Console.WriteLine("Weapon damage " + i + ": " + room.Weapon.Damage.Get);
                Console.WriteLine("Health Unit of room " + i + ": " + room.Unit.Health);
                Console.WriteLine("Damage to Unit of room " + i + ": " + room.Unit.DamageToPlayer.Get);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Dungeon dungeon = new Dungeon();
            dungeon.ShowRooms();

            //Console.WriteLine("Player characteristics:");
            //Unit unit = new Unit("Igrok");
            //Console.WriteLine("Player name: " + unit.Name);
            //Console.WriteLine("Player health: " + unit.Health);
            //Console.WriteLine("Player Damage: " + unit.Damage);
            //Console.WriteLine("Player armor: " + unit.Armor);
            //Console.WriteLine("Player health with armor: " + unit.GetRealHealth());
            //Console.WriteLine();

            //Console.WriteLine("Battle: ");
            //while (unit.Health > 0f)
            //{
            //    Console.WriteLine("The player suffered 50 damage");
            //    Console.WriteLine("The player is alive: " + unit.SetDamage(50));
            //    Console.WriteLine("Player health: " + Math.Round(unit.Health));
            //    Console.WriteLine("Player health with armor: " + Math.Round(unit.GetRealHealth()));
            //    Console.WriteLine();
            //}

            //Weapon weapon = new Weapon("Gun", 10, 50);

            //Console.WriteLine("Weapon name: " + weapon.Name);
            //Console.WriteLine("Minimum weapon damage: " + weapon.MinDamage);
            //Console.WriteLine("Maximum weapon damage: " + weapon.MaxDamage);
            //Console.WriteLine("Weapon durability: " + weapon.Durability);
            //Console.WriteLine("Average weapon damage: " + weapon.GetDamage());
            



        
        
        }
    }

}
