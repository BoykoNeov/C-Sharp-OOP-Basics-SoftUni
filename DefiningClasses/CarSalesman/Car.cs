using System.Text;

public class Car
{
    private string weight;
    private string color;

    public string Model { get; set; }

    public Engine Engine { get; set; }

    public string Weight
    {
        get
        {
            if (this.weight == null)
            {
                return "n/a";
            }
            else
            {
                return this.weight;
            }
        }

        set
        {
            this.weight = value;
        }
    }

    public string Color
    {
        get
        {
            if (this.color == null)
            {
                return "n/a";
            }

            return this.color;
        }

        set
        {
            this.color = value;
        }
    }

    public override string ToString()
    {
        string carModel = $"{this.Model}:";
        string engineModel = $"  {this.Engine.Model}:";
        string enginePower = $"    Power: {this.Engine.Power}";
        string engineDisplacement = $"    Displacement: {this.Engine.Displacement}";
        string engineEfficiency = $"    Efficiency: {this.Engine.Efficiency}";
        string carWeight = $"Weight: {this.Weight}";
        string carColor = $"Color: {this.Color}";

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(carModel);
        sb.AppendLine(engineModel);
        sb.AppendLine(enginePower);
        sb.AppendLine(engineDisplacement);
        sb.AppendLine(engineEfficiency);
        sb.AppendLine(carWeight);
        sb.Append(carColor);

        return sb.ToString();
    }
}