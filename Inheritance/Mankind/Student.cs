using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facNum)
        : base(firstName, lastName)
    {
        this.FacNum = facNum;
    }

    public string FacNum
    {
        get
        {
            return this.facultyNumber;
        }

        private set
        {
            if (!value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToString());
        sb.AppendLine($"Faculty number: {this.facultyNumber}");

        return sb.ToString();
    }
}