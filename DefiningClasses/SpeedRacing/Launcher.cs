using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int numberOfCarsToTrack = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCarsToTrack; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            string model = input[0];
            decimal fuelAmount = decimal.Parse(input[1]);
            decimal fuelConsumptionPerKm = decimal.Parse(input[2]);

            Car currentCar = new Car(model, fuelAmount, fuelConsumptionPerKm);
            cars.Add(currentCar);
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) !="End")
        {
            string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = commandArgs[1];
            int distance = int.Parse(commandArgs[2]);

            Car currentCar = cars.Single(c => c.Model.Equals(model));

            if (!currentCar.IsFuelEnough(distance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Model} {car.Fuel:f2} {car.DistanceTravelled}");
        }
    }
}