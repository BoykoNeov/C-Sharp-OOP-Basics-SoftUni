public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
        this.FoodsThatItEats.Add(typeof(Meat));
    }

    public override string MakeSound()
    {
        return "ROAR!!!";
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 1;
        }
    }
}