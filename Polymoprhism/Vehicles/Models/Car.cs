public class Car : Vehicle
{
    public Car(double fuel, double fuelConsumption) : base(fuel, fuelConsumption)
    {
        base.FuelConsumptiomPerKm += 0.9;
    }
}