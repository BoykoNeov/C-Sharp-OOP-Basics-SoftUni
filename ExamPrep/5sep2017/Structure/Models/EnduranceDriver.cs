public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car) : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => 1.5;
}

// This type of drivers have FuelConsumptionPerKm equal to 1.5 liters.