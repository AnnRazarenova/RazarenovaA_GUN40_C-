using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems.Armour
{
    internal class Helmet : ArmourBase
    {
        public override uint Defence { get; set; } //Св-во защита
        public Helmet(uint defence, uint durability, string name) : base(defence, durability, name)
        {
            Defence = defence;
        }

        

        public override EquipSlot Slot => EquipSlot.Helmet; //Св-во, переопределяется слот для брони

    }
}
