using System;
using System.Collections.Generic;

public abstract class Pokemon
{
    public string Name { get; set; }
    public string Strength { get; set; }
    public string Weakness { get; set; }

    public abstract void BattleCry();
}

public class Squirtle : Pokemon
{
    public Squirtle()
    {
        Name = "Squirtle";
        Strength = "Water";
        Weakness = "Leaf";
    }

    public override void BattleCry()
    {
        Console.WriteLine("Squirtle, go!");
    }
}

public class Bulbasaur : Pokemon
{
    public Bulbasaur()
    {
        Name = "Bulbasaur";
        Strength = "Grass";
        Weakness = "Fire";
    }

    public override void BattleCry()
    {
        Console.WriteLine("Bulbasaur, go!");
    }
}

public class Charmander : Pokemon
{
    public Charmander()
    {
        Name = "Charmander";
        Strength = "Fire";
        Weakness = "Water";
    }

    public override void BattleCry()
    {
        Console.WriteLine("Charmander, go!");
    }
}

public class Trainer
{
    public string Name { get; set; }
    public List<Pokemon> Belt { get; set; }

    public Trainer(string name)
    {
        Name = name;
        Belt = new List<Pokemon>();
    }

    public void AddPokemonToBelt(Pokemon pokemon)
    {
        Belt.Add(pokemon);
    }

    public void ThrowPokeball()
    {
        foreach (Pokemon pokemon in Belt)
        {
            Console.WriteLine($"Throwing pokeball for {pokemon.Name}...");
            pokemon.BattleCry();
            Console.WriteLine($"Returning {pokemon.Name} to the pokeball...");
        }
    }
}

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pokemon Battle Simulator!\n");

        Console.WriteLine("Enter the name of Trainer 1:");
        string trainer1Name = Console.ReadLine();
        Trainer trainer1 = new Trainer(trainer1Name);

        Console.WriteLine("\nEnter the name of Trainer 2:");
        string trainer2Name = Console.ReadLine();
        Trainer trainer2 = new Trainer(trainer2Name);

        trainer1.AddPokemonToBelt(new Squirtle());
        trainer1.AddPokemonToBelt(new Bulbasaur());
        trainer1.AddPokemonToBelt(new Charmander());

        trainer2.AddPokemonToBelt(new Squirtle());
        trainer2.AddPokemonToBelt(new Bulbasaur());
        trainer2.AddPokemonToBelt(new Charmander());

        bool quitGame = false;
        int round = 1;

        while (!quitGame)
        {
            Console.WriteLine($"\nRound {round} - {trainer1.Name}, throw a pokeball!");
            trainer1.ThrowPokeball();

            Console.WriteLine($"\n{trainer2.Name}, throw a pokeball!");
            trainer2.ThrowPokeball();

            Console.WriteLine("\nDo you want to continue the battle? (yes/no)");
            string continueChoice = Console.ReadLine().ToLower();

            if (continueChoice == "no")
            {
                quitGame = true;
            }
            else
            {
                round++;
            }
        }

        Console.WriteLine("\nThe battle has ended!");
    }
}
