using System;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] citizenParams = input.Split();

            Citizen newCitizen = new Citizen(citizenParams[0], citizenParams[1], int.Parse(citizenParams[2]));

            Console.WriteLine((newCitizen as IPerson).GetName());
            Console.WriteLine((newCitizen as IResident).GetName());
        }
    }
}