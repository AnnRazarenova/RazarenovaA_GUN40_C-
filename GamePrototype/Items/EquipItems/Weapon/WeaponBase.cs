using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Weapon
{
    public /*sealed*/ abstract class WeaponBase: EquipItem //Класс(абстракция) оружия
    {
        //public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;  //Конструктор
        public WeaponBase(uint damage, uint durability, string name) : base(durability, name)
        {
            Damage = damage;
        }

        public abstract uint Damage { get; set; } //Св-во, урон оружия

        public override EquipSlot Slot { get; } //Св-во, переопределяется слот для оружия
    }
}
