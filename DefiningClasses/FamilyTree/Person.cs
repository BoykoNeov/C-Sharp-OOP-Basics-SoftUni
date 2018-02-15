using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public Person(string firstName, string lastName, string date) :this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.BirthDate = date;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthDate { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.FirstName} {this.LastName} {this.BirthDate}");
        sb.AppendLine("Parents:");

        foreach (var parent in this.Parents)
        {
            sb.AppendLine($"{parent.FirstName} {parent.LastName} {parent.BirthDate}");

        }

        sb.AppendLine("Children:");

        foreach (var child in this.Children)
        {
            sb.AppendLine($"{child.FirstName} {child.LastName} {child.BirthDate}");

        }

        return sb.ToString();
    }
}