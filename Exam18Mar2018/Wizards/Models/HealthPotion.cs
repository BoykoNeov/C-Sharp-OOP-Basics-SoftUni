namespace DungeonsAndCodeWizards
{
    public class HealthPotion : Item
    {
        //protected HealthPotion(int weight) : base(weight)
        //{
        //    this.Weight = 5;
        //}

        public HealthPotion()
        {
            this.Weight = 5;
            this.Name = "HealthPotion";
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;
        }
    }
}