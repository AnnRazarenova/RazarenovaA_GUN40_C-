using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Dungeon
{
    public sealed class DungeonRoom
    {      
        public readonly string Name; //Поля класса(св-во?) Имя комнаты
        public readonly Unit Enemy; //Враг
        public readonly Item Loot; //Лут
        public readonly Dictionary<Direction, DungeonRoom> Rooms = new(); //Словарь комнат
        public bool IsFinal => Rooms.Count == 0;

        public DungeonRoom(string name) => Name = name; //Конструктор для "Ничего"

        public DungeonRoom(string name, Unit enemy) //Конструктор для "С врагом"
        {
            Name = name;
            Enemy = enemy;
        }

        public DungeonRoom(string name, Item item) //Конструктор для "С лутом"
        {
            Name = name;
            Loot = item;
        }

        public bool TrySetDirection(Direction direction, DungeonRoom room) //Задаём направления
        {
            if (Rooms.ContainsKey(direction)) //Если она существует, то ошибка
            {
                Console.WriteLine($"Room {Name} already has room for {direction.ToString()}");
                return false;
            }
            Rooms.Add(direction, room); //Добавляем комнату
            return true;
        }
    }
}
