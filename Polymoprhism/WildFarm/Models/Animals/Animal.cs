using System.Collections.Generic;
using System;

public abstract class Animal
{
    private string name;
    private string typeName;
    private double weight;
    private int foodEaten;

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.TypeName = this.GetType().Name;
        this.Weight = weight;
        this.FoodEaten = 0;
        this.FoodsThatItEats = new HashSet<Type>();
    }

    protected HashSet<Type> FoodsThatItEats { get; set; }
    protected abstract double WeightGainedByUnitOfFoodEaten { get; }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public string TypeName
    {
        get
        {
            return this.typeName;
        }
        set
        {
            this.typeName = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

    public int FoodEaten
    {
        get
        {
            return this.foodEaten;
        }
        set
        {
            this.foodEaten = value;
        }
    }

    public abstract string MakeSound();

    public virtual string Eat(Food food)
    {
        if (!this.FoodsThatItEats.Contains(food.GetType()))
        {
            return $"{this.TypeName} does not eat {food.GetType().Name}!";
        }
        else
        {
            this.FoodEaten += food.Quatity;
            this.Weight += food.Quatity * this.WeightGainedByUnitOfFoodEaten;
            return null;
        }
    }
}