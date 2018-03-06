public class Car : Vehicle
{
    public Car(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
    {
        base.FuelConsumptiomPerKm += 0.9;
    }
}