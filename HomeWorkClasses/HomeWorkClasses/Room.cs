using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkClasses
{
    public struct Room
    {
        public Unit Unit { get; }

        public Weapon Weapon { get; }

        public Room(Unit unit, Weapon wepon)
        {
            Unit = unit;
            Weapon = wepon;
        }
    }

}
