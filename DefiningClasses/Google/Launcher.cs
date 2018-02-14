using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var people = new List<Person>();

        while (true)
        {
            var inputLine = Console.ReadLine();
            if (inputLine.Equals("End")) break;

            string[] tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string personName = tokens[0];

            if (!people.Any(p => p.Name == personName))
            {
                people.Add(new Person(personName));
            }

            Person currentPerson = people.FirstOrDefault(p => p.Name == personName);

            if (tokens[1].Equals("company"))
            {
                currentPerson.Company.Name = tokens[2];
                currentPerson.Company.Department = tokens[3];
                currentPerson.Company.Salary = decimal.Parse(tokens[4]);
            }
            else if (tokens[1].Equals("pokemon"))
            {
                var pokemon = new Pokemon(tokens[2], tokens[3]);
                currentPerson.Pokemons.Add(pokemon);
            }
            else if (tokens[1].Equals("parents"))
            {
                currentPerson.Parents.Add(new Relative(tokens[2], tokens[3]));
            }
            else if (tokens[1].Equals("children"))
            {
                currentPerson.Children.Add(new Relative(tokens[2], tokens[3]));
            }
            else
            {
                currentPerson.Car.Model = tokens[2];
                currentPerson.Car.MaxSpeed = int.Parse(tokens[3]);
            }
        }

        string name = Console.ReadLine().Trim();
        Person person = people.Single(p => p.Name == name);
        Console.WriteLine(person);
    }
}