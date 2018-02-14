using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            string name = inputs[0];
            int age = int.Parse(inputs[1]);
            Person newPerson = new Person(age, name);
            persons.Add(newPerson);
        }

        foreach (Person person in persons.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}