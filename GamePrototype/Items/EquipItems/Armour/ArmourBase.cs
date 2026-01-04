using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Armour
{
    public abstract class ArmourBase : EquipItem //Класс(абстракция) брони
    {
        /*public Armour(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;*/ //Конструктор
        public ArmourBase(uint defence, uint durability, string name) : base(durability, name)
        {
           Defence = defence;
        }

        public abstract uint Defence { get; set; } //Св-во защита

        public override EquipSlot Slot { get; } //Св-во, переопределяется слот для брони


    }
}
