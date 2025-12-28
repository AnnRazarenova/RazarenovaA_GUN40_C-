namespace GamePrototype.Items.EconomicItems
{
    public sealed class HealthPotion : EconomicItem
    {
        public uint HealthRestore => 7; //св-во востановы хп
        public override bool Stackable => false; //Сво-во, переопределяем, не стакается

        public HealthPotion(string name) : base(name) //Конструктор
        {
        }      
    }
}
