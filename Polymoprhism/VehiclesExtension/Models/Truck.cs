public class Truck : Vehicle
{
    public Truck(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
        this.FuelConsumptiomPerKm += 1.6;
    }

    public override string Refuel(double fuelQuantity)
    {
        if (fuelQuantity <= 0)
        {
            return "Fuel must be a positive number";
        }

        if (this.Fuel + fuelQuantity > this.TankCapacity)
        {
            return $"Cannot fit {fuelQuantity} fuel in the tank";
        }

        this.Fuel += fuelQuantity * 0.95;
        return null;
    }
}