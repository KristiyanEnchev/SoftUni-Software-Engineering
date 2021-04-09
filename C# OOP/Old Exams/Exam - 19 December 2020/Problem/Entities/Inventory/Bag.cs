using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;
using System.Linq;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            int expectedLoad = item.Weight + Load;
            if (expectedLoad > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items == null)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (!items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }

            var item = items.FirstOrDefault(x => x.GetType().Name == name);

            items.Remove(item);

            return item;
        }
    }
}
