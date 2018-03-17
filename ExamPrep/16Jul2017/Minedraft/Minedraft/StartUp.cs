using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        //List<string> hammerHarvesterArgs = new List<string>()
        //{
        //    "Hammer", "1", "10.1" , "10.2"
        //};

        //List<string> SonicHarvesterArgs = new List<string>()
        //{
        //    "Sonic", "2", "20.1" , "20.4", "3"
        //};

        //Harvester harvester = HarvesterFactory.CreateHarvester(hammerHarvesterArgs);
        //Harvester secondHarvester = HarvesterFactory.CreateHarvester(SonicHarvesterArgs);

        //List<string> providerArgs = new List<string>()
        //{
        //    "Solar", "3", "10"
        //};

        //List<string> secondProviderArgs = new List<string>()
        //{
        //    "Pressure" , "4" , "120"
        //};

        //Provider provider = ProviderFactory.CreateProvider(providerArgs);
        //Provider secondProvider = ProviderFactory.CreateProvider(secondProviderArgs);

        DraftManager draftManager = new DraftManager();
        List<string> inputs = new List<string>();

        while (true)
        {
            inputs = Console.ReadLine().Split().ToList();
            string command = inputs[0];
            inputs = inputs.Skip(1).ToList();

            string output = string.Empty;

            switch (command)
            {
                case "RegisterHarvester":
                   output = draftManager.RegisterHarvester(inputs);
                    break;

                case "RegisterProvider":
                    output = draftManager.RegisterProvider(inputs);
                    break;

                case "Day":
                    output = draftManager.Day();
                    break;

                case "Mode":
                    output = draftManager.Mode(inputs);
                    break;

                case "Check":
                    output = draftManager.Check(inputs);
                    break;

                case "Shutdown":
                    output = draftManager.Shutdown();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;

            if (command == "Shutdown")
            {
                break;
            }
        }
    }
}