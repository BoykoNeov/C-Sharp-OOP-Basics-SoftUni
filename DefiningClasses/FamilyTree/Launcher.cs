using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Person> family = new List<Person>();
        List<string> inputLines = new List<string>();
        string personInfo = Console.ReadLine();

        string inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            if (inputLine.Contains("-"))
            {
                inputLines.Add(inputLine);
                continue;
            }

            string[] personArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string firstName = personArgs[0];
            string lastName = personArgs[1];
            string date = personArgs[2];

            if (!family.Any(p => p.FirstName == firstName && p.LastName == lastName))
            {
                Person person = new Person(firstName, lastName, date);
                family.Add(person);
            }
        }

        for (int i = 0; i < inputLines.Count; i++)
        {
            string[] lineArgs = inputLines[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string parentInfo = lineArgs[0].Trim();
            string childInfo = lineArgs[1].Trim();
            Person parent = new Person();
            Person child = new Person();

            parent = AddParentAndChildInfo(parentInfo, family, parent);
            child = AddParentAndChildInfo(childInfo, family, child);

            child.Parents.Add(parent);
            parent.Children.Add(child);
        }

        Person personResult = new Person();

        if (!personInfo.Contains("/"))
        {
            string[] nameInfo = personInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            personResult = family.Single(p => p.FirstName == nameInfo[0] && p.LastName == nameInfo[1]);
        }
        else
        {
            personResult = family.Single(p => p.BirthDate == personInfo.Trim());
        }

        Console.WriteLine(personResult);
    }

    public static Person AddParentAndChildInfo(string personInfo, List<Person> family, Person person)
    {
        if (personInfo.Contains('/'))
        {
            person = family.Single(p => p.BirthDate == personInfo);
        }
        else
        {
            string[] nameInfo = personInfo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            person = family.Single(p => p.FirstName == nameInfo[0] && p.LastName == nameInfo[1]);
        }

        return person;
    }
}