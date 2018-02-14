public class Engine
{
    private string displacement;
    private string efficiency;

    public string Model { get; set; }

    public string Power { get; set; }

    public string Displacement
    {
        get
        {
            if (this.displacement == null)
            {
                return displacement = "n/a";
            }
            else
            {
                return this.displacement;
            }
        }

        set
        {
            this.displacement = value;
        }
    }

    public string Efficiency
    {
        get
        {
            if (this.efficiency == null)
            {
                return efficiency = "n/a";
            }
            else
            {
                return this.efficiency;
            }
        }

        set
        {
                this.efficiency = value;
        }
    }
}