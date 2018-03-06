using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        List<Animal> animals = new List<Animal>();

        while ((input = Console.ReadLine()) != "End")
        {
            List<string> animalParams = input.Split().ToList();
            Animal animal = null;

            switch (animalParams[0].ToLower())
            {
                case "mouse":
                    animal = new Mouse(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
                    break;

                case "dog":
                    animal = new Dog(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
                    break;

                case "owl":
                    animal = new Owl(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
                    break;

                case "hen":
                    animal = new Hen(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
                    break;

                case "cat":
                    animal = new Cat(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
                    break;

                case "tiger":
                    animal = new Tiger(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
                    break;

                default:
                    break;
            }

            Console.WriteLine(animal.MakeSound());

            animals.Add(animal);

            string[] foodItems = Console.ReadLine().Split();

            Food food = null;

            switch (foodItems[0])
            {
                case nameof(Fruit):
                    food = new Fruit(int.Parse(foodItems[1]));
                    break;

                case nameof(Vegetable):
                    food = new Vegetable(int.Parse(foodItems[1]));
                    break;

                case nameof(Meat):
                    food = new Meat(int.Parse(foodItems[1]));
                    break;

                case nameof(Seeds):
                    food = new Seeds(int.Parse(foodItems[1]));
                    break;
            }

            string eatResult = animal.Eat(food);

            if (eatResult != null)
            {
                Console.WriteLine(eatResult);
            }
        }

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}