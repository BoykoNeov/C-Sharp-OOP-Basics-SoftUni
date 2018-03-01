using System;
using System.Collections.Generic;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        AddCollection<string> addCollection = new AddCollection<string>();
        AddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
        MyList<string> myList = new MyList<string>();

        List<IAddCollection<string>> addCollections = new List<IAddCollection<string>>
        {
            addCollection,
            addRemoveCollection,
            myList
        };

        string[] inputs = Console.ReadLine().Split();
        StringBuilder sb = new StringBuilder();


        foreach (IAddCollection<string> collection in addCollections)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                sb.Append(collection.Add(inputs[i]) + " ");
            }

            sb.AppendLine();
        }

        List<IAddRemoveCollection<string>> addRemoveCollections = new List<IAddRemoveCollection<string>>
        {
            addRemoveCollection,
            myList
        };

        int n = int.Parse(Console.ReadLine());

        foreach (IAddRemoveCollection<string> collection in addRemoveCollections)
        {
            for (int i = 0; i < n; i++)
            {
                sb.Append(collection.Remove() + " ");
            }

            sb.AppendLine();
        }

        Console.WriteLine(sb.ToString().Trim());
    }
}