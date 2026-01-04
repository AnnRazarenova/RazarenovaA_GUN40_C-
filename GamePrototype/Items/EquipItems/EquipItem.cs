using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class EquipItem : Item //Класс(абстракция) для экипировки(броня, оружие)
    {
        private uint _durability; //Поле прочности(текущей)
        private uint _maxDurability; //Поле прочности(максимум)
        public uint Durability { get => _durability; protected set => _durability = value; } //Св-во, с его помощью следим за прочностью
        public override bool Stackable => false; //Св-во, переопределяем, не стакается

        public abstract EquipSlot Slot { get; } //Св-во, абстрактное

        protected EquipItem(uint maxDurability, string name) : base(name)
        { 
            _maxDurability = maxDurability;
            Durability = _maxDurability;
        } //Конструктор


        public void ReduceDurability(uint delta) =>
            _durability = _durability - delta > 0
            ? _durability - delta //Положительное условие "?"
            : 0;//Отрицательное условие ":"
             

        public void Repair(uint delta) => //Метод для починки предмета(брони, оружия(?))
            _durability = _durability + delta > _maxDurability 
            ? _maxDurability //Положительное условие "?"
            : _durability + delta; //Отрицательное условие ":"
    }
}
