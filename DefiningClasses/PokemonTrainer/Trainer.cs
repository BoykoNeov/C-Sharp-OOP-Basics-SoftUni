using System.Collections.Generic;

public class Trainer
{
    public string Name { get; set; }
    public int Badges { get; set; }
    public HashSet<Pokemon> pokemons = new HashSet<Pokemon>();

    public Trainer()
    {
        this.pokemons = new HashSet<Pokemon>();
    }

    public Trainer(string trainerName) : this()
    {
        this.Name = trainerName;
    }
}