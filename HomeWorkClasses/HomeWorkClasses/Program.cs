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

            Wepon wepon = new Wepon("Gun", 10, 50);

            Console.WriteLine("Название оружия: " + wepon.Name);
            Console.WriteLine("Минимальный урон оружия: " + wepon.MinDamage);
            Console.WriteLine("Максимальный урон оружия: " + wepon.MaxDamage);
            Console.WriteLine("Прочность оружия: " + wepon.Durability);
            Console.WriteLine("Средний урон оружия: " + wepon.GetDamage());



        }
    }

    internal class Wepon
    {
        public string Name { get; }

        public int MinDamage {  get; private set; }

        public int MaxDamage { get; private set; }

        public float Durability { get; }

        public Wepon() : this("Unkown wepon", 1, 10)
        {

        }

        public Wepon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Durability = 1f;
            
            SetDamageParams (MinDamage, MaxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            int f = 1;
            if (minDamage > maxDamage)
            {
                int swap;
                swap = minDamage;
                minDamage = maxDamage;
                maxDamage = swap;

                Console.WriteLine("Некорректные входные данные у оружия: " + Name);
            }
            else
            {
                if (minDamage < 1)
                {
                    minDamage = f;
                    Console.WriteLine($"Форсированная установка минимального значения у оружия: {Name}");
                }
                if (maxDamage <= 1)
                {
                    maxDamage = 10;
                }
            }

            MinDamage = minDamage;
            MaxDamage = maxDamage;

        }

        public int GetDamage()
        {
            return (MaxDamage +  MinDamage)/2;
        }

        //static void Main(string[] args)
        //{
        //    Wepon wepon = new Wepon("Gun", 10, 50);

        //    Console.WriteLine("Название оружия: " + wepon.Name);
        //    Console.WriteLine("Минимальный урон оружия: " + wepon.MinDamage);
        //    Console.WriteLine("Максимальный урон оружия: " + wepon.MaxDamage);
        //    Console.WriteLine("Прочность оружия: " + wepon.Durability);
        //    Console.WriteLine("Средний урон оружия: " + wepon.GetDamage());


        //}
    }

}
