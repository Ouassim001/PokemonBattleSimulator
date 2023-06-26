using System;
using System.Collections.Generic;

public class Trainer
{
    private string name;
    private List<Pokeball> belt;

    public Trainer(string name)
    {
        this.name = name;
        belt = new List<Pokeball>();

        for (int i = 0; i < 6; i++)
        {
            belt.Add(new Pokeball());
        }
    }

    public void ThrowPokeball()
    {
        foreach (Pokeball pokeball in belt)
        {
            if (pokeball.IsEmpty())
            {
                pokeball.Throw();
                return;
            }
        }

        Console.WriteLine("No empty pokeballs left.");
    }

    public void ReturnPokemon()
    {
        foreach (Pokeball pokeball in belt)
        {
            if (!pokeball.IsEmpty())
            {
                pokeball.Return();
                return;
            }
        }

        Console.WriteLine("No occupied pokeballs left.");
    }
}
