public class Citizen : IPerson, IBirthable, IIdentifiable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Id { get; set; }
    public string Birthdate { get; set; }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public Citizen(string name, int age, string id, string birthdate) : this(name, age)
    {
        Id = id;
        this.Birthdate = birthdate;
    }
}