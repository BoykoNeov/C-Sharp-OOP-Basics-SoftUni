namespace DungeonsAndCodeWizards
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
        {
            this.Weight = 10;
            this.Name = "ArmorRepairKit";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Armor = character.BaseArmor;
        }
    }
}