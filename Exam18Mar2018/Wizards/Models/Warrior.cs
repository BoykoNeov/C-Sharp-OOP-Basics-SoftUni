using System;

namespace DungeonsAndCodeWizards
{
    public class Warrior : Character, IAttackable
    {
        // The Warrior class always has 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, new Satchel(), faction)
        {
            this.Name = name;
            this.Faction = faction;
        }

        public void Attack(Character character)
        {
            this.CheckIsAlive();
            character.CheckIsAlive();

            if (character.Equals(this))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}