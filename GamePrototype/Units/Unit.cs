using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Units
{
    public abstract class Unit //Абстрактный класс персонажей
    {
        private const int INVENTORY_SIZE = 3; //Размер инвенторя, константа(можно в отдеьный класс или в самом классе(абстракцие))
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        protected Inventory Inventory;
        
        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set => _health = value;
        }

        public uint MaxHealth => _maxHealth;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage) //Конструктор
        {
            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE); //Создаётся новый инвентарь
        }

        public void ApplyDamage(uint damage) //Метод для принятия урона
        {//Сама механика должна быть инкапсулированной
            var damageApplied = CalculateAppliedDamage(damage);//Расчёт в прайват методах, для скрытия расчёта(детали реализации скрыты), разбить метод на несколько действий, либо для переопределения
            if (_health < damageApplied || (_health - damageApplied) <= 0) 
            {
                _health = 0;
            }
            else 
            {
                _health -= damageApplied;
            }
            
            DamageReceiveHandler();
        }

        protected abstract uint CalculateAppliedDamage(uint damage); //Метод, абстрактный, расчёт полученного урона, у игрока и нпс разное
        
        protected virtual void DamageReceiveHandler() { } //Метод, виртуальный, для проверки что будет делать юнит после получения урона
        
        public abstract uint GetUnitDamage(); //Метод, абстрактный, возвращает урон который наносит юнит

        public abstract void HandleCombatComplete(); //Метод, абстрактный, указывает что делает юнит после выхода из боя

        public virtual void AddItemToInventory(Item item) //Метод, виртуальный, добавляем предмет в инвентарь
        {
            if (!Inventory.TryAdd(item)) 
            {
                Console.WriteLine($"Inventory of {Name} is full");
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++) 
            {
                if (!Inventory.TryAdd(unit.Inventory.Items[i])) 
                {
                    //inventory is full
                    return;
                }
            }
        }
    }
}
