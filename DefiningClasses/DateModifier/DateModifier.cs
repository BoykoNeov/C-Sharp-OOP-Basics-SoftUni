using System;

public class DateModifier
{
    private int dateDifference;

    public int DateDifference
    {
        get { return this.dateDifference; }
    }

    public void CalculateDateDifference(string firstDate, string secondDate)
    {
        DateTime first = DateTime.ParseExact(firstDate, "yyyy MM dd", null);
        DateTime second = DateTime.ParseExact(secondDate, "yyyy MM dd", null);
        TimeSpan period = first - second;
        this.dateDifference = Math.Abs(period.Days);
    }
}