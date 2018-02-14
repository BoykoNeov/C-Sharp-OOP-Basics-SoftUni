using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        string input = string.Empty;
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
        Dictionary<string, int> orderOfAppearance = new Dictionary<string, int>();
        int currentTrainerNumber = 1;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] parameters = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = parameters[0];
            string pokemonName = parameters[1];
            string pokemonElement = parameters[2];
            int pokemonHealth = int.Parse(parameters[3]);

            Pokemon newPokemon = new Pokemon(pokemonName, pokemonHealth, pokemonElement);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer(trainerName));
                orderOfAppearance.Add(trainerName, currentTrainerNumber++);
            }

            trainers[trainerName].pokemons.Add(newPokemon);
        }

        string elementsInput = string.Empty;

        while ((elementsInput = Console.ReadLine()) != "End")
        {
            foreach (Trainer trainer in trainers.Values)
            {
                if (trainer.pokemons.Any(p => p.Element == elementsInput))
                {
                    trainer.Badges++;
                }
                else
                {
                    HashSet<Pokemon> pokemonsToRemove = new HashSet<Pokemon>();

                    foreach (Pokemon pokemon in trainer.pokemons)
                    {
                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            pokemonsToRemove.Add(pokemon);
                        }
                    }

                    trainer.pokemons.SymmetricExceptWith(pokemonsToRemove);
                }
            }
        }

        foreach (Trainer trainer in trainers.Values.OrderByDescending(t => t.Badges).ThenBy(t => orderOfAppearance[t.Name]))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.pokemons.Count}");
        }
    }
}