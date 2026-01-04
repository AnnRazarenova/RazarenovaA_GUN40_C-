using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems.Weapon
{
    internal class MeleeWeapon : WeaponBase
    {
        public override uint Damage { get; set; } //Св-во, урон оружия

        public MeleeWeapon(uint damage, uint durability, string name) : base(damage, durability, name)
        {
            Damage = damage;
        }


        public override EquipSlot Slot => EquipSlot.MeleeWeapon; //Св-во, переопределяется слот для оружия
    }
}
