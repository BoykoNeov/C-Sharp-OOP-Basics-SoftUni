using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        public List<Character> CharacterParty { get; private set; }
        public List<Item> ItemPool { get; private set; }
        int lastSurvivorConsequetiveRounds = 0;

        public DungeonMaster()
        {
            this.CharacterParty = new List<Character>();
            this.ItemPool = new List<Item>();
        }


        //        Parameters
        //•	faction – a string
        //•	characterType – string
        //•	name – string
        //Functionality
        //Creates a character and adds them to the party.
        //If the faction is invalid, throw an ArgumentException with the message Invalid faction "{faction}"!
        //If the character type is invalid, throw an ArgumentException with the message “Invalid character type "{characterType}"!”
        //Returns the string “{name} joined the party!”

        public string JoinParty(string[] args)
        {
            string factionString = args[0];
            string charType = args[1];
            string name = args[2];

            Faction faction;

            if (!Enum.TryParse(factionString, out faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionString}\"!");
            }

            Character newCharacter = CharacterFactory.CreateCharacter(factionString, charType, name);
            this.CharacterParty.Add(newCharacter);
            return $"{name} joined the party!";
        }

        //        Parameters
        //•	itemName –string
        //Functionality
        //Creates an item and adds it to the item pool.
        //If the item type is invalid, throw an ArgumentException with the message "Invalid item "{ name}"!
        //Returns the string “{itemName} added to pool.”
        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item newItem = ItemFactory.CreateItem(itemName);
            this.ItemPool.Add(newItem);
            return $"{itemName} added to pool.";
        }

        // Parameters
        //•	characterName – string
        //Functionality
        //Makes the character with the specified name pick up the last item in the item pool.
        //If the character doesn’t exist in the party, throw an ArgumentException with the message “Character {name} not found!”
        //If there’s no items left in the pool, throw an InvalidOperationException with the message “No items left in pool!”
        //Returns the string “{characterName
        //}
        //picked up { itemName }!”
        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character currentCharacter = GetCharacter(characterName);

            if (this.ItemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item currentItem = this.ItemPool.Last();
            this.ItemPool.RemoveAt(this.ItemPool.Count - 1);
            currentCharacter.Bag.AddItem(currentItem);
            return $"{currentCharacter.Name} picked up {currentItem.Name}!";
        }

        //UseItem Command
        //        Parameters
        //•	characterName – a string
        //•	itemName – string
        //Functionality
        //Makes the character with that name use an item with that name from their bag.
        //If the character doesn’t exist in the party, throw an ArgumentException with the message “Character {name} not found!”
        //The rest of the exceptions should be processed by the called functionality(empty bag, etc.)
        //Returns the string “{character.Name} used {itemName}.”
        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character currentCharacter = this.GetCharacter(characterName);
            Item currentItem = currentCharacter.Bag.GetItem(itemName);
            currentItem.AffectCharacter(currentCharacter);
            return $"{characterName} used {itemName}.";
        }

        //Parameters
        //•	giverName – a string
        //•	receiverName – string
        //•	itemName – string
        //Functionality
        //Makes the giver get an item with that name from their bag and uses it on the receiving character.
        //Process any edge cases(giver not found, receiver not found, item not found, etc.) in the same way as in the above commands.
        //Returns the string “{giverName} used {itemName} on {receiverName}.”
        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            // giver.CheckIsAlive();
            Item usedItem = giver.Bag.GetItem(itemName);
            usedItem.AffectCharacter(receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        // GiveCharacterItem Command
        //        Parameters
        //•	giverName – a string
        //•	receiverName – string
        //•	itemName – string
        //Functionality
        //Makes the giver get an item with that name from their bag and gives it to the receiving character.
        //Process any edge cases(giver not found, receiver not found, item not found, etc.) in the same way as in the above commands.
        //Returns the string “{giverName} gave {receiverName} {itemName}.”
        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = GetCharacter(giverName);
            Character receiver = GetCharacter(receiverName);
            giver.CheckIsAlive();
            receiver.CheckIsAlive();
            Item givenItem = giver.Bag.GetItem(itemName);
            receiver.Bag.AddItem(givenItem);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        // Returns info about all characters, sorted by whether they are alive (descending), then by their health (descending)
        //        The format of a single character is:
        //{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}
        //Returns the formatted character info for each character, separated by new lines.
        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character character in this.CharacterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                string characterIsAlive = character.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {characterIsAlive}");
            }

            return sb.ToString().Trim();
        }

        // Parameters
        //•	attackerName – a string
        //•	receiverName – string
        //Functionality
        //Makes the attacker attack the receiver.
        //If any of the characters don’t exist in the party, throw exceptions with messages just like the above commands.
        //If the attacker cannot attack, throw an ArgumentException with the message “{ attacker.Name}
        //        cannot attack!”
        //The command output is in the following format:
        //{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiverHealth}/{receiverBaseHealth} HP and {receiverArmor}/{receiverBaseArmor} AP left!
        //If the attacker ends up killing the receiver, add a new line, plus “{receiver.Name} is dead!” to the output.
        //Returns the formatted string

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.GetCharacter(attackerName);
            Character receiver = this.GetCharacter(receiverName);

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            Warrior castAttacker = (Warrior)attacker;
            castAttacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiverName} is dead!");
            }

            return sb.ToString().Trim();
        }

        // Parameters
//•	healerName – a string
//•	healingReceiverName – string
//Functionality
//Makes the healer heal the healing receiver.
//If any of the characters don’t exist in the party, throw exceptions with messages just like the above commands.
//If the healer cannot heal, throw an ArgumentException with the message “{ healerName}
//        cannot heal!”
//The command output is in the following format:
//{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!
//Returns the formatted string
        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = this.GetCharacter(healerName);
            Character receiver = this.GetCharacter(receiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric castHealer = (Cleric)healer;

            castHealer.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Character character in this.CharacterParty.Where(c => c.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                double healthAfterRest = character.Health;
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {healthAfterRest})");
            }

            int howManyAliveCharactersAreThere = this.CharacterParty.Where(c => c.IsAlive).Count();
            if (howManyAliveCharactersAreThere <= 1)
            {
                this.lastSurvivorConsequetiveRounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorConsequetiveRounds >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Character GetCharacter(string characterName)
        {
            Character currentCharacter = this.CharacterParty.FirstOrDefault(c => c.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return currentCharacter;
        }
    }
}