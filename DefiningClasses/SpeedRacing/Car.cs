public class Car
{
    public Car(string model, decimal fuelAmount, decimal fuelPerKm)
    {
        this.Model = model;
        this.Fuel = fuelAmount;
        this.FuelPerKm = fuelPerKm;
    }

    public string Model { get; private set; }

    public decimal Fuel { get; set; }

    public decimal FuelPerKm { get; private set; }

    public decimal DistanceTravelled { get; set; }

    public bool IsFuelEnough(int distanceToTravel)
    {
        if (this.FuelPerKm * distanceToTravel <= this.Fuel)
        {
            this.Fuel -= this.FuelPerKm * distanceToTravel;
            this.DistanceTravelled += distanceToTravel;
            return true;
        }

        return false;
    }
}