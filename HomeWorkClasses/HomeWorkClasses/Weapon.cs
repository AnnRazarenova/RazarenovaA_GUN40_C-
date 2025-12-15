using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWorkClasses
{
    public class Weapon
    {
        public string Name { get; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public int Damage { get; private set; }

        public int AverageDamage { get; }

        public float Durability { get; }
        public Weapon() : this("Unkown weapon", 1, 10)
        {

        }
        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Durability = 1f;

            SetDamageParams(MinDamage, MaxDamage);
            
            Damage = new Interval(MinDamage, MaxDamage).Get;
            AverageDamage = GetDamage();
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

                Console.WriteLine("\r\nIncorrect input data for the weapon: " + Name);
            }
            else
            {
                if (minDamage < 1)
                {
                    minDamage = f;
                    Console.WriteLine($"Forced setting of the minimum value for a weapon: {Name}");
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

    }

}
