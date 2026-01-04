using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems.Armour;
using GamePrototype.Items.EquipItems.Weapon;
using GamePrototype.Items.EquipItems.Weapon.Weapon;
using GamePrototype.Units;
namespace GamePrototype.Utils
{
    internal class UnitFactoryDemoHardLevel : UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name) => CreateHardPlayer(name);
        public static Unit CreateHardPlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new RangeWeapon(8, 15, "Bowl"));
            player.AddItemToInventory(new Helmet(10, 13, "Magic helmet"));
            //player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => CreateHardGoblinEnemy();
        public static Unit CreateHardGoblinEnemy() => new Goblin(GameConstants.Goblin, 25, 25, 5);
    }
}
