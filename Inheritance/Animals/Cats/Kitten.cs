public class Kitten : Cat
{
    public Kitten(string name, string age) : base(name, age)
    {
        base.Gender = "Female";
    }

    public Kitten(string name, string age, string gender) : this(name, age)
    {
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}