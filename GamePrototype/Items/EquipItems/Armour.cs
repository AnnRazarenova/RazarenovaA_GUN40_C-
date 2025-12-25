using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Armour : EquipItem //Класс(абстракция) брони
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence; //Конструктор

        public uint Defence { get; } //Св-во защита

        public override EquipSlot Slot => EquipSlot.Armour;
    }
}
