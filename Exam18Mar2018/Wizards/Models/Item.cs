namespace DungeonsAndCodeWizards
{
    public abstract class Item
    {
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            protected set { this.name = value; }
        }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        protected Item()
        {

        }

        public virtual void AffectCharacter(Character character)
        {
           character.CheckIsAlive();     
        }
    }
}