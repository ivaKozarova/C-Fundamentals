using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Startup
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                CreateLitOftrainers(input, trainers);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                SearchForCurrentElement(input, trainers);
            }

            trainers = trainers.OrderByDescending(t => t.Value.Badges)
                .ToDictionary(x => x.Key, x => x.Value);

            PrintTrainers(trainers);
        }

        private static void SearchForCurrentElement(string input, Dictionary<string, Trainer> trainers)
        {
            foreach ((string trainerName, Trainer trainer) in trainers)
            {
                if (trainer.Pokemons.Any(e => e.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    for (int i = 0; i <trainer.Pokemons.Count; i++)
                    {
                        Pokemon pokemon = trainer.Pokemons[i];
                        pokemon.Health -= 10;
                        if(pokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(pokemon);
                            i--;

                        }
                     
                    }
                }
            }
        }

        private static void PrintTrainers(Dictionary<string, Trainer> trainers)
        {
            foreach (var trainerInfo in trainers)
            {
                Console.WriteLine(trainerInfo.Value);
            }
        }

        private static void CreateLitOftrainers(string input, Dictionary<string, Trainer> trainers)
        {
            var inputInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string trainerName = inputInfo[0];
            string pokemonName = inputInfo[1];
            string element = inputInfo[2];
            int health = int.Parse(inputInfo[3]);

            Pokemon pokemon = new Pokemon(pokemonName, element, health);

            if (!trainers.ContainsKey(trainerName))
            {
                Trainer trainer = new Trainer(trainerName);
                trainers.Add(trainerName, trainer);
            }
            trainers[trainerName].Pokemons.Add(pokemon);
        }
    }
}
