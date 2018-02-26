using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        List<Animal> animals = new List<Animal>();

        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                string animalType = input;
                string[] parameters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Animal currentAnimal = null;

                if (parameters.Length == 2)
                {
                    currentAnimal = Activator.CreateInstance(Type.GetType(animalType), parameters[0], parameters[1]) as Animal;
                }

                if (parameters.Length == 3)
                {
                    currentAnimal = Activator.CreateInstance(Type.GetType(animalType), parameters[0], parameters[1], parameters[2]) as Animal;
                }

                if (!currentAnimal.IsValid())
                {
                    throw new ArgumentException();
                }

                animals.Add(currentAnimal);
            }
            catch
            {
                Console.WriteLine("Invalid input!");
                continue;
            }
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal.GetType());
            Console.WriteLine(animal);
            Console.WriteLine(animal.ProduceSound());
        }
    }
}