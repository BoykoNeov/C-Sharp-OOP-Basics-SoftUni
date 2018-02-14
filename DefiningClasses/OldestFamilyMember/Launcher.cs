using System;

public class Launcher
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            string name = inputs[0];
            int age = int.Parse(inputs[1]);
            Person newPerson = new Person(age, name);
            family.AddMember(newPerson);
        }

        Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
    }
}