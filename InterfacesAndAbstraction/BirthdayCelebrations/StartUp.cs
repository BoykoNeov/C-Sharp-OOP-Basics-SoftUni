using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        List<IBirthdateable> thingsBirthBirthdays = new List<IBirthdateable>();

        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();

            if (arguments[0] == "Citizen")
            {
                thingsBirthBirthdays.Add(new Citizen(arguments[1], int.Parse(arguments[2]), arguments[3], arguments[4]));
            }
            else if (arguments[0] == "Pet")
            {
                thingsBirthBirthdays.Add(new Pet(arguments[1], arguments[2]));
            }
        }

        List<string> birthdaysToPrint = new List<string>();
        string selectedYear = Console.ReadLine();

        foreach (IBirthdateable somethingBorn in thingsBirthBirthdays)
        {
            if (somethingBorn.Birthdate.EndsWith(selectedYear))
            {
                birthdaysToPrint.Add(somethingBorn.Birthdate);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, birthdaysToPrint));
    }
}