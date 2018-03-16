using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateProvider(List<string> arguments)
    {
        Provider newProvider = null;

        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if (type == "Solar")
        {
            newProvider = new SolarProvider(id, energyOutput);
        }
        else if (type == "Pressure")
        {
            newProvider = new PressureProvider(id, energyOutput);
        }
        else
        {
            throw new ArgumentException("Invalid entry");
        }

        return newProvider;
    }
}