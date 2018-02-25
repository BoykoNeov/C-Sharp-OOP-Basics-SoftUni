using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    private List<Topping> Toppings;

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public void AddToping(Topping topping)
    {
        this.Toppings.Add(topping);

        if (this.Toppings.Count > 10)
        {
            throw new InvalidOperationException("Number of toppings should be in range [0..10].");
        }

    }

    public double CalcTotalCalories()
    {
        double sum = 0;
        sum += this.dough.CalcDoughCalories();

        foreach (Topping topping in this.Toppings)
        {
            sum += topping.CalcToppingCalories();
        }

        return sum;
    }
}