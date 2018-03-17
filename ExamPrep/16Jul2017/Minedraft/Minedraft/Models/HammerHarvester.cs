public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement *= 2;
        this.OreOutput *= 3;
        this.Type = "Hammer";
    }
}