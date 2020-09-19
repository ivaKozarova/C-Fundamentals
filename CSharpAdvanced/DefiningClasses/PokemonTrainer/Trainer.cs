using System.Collections.Generic;

namespace PokemonTrainer
{
    public  class Trainer
    {
        public Trainer(string name)
        {
            this.TrainerName = name;
            this.Pokemons = new List<Pokemon>();
            this.Badges = 0;
         }

        public string TrainerName { get; set; }
        public int  Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {

            return $"{this.TrainerName} {this.Badges} {this.Pokemons.Count}";

        }


    }
}
