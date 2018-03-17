using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private string operationMode;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalEnergyStored;
    private double totalOreMined;

    public DraftManager()
    {
        this.operationMode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
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
        double daysEnergy = this.providers.Sum(p => p.EnergyOutput);
        this.totalEnergyStored += daysEnergy;

        double baseDaysEnergyConsumption = this.harvesters.Sum(h => h.EnergyRequirement);
        double baseDaysOreProduction = this.harvesters.Sum(h => h.OreOutput);

        if (this.operationMode == "Energy")
        {
            baseDaysEnergyConsumption = 0;
            baseDaysOreProduction = 0;
        }
        else if (this.operationMode == "Half")
        {
            baseDaysEnergyConsumption *= 0.6;
            baseDaysOreProduction *= 0.5;
        }

        if (this.totalEnergyStored >= baseDaysEnergyConsumption)
        {
            this.totalOreMined += baseDaysOreProduction;
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
        this.operationMode = arguments[0];
        return $"Successfully changed working mode to {this.operationMode} Mode";
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
        else
        {
            return robot.ToString();
        }
    }

    public string Shutdown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {this.totalEnergyStored}" + Environment.NewLine + $"Total Mined Plumbus Ore: {this.totalOreMined}";
    }
}