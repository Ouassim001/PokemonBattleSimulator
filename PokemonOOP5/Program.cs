using System;
using System.Collections.Generic;
using System.Threading;

public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        Name = name;
        Type = type;
    }
}

public class Battle
{
    public static string Fight(Pokemon pokemon1, Pokemon pokemon2)
    {
        if (pokemon1.Type == "Fire" && pokemon2.Type == "Grass")
        {
            return $"{pokemon1.Name} wins!";
        }
        else if (pokemon1.Type == "Grass" && pokemon2.Type == "Water")
        {
            return $"{pokemon1.Name} wins!";
        }
        else if (pokemon1.Type == "Water" && pokemon2.Type == "Fire")
        {
            return $"{pokemon1.Name} wins!";
        }
        else if (pokemon1.Type == pokemon2.Type)
        {
            return "It's a draw!";
        }
        else
        {
            return $"{pokemon2.Name} wins!";
        }
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
        Random random = new Random();

        foreach (Pokemon pokemon in Belt)
        {
            Console.WriteLine($"Throwing pokeball for {pokemon.Name}...");
            Console.WriteLine($"{pokemon.Name}, go!");

            Thread.Sleep(1000);

            int index = random.Next(Belt.Count);
            Pokemon opponent = Belt[index];

            Console.WriteLine($"Opponent: {opponent.Name}");
            Console.WriteLine(Battle.Fight(pokemon, opponent));

            Console.WriteLine($"Returning {pokemon.Name} to the pokeball...\n");

            Thread.Sleep(2000);
        }
    }
}

public class Arena
{
    public int RoundCount { get; set; }
    public int BattleCount { get; set; }

    public void StartBattle(Trainer trainer1, Trainer trainer2)
    {
        RoundCount = 1;

        while (trainer1.Belt.Count > 0 && trainer2.Belt.Count > 0)
        {
            Console.WriteLine($"Round {RoundCount}");

            Console.WriteLine($"{trainer1.Name}, throw a pokeball!");
            trainer1.ThrowPokeball();

            Console.WriteLine($"{trainer2.Name}, throw a pokeball!");
            trainer2.ThrowPokeball();

            Console.WriteLine("Press Enter to continue or type 'quit' to end the battle.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            RoundCount++;
        }

        BattleCount++;
        Console.WriteLine("\nThe battle has ended!");
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

        trainer1.AddPokemonToBelt(new Pokemon("Charmander", "Fire"));
        trainer1.AddPokemonToBelt(new Pokemon("Bulbasaur", "Grass"));
        trainer1.AddPokemonToBelt(new Pokemon("Squirtle", "Water"));

        trainer2.AddPokemonToBelt(new Pokemon("Charmander", "Fire"));
        trainer2.AddPokemonToBelt(new Pokemon("Bulbasaur", "Grass"));
        trainer2.AddPokemonToBelt(new Pokemon("Squirtle", "Water"));

        Arena arena = new Arena();
        arena.StartBattle(trainer1, trainer2);
    }
}
