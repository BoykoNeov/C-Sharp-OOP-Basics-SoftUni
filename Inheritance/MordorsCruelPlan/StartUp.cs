using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        // Split by whitespace
        string[] foodNames = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        List<Food> foods = new List<Food>();

        foreach (string foodName in foodNames)
        {
            char[] currentFoodName = foodName.ToLower().ToCharArray();
            currentFoodName[0] = char.ToUpper(currentFoodName[0]);

            foods.Add(FoodFactory.CreateFood(new string(currentFoodName)));
        }

        int happinessLevel = 0;

        foreach (Food food in foods)
        {
            happinessLevel += food.Happiness;
        }

        Console.WriteLine(happinessLevel);
        Console.WriteLine(MoodFactory.CreateMood(happinessLevel));
    }
}