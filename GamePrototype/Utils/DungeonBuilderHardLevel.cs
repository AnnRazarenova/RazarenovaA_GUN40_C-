using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems.Weapon;
using GamePrototype.Items.EquipItems.Weapon.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Utils
{
    public class DungeonBuilderHardLevel : DungeonBuilder
    {

        public override DungeonRoom BuildDungeon() => BuildHardDungeon();
        public static DungeonRoom BuildHardDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemoHardLevel.CreateHardGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootGoldRoom = new DungeonRoom("LootGold", new Gold());
            var lootMeleeWeaponRoom = new DungeonRoom("LootMeleeWeapon", new MeleeWeapon(5, 15, "Knife"));
            var lootRangeWeaponRoom = new DungeonRoom("LootRangeWeapon", new RangeWeapon(10, 11, "Magic staff"));
            var lootStoneRoom = new DungeonRoom("LootGrindstone", new Grindstone("Stone"));
            var finalRoom = new DungeonRoom("Final", new HealthPotion("Health potion"));

            //enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, lootMeleeWeaponRoom);
            enter.TrySetDirection(Direction.Right, monsterRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootGoldRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

            emptyRoom.TrySetDirection(Direction.Forward, lootRangeWeaponRoom);
            emptyRoom.TrySetDirection(Direction.Left, monsterRoom);


            lootMeleeWeaponRoom.TrySetDirection(Direction.Forward, monsterRoom);
            lootMeleeWeaponRoom.TrySetDirection(Direction.Forward, lootStoneRoom);

            lootRangeWeaponRoom.TrySetDirection(Direction.Left, emptyRoom);
            lootRangeWeaponRoom.TrySetDirection(Direction.Right, monsterRoom);


            lootGoldRoom.TrySetDirection(Direction.Forward, finalRoom);

            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
