using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public abstract class Bag
    {
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            protected set { capacity = value; }
        }

        public List<Item> items;
        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return (IReadOnlyCollection<Item>)this.items;
            }
        }

        public int Load
        {
            get
            {
                if (this.Items.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return this.Items.Sum(i => i.Weight);
                }
            }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new ArgumentException("Bag is full!");
            }
            else
            {
                this.items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item itemToReturn = this.Items.FirstOrDefault(i => i.Name == name);

            if (itemToReturn == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(itemToReturn);
            return itemToReturn;
        }

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        protected Bag()
        {
            this.items = new List<Item>();
        }
    }
}