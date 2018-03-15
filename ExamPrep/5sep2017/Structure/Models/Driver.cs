using System;

public abstract class Driver
{
    private Car car;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.FailureReason = null;
        this.ParticipatedInOvertakingInCurrentRound = false;
    }

    public Car Car
    {
        get { return this.car; }

        private set
        {
            if (value.Tyre.Degradation < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.car = value;
        }
    }

    public string Name { get; set; }
    public double TotalTime { get; set; }
    public virtual double FuelConsumptionPerKm { get; protected set; }
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    internal string FailureReason { get; set; }
    internal bool ParticipatedInOvertakingInCurrentRound { get; set; }
}

//Drivers
//All drivers have a name, total time record and a car to drive:
//Name – a string
//TotalTime – a floating-point number
//Car - parameter of type Car
//FuelConsumptionPerKm – a floating-point number
//Speed – a floating-point number
//Driver’s Speed is calculated throught the formula below.Keep in mind that Speed changes on each lap.
//Speed = “(car’s Hp + tyre’s degradation) / car’s fuelAmount”