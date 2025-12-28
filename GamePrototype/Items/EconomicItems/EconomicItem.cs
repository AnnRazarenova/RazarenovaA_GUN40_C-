namespace GamePrototype.Items.EconomicItems
{
    public abstract class EconomicItem : Item //Класс(абстракция) для экономических (зелье, золото, тач. камень)
    {
        protected EconomicItem(string name) : base(name)
        {
            //Коструктор
        }
    }
}
