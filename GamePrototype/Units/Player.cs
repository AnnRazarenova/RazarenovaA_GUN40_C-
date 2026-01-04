using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Armour;
using GamePrototype.Items.EquipItems.Weapon;
using GamePrototype.Items.EquipItems.Weapon.Weapon;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new(); //Словарь, какие предметы есть

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {
            
            Console.WriteLine($"Name: {name}, health: {maxHealth},  damage: {baseDamage}");
        }

        public override uint GetUnitDamage() //Метод, переопределён, возвращает урон игрока, базовый + оружие или базовый
        {
            uint totalDamage = 0;
            
            if (_equipment.TryGetValue(EquipSlot.MeleeWeapon, out var meleeItem) && meleeItem is WeaponBase meleeWeapon) //Получаем из инвенторя оружие
            {
                totalDamage = CalculateUnitDamage(meleeWeapon);
            }
            else
                if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var rangeItem) && rangeItem is WeaponBase rangeWeapon)
            {
                totalDamage = CalculateUnitDamage(rangeWeapon);
            }
                return totalDamage;
        }

        public uint CalculateUnitDamage(WeaponBase weapon)
        {
            uint totalDamage = BaseDamage;

            Console.WriteLine($"Weapon name: {weapon.Name}");

            if (weapon.Durability > 0)
            {
                weapon.ReduceDurability(1); //Оружие теряет пункт прочности(иначе нет смысла использовать точильный камень)\
                Console.WriteLine($"Weapon new durability: {weapon.Durability}");
                totalDamage = BaseDamage + weapon.Damage;
            }
            if (weapon.Durability <= 0) //Именно if чтобы сразу убирать сломанное оружие после ReduceDurability
            {
                Console.WriteLine($"{weapon.Name} сломалось!");
                RemoveItemFromInventory(weapon);
            }
            return totalDamage;
        }

        public override void HandleCombatComplete()//Метод, прееопределяется, если вышли из боя(победа), используем например зелье на хп
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item newItem)//Метод, переопределяется, добавление предмета в инвентарь(если можно добавить)
        {
            if (newItem is EquipItem newEquipItem)
            {
                // Item was equipped

                if (_equipment.TryAdd(newEquipItem.Slot, newEquipItem))
                {
                    Console.WriteLine($"You have got {newEquipItem.Name}");
                    return;
                }
                else
                    ChangeEquipedItemInInventory(newEquipItem);
                
            }
            
                base.AddItemToInventory(newItem);//базовая реализация
        }

        public void ChangeEquipedItemInInventory(EquipItem newEquipItem)//Метод, переопределяется, добавление предмета в инвентарь(если можно добавить)
        {
            EquipItem currentItem = _equipment[newEquipItem.Slot];

            Console.WriteLine($"You found: {newEquipItem.Name}, your current item: {currentItem.Name}");

            ShowDifference(newEquipItem, currentItem);

            Console.WriteLine($"Do you want to change your {currentItem.Name} to {newEquipItem.Name}");

            string answer = Console.ReadLine()?.Trim().ToLower();

            if ((answer == "yes" || answer == "y") && _equipment.Remove(currentItem.Slot) && _equipment.TryAdd(newEquipItem.Slot, newEquipItem))
            {
                //Поменяли предметы
                Console.WriteLine($"You have changed {currentItem.Name} to {newEquipItem.Name}");

                return;
            }
            else
                Console.WriteLine($"Inventory of {Name} has not changed");//базовая реализация
        }

        public void ShowDifference(EquipItem newEquipItem, EquipItem currentEquipItem)//метод показывает разницу нового(найденного) оружия со старым
        {
            if (newEquipItem is MeleeWeapon newMeleeWeapon && currentEquipItem is MeleeWeapon currentMeleeWeapon)
            {
                Console.WriteLine($"{newMeleeWeapon.Name}'s damage: {newMeleeWeapon.Damage}," +
                    $" {currentMeleeWeapon.Name}'s damage: {currentMeleeWeapon.Damage}");
                Console.WriteLine($"{newMeleeWeapon.Name}'s durability: {newMeleeWeapon.Durability}," +
                    $" {currentMeleeWeapon.Name}'s durability: {currentMeleeWeapon.Durability}");
            }
            if (newEquipItem is RangeWeapon newRangeWeapon && currentEquipItem is RangeWeapon currentRangeWeapon)
            {
                Console.WriteLine($"{newRangeWeapon.Name}'s damage: {newRangeWeapon.Damage}," +
                    $" {currentRangeWeapon.Name}'s damage: {currentRangeWeapon.Damage}");
                Console.WriteLine($"{newRangeWeapon.Name}'s durability: {newRangeWeapon.Durability}," +
                    $" {currentRangeWeapon.Name}'s durability: {currentRangeWeapon.Durability}");
            }
            if (newEquipItem is Helmet newHelmet && currentEquipItem is Helmet currentHelmet) 
            {
                Console.WriteLine($"{newHelmet.Name}'s defence: {newHelmet.Defence}," +
                    $" {currentHelmet.Name}'s defence: {currentHelmet.Defence}");
                Console.WriteLine($"{newHelmet.Name}'s damage: {newHelmet.Durability}," +
                    $" {currentHelmet.Name}'s damage: {currentHelmet.Durability}");
            }
            if (newEquipItem is Chestplate newChestplate && currentEquipItem is Chestplate currentChestplate)
            {
                Console.WriteLine($"{newChestplate.Name}'s defence: {newChestplate.Defence}," +
                    $" {currentChestplate.Name}'s defence: {currentChestplate.Defence}");
                Console.WriteLine($"{newChestplate.Name}'s damage: {newChestplate.Durability}," +
                    $" {currentChestplate.Name}'s damage: {currentChestplate.Durability}");
            }
        }

        public override void RemoveItemFromInventory(Item item)//Метод, переопределяется, добавление предмета в инвентарь(если можно добавить)
        {
            if (item is EquipItem equipItem && _equipment.Remove(equipItem.Slot))
            {
                // Item was equipped
                return;
            }
            base.RemoveItemFromInventory(item);//базовая реализация
        }

        private void UseEconomicItem(EconomicItem economicItem)//Метод для использования зелья здоровья
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                if (Health < MaxHealth)
                {
                    Health += healthPotion.HealthRestore;//сделать ограничения по макс хп
                }
                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
            }
              
            WeaponBase weapon = ChooseWeapon();

            if (economicItem is Grindstone grindstoneMelee && _equipment.TryGetValue(EquipSlot.MeleeWeapon, out var meleeItem) && meleeItem is WeaponBase weaponMelee)
            {
                weaponMelee.Repair(grindstoneMelee.DurabilityRestore);
            }
        }

        private WeaponBase ChooseWeapon()
        {
            if (_equipment.TryGetValue(EquipSlot.MeleeWeapon, out var meleeItem) && meleeItem is WeaponBase weaponMelee)
            {
                return weaponMelee;
            }
            else
                if (_equipment.TryGetValue(EquipSlot.RangeWeapon, out var rangeItem) && rangeItem is WeaponBase weaponRange)
            {
                return weaponRange;
            }
            return null;
        }

        protected override uint CalculateAppliedDamage(uint damage)//Метод, переопределяется, расчёт урона по игроку
        {
            uint totalDefence = 0;

            //Знаю, что этот вариант кода не очень хороший, т.к. брони может быть много и для каждой новой дописывать код неудобно
            //не смогла придумать как перебирать всю броню не прибегая к чётким названиям брони
            //только если разделять EquipSlot на 2 вида: броня и оружие(ArmourSlot и WeaponSlot) и тогда может получится перебор всей имеющейся брони осуществить
            if (_equipment.TryGetValue(EquipSlot.Helmet, out var item1) && item1 is ArmourBase helmet) 
            {
                totalDefence += helmet.Defence;

                helmet.ReduceDurability(1); //Теряет 1 пункт прочности, set Durability теперь не протектид
                Console.WriteLine($"Armour durability: {helmet.Durability}");
            }
            if (_equipment.TryGetValue(EquipSlot.Chestplate, out var item2) && item2 is ArmourBase chestplate)
            {
                totalDefence += chestplate.Defence;

                chestplate.ReduceDurability(1); //Теряет 1 пункт прочности, set Durability теперь не протектид
                Console.WriteLine($"Armour durability: {chestplate.Durability}");
            }
            
            damage -= (uint)(damage * (totalDefence / 100f));
            
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
