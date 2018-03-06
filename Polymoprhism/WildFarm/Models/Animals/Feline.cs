public abstract class Feline : Mammal
{
    public virtual string Breed { get; set; }

    public Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public sealed override string ToString()
    {
        return $"{this.TypeName} [{this.Name}, {this.Breed}, {this.Weight}, {LivingRegion}, {this.FoodEaten}]";
    }
}