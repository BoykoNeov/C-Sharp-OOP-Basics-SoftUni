using System;

public abstract class Cat
{
    public abstract string Name { get; set; }

    public override abstract string ToString();

    public Cat() { }

    public Cat(string name)
    {
        this.Name = name;
    }
}