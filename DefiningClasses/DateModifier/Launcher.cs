using System;

public class Launcher
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        DateModifier dateModifier = new DateModifier();
        dateModifier.CalculateDateDifference(firstDate, secondDate);
        Console.WriteLine(dateModifier.DateDifference);
    }
}