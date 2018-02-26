public class Tomcat : Cat
{
    public Tomcat(string name, string age) : base(name, age)
    {
        base.Gender = "Male";
    }

    public Tomcat(string name, string age, string gender) : this(name, age)
    {
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}