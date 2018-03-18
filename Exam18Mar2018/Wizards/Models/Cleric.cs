using System;

namespace DungeonsAndCodeWizards
{
    public class Cleric : Character, IHealable
    {
        // 50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.
        // The cleric’s RestHealMultiplier is 0.5.

        public Cleric(string name, Faction faction) : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckIsAlive();
            character.CheckIsAlive();

            if (!this.Faction.Equals(character.Faction))
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
