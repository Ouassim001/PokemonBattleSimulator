using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonOOP1
{
    internal class Pokeball
    {
        Charmander charmander;

        public Pokeball(Charmander charmander)
        {
            this.charmander = charmander;
        }

        public void Open()
        {
            Console.WriteLine("the pokeball is opened");
        }

        public void Close()
        {
            Console.WriteLine("the pokeball is closed");

        }
    }

}
