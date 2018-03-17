using System;

public abstract class Provider : Robot
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return energyOutput;
        }
        protected set
        {
            if (value >= 10000 || value < 0)
            {
                throw new System.ArgumentException("EnergyOutput");
            }

            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string result = $"{this.Type} Provider - {this.Id}" + Environment.NewLine + $"Energy Output: {this.EnergyOutput}";
        return result;
    }
}