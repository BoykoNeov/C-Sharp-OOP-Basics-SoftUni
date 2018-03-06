using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string[] carParams = Console.ReadLine().Split();
        Car car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]), double.Parse(carParams[3]));

        string[] truckParams = Console.ReadLine().Split();
        Truck truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]), double.Parse(truckParams[3]));

        string[] busParams = Console.ReadLine().Split();
        Bus bus = new Bus(double.Parse(busParams[1]), double.Parse(busParams[2]), double.Parse(busParams[3]));

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] inputCmds = Console.ReadLine().Split();

            Vehicle vehicle = null;

            if (inputCmds[1] == "Car")
            {
                vehicle = car;
            }
            else if (inputCmds[1] == "Truck")
            {
                vehicle = truck;
            }
            else if (inputCmds[1] == "Bus")
            {
                vehicle = bus;
            }

            Type theType = vehicle.GetType();
            MethodInfo theMethod = theType.GetMethod(inputCmds[0]);
            object[] methodParams = new object[] { double.Parse(inputCmds[2]) };
            object result = theMethod.Invoke(vehicle, methodParams);

            if (result != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Car: {car.Fuel:f2}");
        Console.WriteLine($"Truck: {truck.Fuel:f2}");
        Console.WriteLine($"Bus: {bus.Fuel:f2}");
    }
}