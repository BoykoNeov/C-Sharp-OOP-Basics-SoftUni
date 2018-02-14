namespace RawData
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Car[] cars = new Car[numberOfCars];

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] inputs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = inputs[0];
                int engineSpeed = int.Parse(inputs[1]);
                int enginePower = int.Parse(inputs[2]);
                int cargoWeight = int.Parse(inputs[3]);
                string cargoType = inputs[4];

                // this is intentionally done crappy...
                Tire[] tires = new Tire[4];
                for (int j = 0; j < 8; j += 2)
                {
                    Tire newTire = new Tire()
                    {
                        Pressure = double.Parse(inputs[5 + j]),
                        Age = int.Parse(inputs[6 + j]),
                    };

                    tires[j / 2] = newTire;
                }

                Cargo currentCargo = new Cargo(cargoWeight, cargoType);
                Engine currentEngine = new Engine(engineSpeed, enginePower);

                Car currentCar = new Car(carModel, currentCargo, currentEngine, tires);
                cars[i] = currentCar;
            }

            string command = Console.ReadLine();
            if (command.Equals("fragile"))
            {
                foreach (Car car in cars.Where(c => c.Cargo.CargoType.Equals("fragile")).Where(c => c.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command.Equals("flamable"))
            {
                foreach (Car car in cars.Where(c => c.Cargo.CargoType.Equals("flamable")).Where(c => c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}