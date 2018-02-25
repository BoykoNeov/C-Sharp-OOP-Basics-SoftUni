using System;
using System.Linq;
using System.Collections.Generic;

public class Dough
{
    public const double WhiteModifier = 1.5;
    public const double WholeGrainModifier = 1.0;
    public const double CrispyModifier = 0.9;
    public const double ChewyModifier = 1.1;
    public const double HomeMadeModifier = 1.0;

    private readonly IReadOnlyList<string> allowedTypes = new string[] { "white", "wholegrain" };
    private readonly IReadOnlyList<string> allowedTechniques = new string[] { "crispy", "chewy", "homemade" };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        set
        {
            if (!this.allowedTypes.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        set
        {
            if (!this.allowedTechniques.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double CalcDoughCalories()
    {
        double flourModifier = 0;

        switch (this.flourType.ToLower())
        {
            case "white":
                flourModifier = WhiteModifier;
                break;

            case "wholegrain":
                flourModifier = WholeGrainModifier;
                break;
        }

        double bakingModifier = 0;

        switch (this.bakingTechnique.ToLower())
        {
            case "crispy":
                bakingModifier = CrispyModifier;
                break;

            case "chewy":
                bakingModifier = ChewyModifier;
                break;

            case "homemade":
                bakingModifier = HomeMadeModifier;
                break;
        }

        double result = this.weight * flourModifier * bakingModifier * 2;
        return result;
    }
}