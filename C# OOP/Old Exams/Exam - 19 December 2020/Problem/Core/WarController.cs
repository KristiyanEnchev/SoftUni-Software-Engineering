using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> champions;
        private List<Item> items;
       // private List<IAttacker> warriors;
        //private List<IHealer> priests;

        public WarController()
        {
            champions = new List<Character>();
            //warriors = new List<IAttacker>();
            //priests = new List<IHealer>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character champion = null;

            if (characterType == "Warrior")
            {
                champion = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                champion = new Priest(name);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }

            champions.Add(champion);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;

            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }

            items.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!champions.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            var champion = champions.FirstOrDefault(x => x.Name == characterName);

            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = items[items.Count - 1];

            champion.Bag.AddItem(item);
            items.RemoveAt(items.Count - 1);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!champions.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            var champion = champions.FirstOrDefault(x => x.Name == characterName);
            var item = champion.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

            champion.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);

        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var champ in champions.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList())
            {
                string status = string.Empty;
                if (champ.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }

                sb.AppendLine($"{champ.Name} - HP: {champ.Health}/{champ.BaseHealth}, AP: {champ.Armor}/{champ.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            //var attChamp = champions.FirstOrDefault(x => x.Name == attackerName);
            //IAttacker atttchamp = champions.FirstOrDefault(x => x.);
            //var recieverChamp = champions.FirstOrDefault(x => x.Name == receiverName);

            if (!champions.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }
            else if (!champions.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
            }

            var attChamp = champions.FirstOrDefault(x => x.Name == attackerName);

            if (attChamp.GetType().Name != "Warrior")
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attChamp.Name);
            }

            Warrior ataker = (Warrior)attChamp;
            var recieverChamp = champions.FirstOrDefault(x => x.Name == receiverName);

            ataker.Attack(recieverChamp);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attChamp.AbilityPoints} hit points! {receiverName} has {recieverChamp.Health}/{recieverChamp.BaseHealth} HP and {recieverChamp.Armor}/{recieverChamp.BaseArmor} AP left!");

            if (!recieverChamp.IsAlive)
            {
                sb.AppendLine($"{recieverChamp.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!champions.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }
            if (!champions.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
            }
            Character healer = champions.FirstOrDefault(x => x.Name == healerName);
            Character receiver = champions.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer.GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            Priest priest = (Priest)healer;
            priest.Heal(receiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
        }
    }
}
