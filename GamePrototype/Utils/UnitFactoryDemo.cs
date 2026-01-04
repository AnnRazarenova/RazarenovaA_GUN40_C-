using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Armour;
using GamePrototype.Items.EquipItems.Weapon;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class UnitFactoryDemo
    {
        public abstract Unit CreatePlayer(string name);
        //{
        //    var player = new Player(name, 30, 30, 6);
        //    player.AddItemToInventory(new MeleeWeapon(15, 15, "Sword"));
        //    player.AddItemToInventory(new Helmet(10, 15, "Armour"));
        //    player.AddItemToInventory(new HealthPotion("Potion"));
        //    return player;
        //}

        public abstract Unit CreateGoblinEnemy()/* => new Goblin(GameConstants.Goblin, 18, 18, 2)*/;
    }
}
