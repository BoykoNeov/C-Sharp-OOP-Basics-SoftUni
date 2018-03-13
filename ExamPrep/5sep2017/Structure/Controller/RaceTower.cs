using System.Collections.Generic;

public class RaceTower
{
    public int LapsNumber { get; private set; }
    public int TrackLength { get; private set; }
    public List<Driver> Drivers { get; private set; }
    public string Weather { get; private set; }

    public RaceTower()
    {
        this.Drivers = new List<Driver>();
        this.Weather = "Sunny";
    }

    void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }

    void RegisterDriver(List<string> commandArgs)
    {
        Driver newDriver = DriverFactory.CreateInstance(commandArgs);
        this.Drivers.Add(newDriver);
    }

    void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    string CompleteLaps(List<string> commandArgs)
    {
        //TODO: Add some logic here …
        return null;
    }

    string GetLeaderboard()
    {
        //TODO: Add some logic here …
        return null;
    }

    void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }
}