public class Relative
{
    public Relative(string name, string birthdate)
    {
        this.Name = name;
        this.BirthDate = birthdate;
    }

    public string Name { get; set; }
    public string BirthDate { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthDate}";
    }
}