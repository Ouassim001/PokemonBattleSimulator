using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonOOP1
{
    internal class trainer
    {
        string name;
        List<Pokeball> belt;

        public trainer(string name, List<Pokeball> belt)
        {
            this.name = name;
            this.belt = belt;
        }

        public void throwPokeball(int number)
        {
            Console.WriteLine(name + "has thrown a pokeball");
        }

        public void returnPokemon(int number)
        {
            Console.WriteLine(name + "the pokeball is closed");

            belt[number].Close();
        }
    }
}
