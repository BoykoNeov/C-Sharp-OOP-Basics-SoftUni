using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<string> hammerHarvesterArgs = new List<string>()
        {
            "Hammer", "1", "10.1" , "10.2"
        };

        List<string> SonicHarvesterArgs = new List<string>()
        {
            "Sonic", "2", "20.1" , "20.4", "3"
        };

        Harvester harvester = HarvesterFactory.CreateHarvester(hammerHarvesterArgs);
        Harvester secondHarvester = HarvesterFactory.CreateHarvester(SonicHarvesterArgs);

        List<string> providerArgs = new List<string>()
        {
            "Solar", "3", "10"
        };

        List<string> secondProviderArgs = new List<string>()
        {
            "Pressure" , "4" , "120"
        };

        Provider provider = ProviderFactory.CreateProvider(providerArgs);
        Provider secondProvider = ProviderFactory.CreateProvider(secondProviderArgs);

        Console.WriteLine();
    }
}