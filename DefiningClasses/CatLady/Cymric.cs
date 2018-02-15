public class Cymric : Cat
{
    public override string Name { get; set; }
    public double FurLength { get; set; }

    public Cymric() : base()
    {
    }

    private Cymric(string name) : base(name)
    {
    }

    public Cymric(string name, string furLength) : this(name)
    {
        this.FurLength = double.Parse(furLength);
    }

    public override string ToString()
    {
        return ($"{this.GetType().Name} {this.Name} {this.FurLength:f2}");
    }
}