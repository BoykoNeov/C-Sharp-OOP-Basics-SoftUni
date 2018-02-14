public class Car
{
    public Car() { }

    public Car(string model, int speed)
    {
        this.Model = model;
        this.MaxSpeed = speed;
    }
    public string Model { get; set; }
    public int MaxSpeed { get; set; }

    public override string ToString()
    {
        return $"{this.Model} {this.MaxSpeed}";
    }
}