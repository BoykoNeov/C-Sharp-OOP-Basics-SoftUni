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

    public Siamese(string name, int earSize) : this(name)
    {
        this.EarSize = earSize;
    }

    public override string ToString()
    {
        return(this.GetType().Name + " " + this.Name + " " + this.EarSize);
    }
}