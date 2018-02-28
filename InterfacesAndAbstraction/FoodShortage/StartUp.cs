using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        Dictionary<string, IBuyer> rebelsAndCitizens = new Dictionary<string, IBuyer>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] arguments =  Console.ReadLine().Split();

            if (arguments.Length == 3)
            {
                rebelsAndCitizens.Add(arguments[0], new Rebel(arguments[0], int.Parse(arguments[1]), arguments[2]));
            }
            else if (arguments.Length == 4)
            {
                rebelsAndCitizens.Add(arguments[0], new Citizen(arguments[0], int.Parse(arguments[1]), arguments[2], arguments[3]));
            }
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            if (rebelsAndCitizens.ContainsKey(input))
            {
                rebelsAndCitizens[input].BuyFood();
            }
        }

        Console.WriteLine(rebelsAndCitizens.Values.Sum(x => x.Food));
    }
}