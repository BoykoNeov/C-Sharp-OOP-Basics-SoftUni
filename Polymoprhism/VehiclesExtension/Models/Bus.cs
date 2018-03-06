public class Bus : Vehicle
{
    public Bus(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
    }

    public string DriveEmpty(double km)
    {
        return base.Drive(km);
    }

    public override string Drive(double km)
    {
        double fuelNeeded = km * (this.FuelConsumptiomPerKm + 1.4);

        if (Fuel - fuelNeeded >= 0)
        {
            this.DistanceTravelled += km;
            this.Fuel -= fuelNeeded;

            return $"{this.GetType().Name} travelled {km} km";
        }
        else
        {
            return $"{this.GetType().Name} needs refueling";
        }
    }
}