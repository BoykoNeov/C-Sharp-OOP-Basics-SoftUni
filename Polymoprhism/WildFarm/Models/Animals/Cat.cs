public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
        this.FoodsThatItEats.Add(typeof(Vegetable));
        this.FoodsThatItEats.Add(typeof(Meat));
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 0.30;
        }
    }

    public override string MakeSound()
    {
        return "Meow";
    }
}