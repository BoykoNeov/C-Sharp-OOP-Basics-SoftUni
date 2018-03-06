public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion)
        : base(name, weight, livingRegion)
    {
        this.FoodsThatItEats.Add(typeof(Vegetable));
        this.FoodsThatItEats.Add(typeof(Fruit));
    }

    public override string MakeSound()
    {
        return "Squeak";
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 0.10;
        }
    }

    public override string ToString()
    {
        return $"{this.TypeName} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}