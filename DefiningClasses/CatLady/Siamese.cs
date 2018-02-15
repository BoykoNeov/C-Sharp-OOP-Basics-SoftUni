public class Siamese : Cat
{
    public override string Name { get; set; }
    public int EarSize { get; set; }

    public Siamese() : base()
    {
    }

    private Siamese(string name) : base(name)
    {
    }

    public Siamese(string name, string earSize) : this(name)
    {
        this.EarSize = int.Parse(earSize);
    }

    public override string ToString()
    {
        return(this.GetType().Name + " " + this.Name + " " + this.EarSize);
    }
}