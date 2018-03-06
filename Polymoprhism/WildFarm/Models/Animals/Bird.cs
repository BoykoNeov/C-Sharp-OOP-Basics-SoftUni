public abstract class Bird : Animal
{
    double WingSize { get; set; }

    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.WingSize = wingSize;
    }

    public sealed override string ToString()
    {
        return $"{this.TypeName} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}