public class StreetExtraordinaire : Cat
{
    public override string Name { get; set; }
    public int DecibelsOfMeows { get; set; }

    public StreetExtraordinaire() : base()
    {
    }

    private StreetExtraordinaire(string name) : base(name)
    {
    }

    public StreetExtraordinaire(string name, string decibelsOfMeows) : this(name)
    {
        this.DecibelsOfMeows = int.Parse(decibelsOfMeows);
    }

    public override string ToString()
    {
        return (this.GetType().Name + " " + this.Name + " " + this.DecibelsOfMeows);
    }
}