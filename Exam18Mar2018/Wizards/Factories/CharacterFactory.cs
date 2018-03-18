using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class CharacterFactory
    {
        //public static Character CreateCharacter(Faction faction, string type, string name)
        //{
        //    Character character = null;
        //    //    Faction faction = (Faction)Enum.Parse(typeof(Faction), args[0]);
        //    //   string characterType = args[1];
        //    string characterType = type;
        //    //    string characterName = args[2];
        //    string characterName = name;

        //    if (characterType == "Warrior")
        //    {
        //        character = new Warrior(characterName, faction);
        //    }
        //    else if(characterType != "Cleric")
        //    {
        //        character = new Cleric(characterName, faction);
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        //    }

        //    return character;
        //}

        public static Character CreateCharacter(string factionString, string type, string name)
        {
            Character character = null;
            if (!Enum.TryParse(factionString, out Faction faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionString}\"!");
            }
            //   string characterType = args[1];
            string characterType = type;
            //    string characterName = args[2];
            string characterName = name;

            if (characterType == "Warrior")
            {
                character = new Warrior(characterName, faction);
            }
            else if (characterType == "Cleric")
            {
                character = new Cleric(characterName, faction);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            return character;
        }
    }
}