public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) : base(name, car)
    {
    }

    public override double FuelConsumptionPerKm => 2.7;
    public override double Speed => base.Speed * 1.3;
}

//This type of drivers have FuelConsumptionPerKm equal to 2.7 liters.Also aggressive driver’s Speed is multiplied by 1.3.