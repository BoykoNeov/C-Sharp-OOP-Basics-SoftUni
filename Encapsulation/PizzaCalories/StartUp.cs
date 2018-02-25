using System;

public class Launcher
{
    public static void Main()
    {
        string input = string.Empty;
        Pizza currentPizza = null;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] args = input.Split();

            if (args[0].Equals("Dough"))
            {
                try
                {
                    Dough dough = new Dough(args[1], args[2], double.Parse(args[3]));

                    if (currentPizza == null)
                    {
                        Console.WriteLine($"{dough.CalcDoughCalories():f2}");
                    }
                    else
                    {
                        currentPizza.Dough = dough;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            else if (args[0].Equals("Topping"))
            {
                try
                {
                    Topping topping = new Topping(args[1], double.Parse(args[2]));

                    if (currentPizza == null)
                    {
                        Console.WriteLine($"{topping.CalcToppingCalories():f2}");
                    }
                    else
                    {
                        currentPizza.AddToping(topping);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            else if (args[0].Equals("Pizza"))
            {
                try
                {
                    Pizza pizza = new Pizza(args[1]);
                    currentPizza = pizza;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }

        if (currentPizza != null)
        {
            Console.WriteLine($"{currentPizza.Name} - {currentPizza.CalcTotalCalories():f2} Calories.");
        }
    }
}