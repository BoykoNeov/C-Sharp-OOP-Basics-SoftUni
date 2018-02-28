using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<IIdable> immigrants = new List<IIdable>();

        string input = string.Empty;

        while((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();

            if (arguments.Length == 2)
            {
                immigrants.Add(new Robot(arguments[0], arguments[1]));
            }
            else if (arguments.Length == 3)
            {
                immigrants.Add(new Citizen(arguments[0], int.Parse(arguments[1]), arguments[2]));
            }
        }

        string endingNumber = Console.ReadLine();

        List<string> restrictedEntryIds = new List<string>();

        foreach (IIdable immigrant in immigrants)
        {
            if (immigrant.Id.EndsWith(endingNumber))
            {
                restrictedEntryIds.Add(immigrant.Id);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, restrictedEntryIds));
    }
}