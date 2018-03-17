using System;

public abstract class Harvester : Robot
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get
        {
            return energyRequirement;
        }

        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("EnergyRequirement");
            }

            energyRequirement = value;
        }
    }


    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }

            this.oreOutput = value;
        }
    }
}