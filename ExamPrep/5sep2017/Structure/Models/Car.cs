using System;

public class Car
{
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }
    public Tyre Tyre { get; private set; }

    public double FuelAmount
    {
        get
        {
            return this.fuelAmount;
        }
        private set
        {
            if (value > 160)
            {
                this.fuelAmount = 160;
            }
            else if(value <= 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    public void Refuel(double givenFuel)
    {
        this.FuelAmount += givenFuel; 
    }

    public void BurnFuel(double fuelToBurn)
    {
        this.FuelAmount -= fuelToBurn;
    }

    public virtual void ReplaceTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }
}

//Each car should keep its horsepower(Hp), fuel amount and the type of tyres fit at the moment
//Hp –  an integer
//FuelAmount – a floating-point number
//Tyre - parameter of type Tyre
//The fuel tank’s maximum capacity of each car is 160 liters.Fuel amount cannot become bigger than the tank’s 
//    maximum capacity.If you are given more fuel than needed you should fill up the tank to the maxiumum and nothing else happens.
//If fuel amount drops below 0 liters you should throw an exception and the driver cannot continue the race.