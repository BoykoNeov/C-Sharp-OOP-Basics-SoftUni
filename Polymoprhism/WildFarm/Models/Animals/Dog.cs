public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        this.FoodsThatItEats.Add(typeof(Meat));
    }

    public override string MakeSound()
    {
        return "Woof!";
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 0.40;
        }
    }

    public override string ToString()
    {
        return $"{this.TypeName} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}