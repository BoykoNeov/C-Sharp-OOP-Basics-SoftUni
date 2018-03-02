public class Truck : Vehicle
{
    public Truck(double fuel, double fuelConsumption) : base(fuel, fuelConsumption)
    {
        base.FuelConsumptiomPerKm += 1.6;
    }

    public override void Refuel(double fuelQuantity)
    {
        base.Refuel(fuelQuantity * 0.95);
    }
}