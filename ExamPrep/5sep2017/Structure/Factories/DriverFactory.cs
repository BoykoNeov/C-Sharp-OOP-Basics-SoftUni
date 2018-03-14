using System.Collections.Generic;

public class DriverFactory
{
    public static Driver CreateInstance(List<string> args)
    {
        try
        {
            List<string> tyreParams = new List<string>();

            string driverType = args[0];
            string driverName = args[1];
            int carHp = int.Parse(args[2]);
            double fuelAmount = double.Parse(args[3]);

            string tyreType = args[4];
            tyreParams.Add(tyreType);

            string tyreHardness = args[5];
            tyreParams.Add(tyreHardness);

            if (tyreType == "Ultrasoft")
            {
                string grip = args[6];
                tyreParams.Add(grip);
            }

            Tyre newTyre = TyreFactory.CreateInstance(tyreParams);

            Car newCar = new Car(carHp, fuelAmount, newTyre);

            Driver newDriver = null;

            if (args[0] == "Aggressive")
            {
                newDriver = new AggressiveDriver(driverName, newCar);
            }
            else if (args[0] == "Endurance")
            {
                newDriver = new EnduranceDriver(driverName, newCar);
            }

            return newDriver;
        }
        catch
        {
            return null;
        }
        
        // type – a string, equal to either “Aggressive“ or “Endurance“
        // name – a string
        // hp – an integer
        // fuelAmount – a floating-point number
        // tyreType – a string
        // tyreHardness – a floating-point number
        // If the type of tyre is Ultrasoft, you will receive 1 extra parameter:
        // grip –  a positive floating - point number
    }
}