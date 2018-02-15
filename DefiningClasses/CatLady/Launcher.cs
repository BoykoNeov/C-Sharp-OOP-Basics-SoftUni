using System;
using System.Collections.Generic;

public class Launcher
{
    public static void Main()
    {
        Dictionary<string, Cat> cats = new Dictionary<string, Cat>();
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] splitedInput = input.Split();
            string catType = splitedInput[0];
            string catName = splitedInput[1];
            string catParam = splitedInput[2];

            try
            {
                Cat currentCat = Activator.CreateInstance(Type.GetType(catType), catName, catParam) as Cat;
                cats[catName] = currentCat;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No such type of cat!");
            }
        }

        string catToPrint = Console.ReadLine();
        Console.WriteLine(cats[catToPrint]);
    }
}