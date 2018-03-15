using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {

        RaceTower raceTower = new RaceTower();
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        raceTower.SetTrackInfo(numberOfLaps, trackLength);


        while (raceTower.LapsNumber > raceTower.CurrentLap)
        {
            List<string> commandArgs = Console.ReadLine().Split().ToList();

            string command = commandArgs[0];
            commandArgs.RemoveAt(0);

            switch (command)
            {
                case "CompleteLaps":
                    Console.ForegroundColor = ConsoleColor.Red;
                    string result  = raceTower.CompleteLaps(commandArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;

                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;

                case "DriverBoxes":
                    raceTower.DriverBoxes(commandArgs);
                    break;

                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;

                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;
                    
            }
        }

        Driver winner = raceTower.Drivers.OrderBy(d => d.TotalTime).FirstOrDefault();
        if (winner == null)
        {
            winner = raceTower.FailedDrivers.OrderBy(d => d.TotalTime).First();
        }

        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
    }
}