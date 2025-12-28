using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Weapon : EquipItem //Класс(абстракция) оружия
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage; //Конструктор

        public uint Damage { get; } //Св-во, урон оружия

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
