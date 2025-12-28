namespace GamePrototype.Units
{
    public sealed class Goblin : Unit
    {
        public Goblin(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage) //Конструктор
        {
        }

        public override uint GetUnitDamage() => BaseDamage; //Метод, переопределяется, возвращает базовый урон

        public override void HandleCombatComplete() => Health = MaxHealth; //Метод, переопределяется, если вышел победителем, востанавливаем хп нпс

        protected override uint CalculateAppliedDamage(uint damage) => damage; //Метод, переопределяется, возвращает урон по нпс(брони нет)
    }
}
