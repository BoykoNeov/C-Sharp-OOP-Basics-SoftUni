using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateHarvester(List<string> arguments)
    {
        Harvester newHarvester = null;

        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (type == "Sonic")
        {
            string sonicFactor = arguments[4];
            newHarvester = new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(sonicFactor));
        }
        else if (type == "Hammer")
        {
            newHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else
        {
            throw new ArgumentException("Invalid entry");
        }

        return newHarvester;
    }
}