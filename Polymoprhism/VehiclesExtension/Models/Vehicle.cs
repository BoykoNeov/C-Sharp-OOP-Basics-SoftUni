public abstract class Vehicle
{
    private double fuel;
    private double distanceTravelled;
    private double tankCapacity;

    protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.Fuel = fuel;
        this.FuelConsumptiomPerKm = fuelConsumption;

        if (this.Fuel > this.TankCapacity)
        {
            this.Fuel = 0;
        }
    }

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        protected set
        {
            this.tankCapacity = value;
        }
    }

    public double Fuel
    {
        get
        {
            return this.fuel;
        }
        set
        {
            this.fuel = value;
        }
    }

    public double DistanceTravelled
    {
        get
        {
            return this.distanceTravelled;
        }
        protected set
        {
            this.distanceTravelled = value;
        }
    }

    public double FuelConsumptiomPerKm { get; protected set; }

    public virtual string Refuel(double fuelQuantity)
    {
        if (fuelQuantity <= 0)
        {
            return "Fuel must be a positive number";
        }

        if (this.Fuel + fuelQuantity > this.TankCapacity)
        {
            return $"Cannot fit {fuelQuantity} fuel in the tank";
        }

        this.Fuel += fuelQuantity;
        return null;
    }

    public virtual string Drive(double Km)
    {
        double fuelNeeded = Km * this.FuelConsumptiomPerKm;

        if (this.Fuel - fuelNeeded >= 0)
        {
            this.DistanceTravelled += Km;
            this.Fuel -= fuelNeeded;

            return  $"{this.GetType().Name} travelled {Km} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }
}