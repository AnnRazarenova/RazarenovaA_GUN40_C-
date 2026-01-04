using GamePrototype.Units;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems.Armour;
using GamePrototype.Items.EquipItems.Weapon;

namespace GamePrototype.Utils
{
    internal class UnitFactoryDemoEasyLevel : UnitFactoryDemo
    {
        public override Unit CreatePlayer(string name) => CreateEasyPlayer(name);
        public static Unit CreateEasyPlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new MeleeWeapon(15, 15, "Sword"));
            player.AddItemToInventory(new Chestplate(15, 15, "Solid chestplate"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Grindstone"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => CreateEasyGoblinEnemy();
        public static Unit CreateEasyGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
    }
}
