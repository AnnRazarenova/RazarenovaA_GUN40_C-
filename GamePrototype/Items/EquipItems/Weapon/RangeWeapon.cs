using GamePrototype.Utils;
namespace GamePrototype.Items.EquipItems.Weapon.Weapon
{
    public sealed class RangeWeapon : WeaponBase
    {
        public override uint Damage { get; set; } //Св-во, урон оружия

        public RangeWeapon(uint damage, uint durability, string name) : base(damage, durability, name)
        {
            Damage = damage;
            //Console.WriteLine($"Name: {name}, Damage: {damage}, Durability: {durability}");
        }


        public override EquipSlot Slot => EquipSlot.RangeWeapon; //Св-во, переопределяется слот для оружия
    }
}
