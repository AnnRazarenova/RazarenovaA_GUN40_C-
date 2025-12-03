namespace HomeWorkClasses
{
    internal class Unit
    {

        public string Name { get; }

        private float health;
        public float Health { get => health; }

        public int Damage { get; }

        public float Armor { get; }

        //#1 #3
        public Unit() : this("Unknown Unit") 
        {
            
        }

        //#2
        public Unit(string name)
        {
            Name = name;
            Damage = 5;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Характеристики игрока:");
            Unit unit = new Unit("Igrok");
            Console.WriteLine("Имя игрока: " + unit.Name);
            Console.WriteLine("Здоровье игрока: " + unit.Health);
            Console.WriteLine("Урон игрока: " + unit.Damage);
            Console.WriteLine("Броня игрока: " + unit.Armor);
            Console.WriteLine("Здоровье игрока с бронёй: " + unit.GetRealHealth());
            Console.WriteLine();

            Console.WriteLine("Битва: ");
            while (unit.Health > 0f)
            {
                Console.WriteLine("Игроку нанесён урон в 50 единиц");
                Console.WriteLine("Игрок жив: " + unit.SetDamage(50));
                Console.WriteLine("Здоровье игрока: " + Math.Round(unit.Health));
                Console.WriteLine("Здоровье игрока с бронёй: " + Math.Round(unit.GetRealHealth()));
                Console.WriteLine();
            }

            //Console.WriteLine("Игроку нанесён урон в 50 единиц");
            //Console.WriteLine("Игрок жив: " + unit.SetDamage(50));
            //Console.WriteLine("Здоровье игрока: " + unit.Health);
            //Console.WriteLine("Здоровье игрока с бронёй: " + unit.GetRealHealth());
            //Console.WriteLine();

            //Console.WriteLine("Игроку нанесён урон в 50 единиц");
            //Console.WriteLine("Игрок жив: " + unit.SetDamage(50));
            //Console.WriteLine("Здоровье игрока: " + unit.Health);
            //Console.WriteLine("Здоровье игрока с бронёй: " + unit.GetRealHealth());
            //Console.WriteLine();

            //Console.WriteLine("Игроку нанесён урон в 50 единиц");
            //Console.WriteLine("Игрок жив: " + unit.SetDamage(50));
            //Console.WriteLine("Здоровье игрока: " + unit.Health);
            //Console.WriteLine("Здоровье игрока с бронёй: " + unit.GetRealHealth());
            //Console.WriteLine();

        }
    }
}
