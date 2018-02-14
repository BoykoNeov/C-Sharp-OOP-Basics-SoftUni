public class Pokemon
{
    public string Name { get; set; }
    public int Health { get; set; }
    public string Element { get; set; }

    public Pokemon() { }
    public Pokemon(string name, int health, string element)
    {
        this.Name = name;
        this.Health = health;
        this.Element = element;
    }
}