public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.FoodsThatItEats.Add(typeof(Meat));
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 0.25;
        }
    }

    public override string MakeSound()
    {
       return "Hoot Hoot";
    }
}