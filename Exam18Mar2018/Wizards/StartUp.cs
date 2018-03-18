using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {
            DungeonMaster dungeonMaster = new DungeonMaster();
            string input = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(input))
            {
                string[] splitInput = input.Split();
                string command = splitInput[0];

                if (string.IsNullOrWhiteSpace(command))
                {
                    break;
                }

                string[] arguments = splitInput.Skip(1).ToArray();

                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            output = dungeonMaster.JoinParty(arguments);
                            break;

                        case "AddItemToPool":
                            output = dungeonMaster.AddItemToPool(arguments);
                            break;

                        case "PickUpItem":
                            output = dungeonMaster.PickUpItem(arguments);
                            break;

                        case "UseItem":
                            output = dungeonMaster.UseItem(arguments);
                            break;

                        case "UseItemOn":
                            output = dungeonMaster.UseItemOn(arguments);
                            break;

                        case "GiveCharacterItem":
                            output = dungeonMaster.GiveCharacterItem(arguments);
                            break;

                        case "GetStats":
                            output = dungeonMaster.GetStats();
                            break;

                        case "Attack":
                            output = dungeonMaster.Attack(arguments);
                            break;

                        case "Heal":
                            output = dungeonMaster.Heal(arguments);
                            break;

                        case "EndTurn":
                            output = dungeonMaster.EndTurn(arguments);
                            break;

                        case "IsGameOver":
                            output = dungeonMaster.IsGameOver().ToString();
                            break;
                    }
                }
                catch(InvalidOperationException ex)
                {
                    output = $"Invalid Operation: {ex.Message}";
                }
                catch(ArgumentException ex)
                {
                    output = $"Parameter Error: {ex.Message}";
                }
                catch(Exception ex)
                {
                    output = ex.Message;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(output);
                Console.ForegroundColor = ConsoleColor.White;

                if (dungeonMaster.IsGameOver())
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}