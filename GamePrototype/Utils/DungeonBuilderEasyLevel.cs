using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems.Weapon;
using GamePrototype.Items.EquipItems.Weapon.Weapon;

namespace GamePrototype.Utils
{
    public class DungeonBuilderEasyLevel : DungeonBuilder
    {
        public override DungeonRoom BuildDungeon() => BuildEasyDungeon();
        public static DungeonRoom BuildEasyDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemoEasyLevel.CreateEasyGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootGoldRoom = new DungeonRoom("LootGold", new Gold());
            var lootMeleeWeaponRoom = new DungeonRoom("LootMeleeWeapon", new MeleeWeapon(18, 11, "Exe"));
            var lootRangeWeaponRoom = new DungeonRoom("LootRangeWeapon", new RangeWeapon(13, 11, "Magic fireball"));
            var lootStoneRoom = new DungeonRoom("LootStone", new Grindstone("Grind stone"));
            var lootPotionRoom = new DungeonRoom("LootStone", new HealthPotion("Health potion"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Grind stone 2"));

            //enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);
            enter.TrySetDirection(Direction.Right, monsterRoom);

            emptyRoom.TrySetDirection(Direction.Left, lootRangeWeaponRoom);
            emptyRoom.TrySetDirection(Direction.Forward, lootGoldRoom);

            lootRangeWeaponRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
            lootRangeWeaponRoom.TrySetDirection(Direction.Left, lootPotionRoom);

            lootPotionRoom.TrySetDirection(Direction.Forward, lootMeleeWeaponRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootGoldRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            lootMeleeWeaponRoom.TrySetDirection(Direction.Forward, monsterRoom);

            lootGoldRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
