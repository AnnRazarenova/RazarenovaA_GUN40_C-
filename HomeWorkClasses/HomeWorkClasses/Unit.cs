using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkClasses
{
    public class Unit
    {
        public string Name { get; }

        private float health;
        public float Health { get => health; }

        public int DamageToPlayer { get; }

        public float Armor { get; }

        //#1 #3
        public Unit() : this("Unknown Unit")
        {

        }

        //#2
        public Unit(string name)
        {
            Name = name;
            DamageToPlayer = 5;
            Armor = 0.6f;
            health = 100f;
        }

        public Unit(string name, int min, int max)
        {
            Name = name;
            DamageToPlayer = new Interval(min, max).Get;
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
}
