using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalEnergyStored;
    private double totalOreMined;

    public double TotalOreMined
    {
        get { return totalOreMined; }
        set { totalOreMined = value; }
    }

    public double TotalEnergyStored
    {
        get { return totalEnergyStored; }
        set { totalEnergyStored = value; }
    }

    public List<Provider> Providers
    {
        get
        {
            return providers;
        }
        private set
        {
            providers = value;
        }
    }


    public List<Harvester> Harvesters
    {
        get
        {
            return harvesters;
        }
        private set
        {
            harvesters = value;
        }
    }

    public string OperationMode
    {
        get
        {
            return this.mode;
        }
        private set
        {
            this.mode = value;
        }
    }

    public DraftManager()
    {
        this.OperationMode = "Full";
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
    }


    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester newHarvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(newHarvester);
            return $"Successfully registered {newHarvester.Type} Harvester - {newHarvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return $"Harvester is not registered, because of it's {ex.Message}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider newProvider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(newProvider);
            return $"Successfully registered {newProvider.Type} Provider - {newProvider.Id}";
        }
        catch (ArgumentException ex)
        {
            return $"Provider is not registered, because of it's {ex.Message}";
        }
    }

    public string Day()
    {
        double daysEnergy = this.Providers.Sum(p => p.EnergyOutput);
        this.TotalEnergyStored += daysEnergy;

        double baseDaysEnergyConsumption = this.Harvesters.Sum(h => h.EnergyRequirement);
        double baseDaysOreProduction = this.Harvesters.Sum(h => h.OreOutput);

        if (this.OperationMode == "Energy")
        {
            baseDaysEnergyConsumption = 0;
            baseDaysOreProduction = 0;
        }
        else if (this.OperationMode == "Half")
        {
            baseDaysEnergyConsumption *= 0.6;
            baseDaysOreProduction *= 0.5;
        }

        if (this.TotalEnergyStored >= baseDaysEnergyConsumption)
        {
            this.TotalOreMined += baseDaysOreProduction;
            this.totalEnergyStored -= baseDaysEnergyConsumption;
        }
        else
        {
            baseDaysOreProduction = 0;
        }

        return $"A day has passed.{Environment.NewLine}Energy Provided: {daysEnergy}{Environment.NewLine}Plumbus Ore Mined: {baseDaysOreProduction}";
    }

    public string Mode(List<string> arguments)
    {
        this.OperationMode = arguments[0];
        return $"Successfully changed working mode to {this.OperationMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Robot robot = null;
        robot = (Robot)this.harvesters.Where(r => r.Id == id).FirstOrDefault() ?? this.providers.Where(r => r.Id == id).FirstOrDefault();

        if (robot == null)
        {
            return $"No element found with id - {id}";
        }
        else if (robot.Type == "Pressure" || robot.Type == "Solar")
        {
            Provider provider = (Provider)robot;
            return provider.ToString();
        }
        else if (robot.Type == "Hammer" || robot.Type == "Sonic")
        {
            Harvester harvester = (Harvester)robot;
            return harvester.ToString();
        }
        else
        {
            return "Unknown type with this id";
        }
    }

    public string Shutdown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {this.TotalEnergyStored}" + Environment.NewLine + $"Total Mined Plumbus Ore: {this.TotalOreMined}";
    }
}