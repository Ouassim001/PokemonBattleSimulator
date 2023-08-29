using System;
using System.Collections.Generic;
using System.Threading;

public class Pokemon
{
    public string Name { get; private set; }
    public PokemonType Type { get; private set; }

    public Pokemon(string name, PokemonType type)
    {
        Name = name;
        Type = type;
    }
}

public enum PokemonType
{
    Fire,
    Grass,
    Water
}

public class Battle
{
    private static string Fight(Pokemon pokemon1, Pokemon pokemon2)
    {
        if (pokemon1.Type == PokemonType.Fire && pokemon2.Type == PokemonType.Grass)
        {
            return $"{pokemon1.Name} wins!";
        }
        else if (pokemon1.Type == PokemonType.Grass && pokemon2.Type == PokemonType.Water)
        {
            return $"{pokemon1.Name} wins!";
        }
        else if (pokemon1.Type == PokemonType.Water && pokemon2.Type == PokemonType.Fire)
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
    public string Name { get; private set; }
    private List<Pokemon> Belt { get; set; }

    public Trainer(string name)
    {
        Name = name;
        Belt = new List<Pokemon>();
    }

    public void AddPokemonToBelt(Pokemon pokemon)
    {
        if (Belt.Count < 6)
        {
            Belt.Add(pokemon);
        }
        else
        {
            throw new Exception("The belt can't hold more than 6 Pokemon!");
        }
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
    private int RoundCount { get; set; }
    private int BattleCount { get; set; }

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

        try
        {
            trainer1.AddPokemonToBelt(new Pokemon("Charmander", PokemonType.Fire));
            trainer1.AddPokemonToBelt(new Pokemon("Bulbasaur", PokemonType.Grass));
            trainer1.AddPokemonToBelt(new Pokemon("Squirtle", PokemonType.Water));

            trainer2.AddPokemonToBelt(new Pokemon("Charmander", PokemonType.Fire));
            trainer2.AddPokemonToBelt(new Pokemon("Bulbasaur", PokemonType.Grass));
            trainer2.AddPokemonToBelt(new Pokemon("Squirtle", PokemonType.Water));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        Arena arena = new Arena();
        arena.StartBattle(trainer1, trainer2);
    }
}
