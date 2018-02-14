public class Person
{
    private string name;
    private int age;

   public Person()
    {
        this.Age = 1;
        this.Name = "No name";
    }

   public Person(int age) : this()
    {
        this.Age = age;
    }

   public Person(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }
}