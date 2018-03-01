using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static IList<ISoldier> army;

    public static void Main()
    {
        army = new List<ISoldier>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split();
            switch (arguments[0])
            {
                case "Private":
                    army.Add(new Private(arguments[1], arguments[2], arguments[3], double.Parse(arguments[4])));
                    break;

                case "Spy":
                    army.Add(new Spy(arguments[1], arguments[2], arguments[3], int.Parse(arguments[4])));
                    break;

                case "LeutenantGeneral":
                    var privates = ExtractPrivates(arguments.Skip(5).ToList());
                    army.Add(new LeutenantGeneral(arguments[1], arguments[2], arguments[3], double.Parse(arguments[4]), privates));
                    break;

                case "Commando":
                    if (arguments[5] != "Airforces" && arguments[5] != "Marines")
                    {
                        break;
                    }

                    var missions = ExtractMissions(arguments.Skip(6).ToList());
                    army.Add(new Commando(arguments[1], arguments[2], arguments[3], double.Parse(arguments[4]), arguments[5], missions));
                    break;

                case "Engineer":
                    if (arguments[5] != "Airforces" && arguments[5] != "Marines")
                    {
                        break;
                    }

                    IList<IRepair> parts = ExtractParts(arguments.Skip(6).ToList());
                    army.Add(new Engineer(arguments[1], arguments[2], arguments[3], double.Parse(arguments[4]), arguments[5], parts));
                    break;
            }
        }

        foreach (ISoldier soldier in army)
        {
            Console.WriteLine(soldier);
        }
    }

    private static IList<IRepair> ExtractParts(IList<string> parts)
    {
        var list = new List<IRepair>();

        for (int i = 0; i < parts.Count - 1; i += 2)
        {
            list.Add(new Repair(parts[i], int.Parse(parts[i + 1])));
        }

        return list;
    }

    private static IList<IMission> ExtractMissions(IList<string> missions)
    {
        var list = new List<IMission>();

        for (int i = 0; i < missions.Count - 1; i += 2)
        {
            if (missions[i + 1] != "inProgress" && missions[i + 1] != "Finished")
            {
                continue;
            }

            list.Add(new Mission(missions[i], missions[i + 1]));
        }

        return list;
    }

    private static IList<ISoldier> ExtractPrivates(IList<string> soldiers)
    {
        var list = new List<ISoldier>();

        foreach (var soldier in soldiers)
        {
            list.Add(army.First(s => s.ID == soldier));
        }

        return list;
    }
}