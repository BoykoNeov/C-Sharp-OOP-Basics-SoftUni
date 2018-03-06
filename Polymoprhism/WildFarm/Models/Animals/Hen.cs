using System.Linq;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        this.FoodsThatItEats = typeof(Food)
        .Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(Food)) && !t.IsAbstract).ToHashSet();
    }

    public override string MakeSound()
    {
        return "Cluck";
    }

    protected override double WeightGainedByUnitOfFoodEaten
    {
        get
        {
            return 0.35;
        }
    }
}