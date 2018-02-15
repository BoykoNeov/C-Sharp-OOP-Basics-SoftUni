using System;

public class Program
{
    public static void Main()
    {
        Shape rectangleToDraw;

        if (Console.ReadLine() == "Rectangle")
        {
            rectangleToDraw = new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }
        else
        {
            rectangleToDraw = new Square(int.Parse(Console.ReadLine()));
        }

        rectangleToDraw.Draw();
    }
}