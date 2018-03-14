using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class RaceTower
{
    public int LapsNumber { get; private set; }
    public int TrackLength { get; private set; }
    public List<Driver> Drivers { get; private set; }
    public string Weather { get; private set; }

    private int CurrentLap { get; set; }
    private List<Driver> FailedDrivers { get; set; }
    private int FailedDriversCount { get; set; }

    public RaceTower()
    {
        this.Drivers = new List<Driver>();
        this.Weather = "Sunny";
        this.FailedDrivers = new List<Driver>();
        this.FailedDriversCount = 0;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        Driver newDriver = DriverFactory.CreateInstance(commandArgs);
        this.Drivers.Add(newDriver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        // double lapTimeAddition = 60 / (this.TrackLength / Driver.Speed);

        StringBuilder sb = new StringBuilder();

        int additionalLaps = int.Parse(commandArgs[0]);

        if (this.CurrentLap + additionalLaps > this.LapsNumber)
        {
            return $"There is no time! On lap {CurrentLap}.";
        }

        List<Driver> driversToRemove = new List<Driver>();

        // complete the specified number of laps
        for (int i = 0; i < additionalLaps; i++)
        {
            foreach (Driver driver in Drivers)
            {
                try
                {

                }
                catch
                {
                    FailedDrivers.Add(driver);
                }
            }

            Drivers.RemoveAll(x => x.FailureReason != null);
        }



        return null;
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(CurrentLap.ToString());
        sb.Append("/");
        sb.AppendLine(LapsNumber.ToString());

        int position = 1;

        foreach (var driver in Drivers.OrderBy(x => x.TotalTime))
        {
            sb.AppendFormat($"{position} {driver.Name} ");
            sb.AppendFormat($"{driver.TotalTime:f3}");

            position++;
        }

        foreach (var driver in FailedDrivers)
        {
            sb.AppendFormat($"{position} {driver.Value.Name} ");
            sb.AppendLine(driver.Value.FailureReason);
            position++;
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.Weather = commandArgs[0];
    }
}