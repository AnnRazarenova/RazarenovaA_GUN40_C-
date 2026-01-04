namespace GamePrototype.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem
    {
        public uint DurabilityRestore => 4; //св-во востановы прочности
        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }    
    }
}
