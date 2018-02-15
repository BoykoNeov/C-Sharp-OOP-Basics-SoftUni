using System;

public class Rectangle : Shape
{
    public virtual int Length { get; set; }
    public virtual int Height { get; set; }

    public Rectangle(int length, int height)
    {
        this.Height = height;
        this.Length = length;
    }

    public override void Draw()
    {
        Console.WriteLine($"|{new string('-', this.Length)}|");

        for (int i = 0; i < this.Height - 2; i++)
        {
            Console.WriteLine($"|{new string (' ', this.Length)}|");
        }

        Console.WriteLine($"|{new string('-', this.Length)}|");
    }
}