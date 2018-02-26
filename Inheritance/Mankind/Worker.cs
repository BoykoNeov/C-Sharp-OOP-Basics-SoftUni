using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHours = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }

        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal WorkHours
    {
        get
        {
            return this.workHours;
        }

        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHours = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToString());
        sb.AppendLine($"Week Salary: {this.weekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.workHours:F2}");
        sb.AppendLine($"Salary per hour: {this.CalculateSalary():F2}");

        return sb.ToString();
    }

    private decimal CalculateSalary()
    {
        return this.weekSalary / (5m * this.workHours);
    }
}