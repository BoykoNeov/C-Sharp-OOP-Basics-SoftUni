using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rectanglesCount = inputs[0];
        int checksCount = inputs[1];

        Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();

        for (int i = 0; i < rectanglesCount; i++)
        {
            string[] coordinates = Console.ReadLine().Split();
            Rectangle currentRectangle = new Rectangle(coordinates[0], double.Parse(coordinates[1]), double.Parse(coordinates[2]), double.Parse(coordinates[3]), double.Parse(coordinates[4]));
            rectangles[currentRectangle.Id] = currentRectangle;
        }

        for (int i = 0; i < checksCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            Rectangle r1 = rectangles[input[0]];
            Rectangle r2 = rectangles[input[1]];
            Console.WriteLine(r1.DoIntersectWith(r2).ToString().ToLower());
        }
    }
}