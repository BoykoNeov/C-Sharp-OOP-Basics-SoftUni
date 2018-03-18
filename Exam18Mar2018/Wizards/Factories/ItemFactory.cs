using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class ItemFactory
    {
        public static Item CreateItem(string name)
        {
            string itemName = name;
            Item newItem = null;

            if (itemName == "HealthPotion")
            {
                newItem = new HealthPotion();
            }
            else if (itemName == "PoisonPotion")
            {
                newItem = new PoisonPotion();
            }
            else if (itemName == "ArmorRepairKit")
            {
                newItem = new ArmorRepairKit();
            }
            else
            {
               // throw new ArgumentException($"Invalid item type \"{itemName}\"!");
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return newItem;
        }
    }
}