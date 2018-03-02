public abstract class Vehicle
{
    private double fuel;
    private double distanceTravelled;

    protected Vehicle(double fuel, double fuelConsumption)
    {
        this.Fuel = fuel;
        this.FuelConsumptiomPerKm = fuelConsumption;
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
        private set
        {
            this.distanceTravelled = value;
        }
    }

    public double FuelConsumptiomPerKm { get; protected set; }

    public virtual void Refuel(double fuelQuantity)
    {
        this.Fuel += fuelQuantity;
    }

    public virtual bool Drive(double Km)
    {
        double fuelNeeded = Km * this.FuelConsumptiomPerKm;

        if (Fuel - fuelNeeded >= 0)
        {
            this.DistanceTravelled += Km;
            this.Fuel -= fuelNeeded;

            return true;
        }
        else
        {
            return false;
        }
    }
}