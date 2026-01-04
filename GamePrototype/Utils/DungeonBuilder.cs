using GamePrototype.Dungeon;

namespace GamePrototype.Utils
{
    public abstract class DungeonBuilder
    {
        public abstract DungeonRoom BuildDungeon();
        //{
        //    var enter = new DungeonRoom("Enter");
        //    var monsterRoom = new DungeonRoom("Monster", UnitFactoryDemo.CreateGoblinEnemy());
        //    var emptyRoom = new DungeonRoom("Empty");
        //    var lootRoom = new DungeonRoom("Loot1", new Gold());
        //    var lootWeaponRoom = new DungeonRoom("Loot2", new MeleeWeapon(18, 11, "Exe"));
        //    var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
        //    var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

        //    //enter.TrySetDirection(Direction.Right, monsterRoom);
        //    enter.TrySetDirection(Direction.Left, lootWeaponRoom);
        //    enter.TrySetDirection(Direction.Right, monsterRoom);

        //    monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
        //    monsterRoom.TrySetDirection(Direction.Left, emptyRoom);

        //    lootWeaponRoom.TrySetDirection(Direction.Forward, monsterRoom);

        //    lootRoom.TrySetDirection(Direction.Forward, finalRoom);
        //    lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

        //    return enter;
        //}
    }
}
