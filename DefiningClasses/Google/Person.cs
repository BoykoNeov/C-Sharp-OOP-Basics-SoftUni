using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Company = new Company();
        this.Car = new Car();
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Relative>();
        this.Children = new List<Relative>();
    }

    public string Name { get; set; }
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Relative> Parents { get; set; }
    public List<Relative> Children { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.Name);
        sb.AppendLine($"Company:");
        if (this.Company.Name != null)
        {
            sb.AppendLine(this.Company.ToString());
        }

        sb.AppendLine($"Car:");

        if (this.Car.Model != null)
        {
            sb.AppendLine(this.Car.ToString());
        }

        sb.AppendLine($"Pokemon:");
        foreach (var pokemon in this.Pokemons)
        {
            sb.AppendLine(pokemon.ToString());
        }

        sb.AppendLine($"Parents:");
        foreach (var parent in this.Parents)
        {
            sb.AppendLine(parent.ToString());
        }

        sb.AppendLine($"Children:");
        foreach (var child in this.Children)
        {
            sb.AppendLine(child.ToString());
        }

        return sb.ToString().Trim();
    }
}