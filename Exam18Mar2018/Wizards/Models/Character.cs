using System;

namespace DungeonsAndCodeWizards
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.Health = BaseHealth;
            this.Armor = BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        private double baseHealth;

        public double BaseHealth
        {
            get { return baseHealth; }
            protected set { baseHealth = value; }
        }

        private double health;

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    this.health = 0;
                }
                else
                {
                    health = value;
                }

                if (health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        private double baseArmor;

        public double BaseArmor
        {
            get { return baseArmor; }
            protected set { baseArmor = value; }
        }

        private double armor;

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value > this.BaseArmor)
                {
                    armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        private double abilityPoints;

        public double AbilityPoints
        {
            get { return abilityPoints; }
            protected set { abilityPoints = value; }
        }

        private Bag bag;

        public Bag Bag
        {
            get { return bag; }
            protected set { bag = value; }
        }

        private Faction faction;

        public Faction Faction
        {
            get { return faction; }
            protected set { faction = value; }
        }

        public virtual double RestHealMultiplier { get => 0.2; }

        public void CheckIsAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

       public void TakeDamage(double hitPoints)
        {
            CheckIsAlive();

            double remainingHitPoints = 0;

            if (this.Armor <= hitPoints)
            {
                remainingHitPoints = hitPoints - this.Armor;
                this.Armor = 0;

                this.Health -= remainingHitPoints;
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

       public void Rest()
        {
            CheckIsAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

       public void UseItem(Item item)
        {
            CheckIsAlive();

            item.AffectCharacter(this);
        }

       public void UseItemOn(Item item, Character character)
        {
            CheckIsAlive();
            character.CheckIsAlive();

            item.AffectCharacter(character);
        }

       public void GiveCharacterItem(Item item, Character character)
        {
            CheckIsAlive();
            character.CheckIsAlive();

            character.ReceiveItem(item);
        }
        //For a character to give another character an item, both of them need to be alive.
        //The targeted character receives the item.

       public void ReceiveItem(Item item)
        {
            CheckIsAlive();
            this.Bag.AddItem(item);
        }
        //For a character to receive an item, they need to be alive.
        //The character puts the item into their bag.
    }
}