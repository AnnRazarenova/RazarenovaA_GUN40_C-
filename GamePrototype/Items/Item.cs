namespace GamePrototype.Items.EconomicItems
{
    public abstract class Item //Абстрактный класс
    {
        public abstract bool Stackable { get; } //Абстрактное св-во, определяет стакается предмет или нет

        public virtual uint Amount { get; protected set; } //Виртуальное св-во, кол-во предметов в стаке

        public string Name { get; } //Св-во, название предмета

        protected Item(string name) //Конструктор(при создании экземпляра класса)
        {
            Name = name;
            Amount = 1;
        }

        public bool TryStack(Item item) //Метод для проверки и стаканья предметов 
        {
            if (!Stackable)
            {
                return false;
            }
            Amount++;
            return true;
        }
    }
}
