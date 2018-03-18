namespace DungeonsAndCodeWizards
{
    public class PoisonPotion : Item
    {
       public PoisonPotion()
        {
            this.Weight = 5;
            this.Name = "PoisonPotion";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;
        }
    }
}