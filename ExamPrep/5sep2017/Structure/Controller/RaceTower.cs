using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public int LapsNumber { get; private set; }
    public int TrackLength { get; private set; }
    public List<Driver> Drivers { get; private set; }
    public string Weather { get; private set; }

    public int CurrentLap { get; private set; }
    public List<Driver> FailedDrivers { get; private set; }

    public RaceTower()
    {
        this.Drivers = new List<Driver>();
        this.Weather = "Sunny";
        this.FailedDrivers = new List<Driver>();
        this.CurrentLap = 0;
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
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];

        Driver boxingDriver = Drivers.Find(d => d.Name == driversName);

        string tyreTypeOrFuelAmount = commandArgs[2];

        if (reasonToBox == "ChangeTyres")
        {
            List<string> tyreFactoryArgs = new List<string>
            {
                tyreTypeOrFuelAmount
            };

            string tyreHardness = commandArgs[3];
            tyreFactoryArgs.Add(tyreHardness);

            if (tyreTypeOrFuelAmount == "Ultrasoft")
            {
                string grip = commandArgs[4];
                tyreFactoryArgs.Add(grip);
            }

            boxingDriver.Car.ReplaceTyre(TyreFactory.CreateInstance(tyreFactoryArgs));
        }
        else
        {
            boxingDriver.Car.Refuel(double.Parse(tyreTypeOrFuelAmount));
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder sb = new StringBuilder();

        int additionalLaps = int.Parse(commandArgs[0]);

        if (this.CurrentLap + additionalLaps > this.LapsNumber)
        {
            return $"There is no time! On lap {CurrentLap}.";
        }

        CurrentLap += additionalLaps;

        // complete the specified number of laps
        for (int i = 0; i < additionalLaps; i++)
        {
            foreach (Driver driver in Drivers)
            {
                try
                {
                    double lapTimeAddition = 60 / (this.TrackLength / driver.Speed);
                    driver.TotalTime += lapTimeAddition;
                    driver.Car.BurnFuel(driver.FuelConsumptionPerKm * TrackLength);
                    driver.Car.Tyre.ReduceDegradation();
                    driver.ParticipatedInOvertakingInCurrentRound = false;
                }
                catch (Exception ex)
                {
                    driver.FailureReason = ex.Message;
                    FailedDrivers.Add(driver);
                }
            }

            sb.AppendLine(CalculateOvertaking());

            Drivers.RemoveAll(x => !string.IsNullOrWhiteSpace(x.FailureReason));
        }

        return sb.ToString();
    }

    private string CalculateOvertaking()
    {
        StringBuilder overtakingSb = new StringBuilder();
        List<Driver> sortedDrivers = Drivers.OrderByDescending(x => x.TotalTime).ToList();

        for (int i = 0; i < Drivers.Count - 1; i++)
        {
            Driver firstDriver = sortedDrivers[0];

            if (firstDriver.ParticipatedInOvertakingInCurrentRound)
            {
                continue;
            }

            Driver secondDriver = sortedDrivers[1];

            if (firstDriver.GetType() == typeof(AggressiveDriver) && firstDriver.Car.Tyre.GetType() == typeof(UltrasoftTyre))
            {
                if (this.Weather == "Foggy")
                {
                    firstDriver.FailureReason = "Crashed";
                    firstDriver.ParticipatedInOvertakingInCurrentRound = true;
                    FailedDrivers.Add(firstDriver);
                    continue;
                }
            }

            if (firstDriver.GetType() == typeof(EnduranceDriver) && firstDriver.Car.Tyre.GetType() == typeof(HardTyre))
            {
                if (this.Weather == "Rainy")
                {
                    firstDriver.FailureReason = "Crashed";
                    firstDriver.ParticipatedInOvertakingInCurrentRound = true;
                    FailedDrivers.Add(firstDriver);
                    continue;
                }
            }

            if (firstDriver.TotalTime - secondDriver.TotalTime <= 3)
            {
                if (firstDriver.GetType() == typeof(AggressiveDriver) && firstDriver.Car.Tyre.GetType() == typeof(UltrasoftTyre))
                {
                        firstDriver.TotalTime -= 3;
                        secondDriver.TotalTime += 3;
                        firstDriver.ParticipatedInOvertakingInCurrentRound = true;
                        secondDriver.ParticipatedInOvertakingInCurrentRound = true;
                        overtakingSb.AppendFormat($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.CurrentLap}");
                        continue;
                }

                if (firstDriver.GetType() == typeof(EnduranceDriver) && firstDriver.Car.Tyre.GetType() == typeof(HardTyre))
                {
                        firstDriver.TotalTime -= 3;
                        secondDriver.TotalTime += 3;
                        firstDriver.ParticipatedInOvertakingInCurrentRound = true;
                        secondDriver.ParticipatedInOvertakingInCurrentRound = true;
                        overtakingSb.AppendFormat($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.CurrentLap}");
                        continue;
                }
            }

            if (firstDriver.TotalTime - secondDriver.TotalTime <= 2)
            {
                firstDriver.TotalTime -= 2;
                secondDriver.TotalTime += 2;
                firstDriver.ParticipatedInOvertakingInCurrentRound = true;
                secondDriver.ParticipatedInOvertakingInCurrentRound = true;
                overtakingSb.AppendFormat($"{firstDriver.Name} has overtaken {secondDriver.Name} on lap {this.CurrentLap}");
            }
        }

        Drivers.RemoveAll(x => !string.IsNullOrWhiteSpace(x.FailureReason));
        return overtakingSb.ToString();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Lap ");
        sb.Append(CurrentLap.ToString());
        sb.Append("/");
        sb.AppendLine(LapsNumber.ToString());

        int position = 1;

        foreach (Driver driver in Drivers.OrderBy(x => x.TotalTime))
        {
            sb.AppendFormat($"{position} {driver.Name} ");
            sb.AppendFormat($"{driver.TotalTime:f3}" + Environment.NewLine);

            position++;
        }

        foreach (Driver driver in FailedDrivers)
        {
            sb.AppendFormat($"{position} {driver.Name} ");
            sb.AppendLine(driver.FailureReason + Environment.NewLine);
            position++;
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.Weather = commandArgs[0];
    }
}