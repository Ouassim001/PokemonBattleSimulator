using System;
using System.Collections.Generic;
using System.Threading;

public class Pokemon
{
    public string Name { get; private set; }
    public string Type { get; private set; }

    public Pokemon(string name, string type)
    {
        Name = name;
        Type = type;
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
        Belt.Add(pokemon);
    }

    public List<Pokemon> GetBelt()
    {
        return Belt;
    }
}

public class Nurse
{
    public void TakePokemonBelt(Trainer trainer)
    {
        List<Pokemon> belt = trainer.GetBelt();
        Console.WriteLine($"Nurse takes {belt.Count} Pokeballs from {trainer.Name}'s belt.");
        Thread.Sleep(2000);
    }

    public void GiveBackPokemonBelt(Trainer trainer)
    {
        List<Pokemon> belt = trainer.GetBelt();
        Console.WriteLine($"Nurse gives back {belt.Count} Pokeballs to {trainer.Name}'s belt.");
        Thread.Sleep(2000);
    }

    public bool SayGoodbye()
    {
        Console.Write("Say bye to the nurse: ");
        string input = Console.ReadLine();
        return input.ToLower() == "bye";
    }
}

public class HealingStation
{
    private List<Pokemon> Slots { get; set; }

    public void FillSlots(List<Pokemon> belt)
    {
        Slots = new List<Pokemon>(belt);
        Console.WriteLine("Healing station is filled with Pokeballs.");
        Thread.Sleep(2000);
    }

    public void TurnOn()
    {
        Console.WriteLine("Healing station is turned on.");
        Thread.Sleep(2000);
    }

    public void HealPokemon()
    {
        Console.WriteLine("Healing Pokemon...");
        Thread.Sleep(3000);
    }

    public void ReturnSlots(Trainer trainer)
    {
        List<Pokemon> belt = trainer.GetBelt();
        belt.Clear();
        belt.AddRange(Slots);
        Console.WriteLine("Pokeballs are returned to the Pokemon belt.");
        Thread.Sleep(2000);
    }
}

public class PokemonCenter
{
    private Nurse Nurse { get; set; }
    private HealingStation HealingStation { get; set; }

    public PokemonCenter(Nurse nurse, HealingStation healingStation)
    {
        Nurse = nurse;
        HealingStation = healingStation;
    }

    public void HealPokemon(Trainer trainer)
    {
        Nurse.TakePokemonBelt(trainer);
        HealingStation.FillSlots(trainer.GetBelt());
        HealingStation.TurnOn();
        HealingStation.HealPokemon();
        HealingStation.ReturnSlots(trainer);
        Nurse.GiveBackPokemonBelt(trainer);
        Console.WriteLine("Your Pokemon are fully healed!");
    }
}

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pokemon Center!");
        Thread.Sleep(2000);

        Trainer trainer = new Trainer("Ash");
        trainer.AddPokemonToBelt(new Pokemon("Pikachu", "Electric"));
        trainer.AddPokemonToBelt(new Pokemon("Bulbasaur", "Grass"));
        trainer.AddPokemonToBelt(new Pokemon("Charmander", "Fire"));

        Nurse nurse = new Nurse();
        HealingStation healingStation = new HealingStation();
        PokemonCenter pokemonCenter = new PokemonCenter(nurse, healingStation);

        pokemonCenter.HealPokemon(trainer);

        Console.WriteLine("Please say bye to the nurse to exit.");
        while (!nurse.SayGoodbye())
        {
            Console.WriteLine("Please say bye to the nurse to exit.");
        }

        Console.WriteLine("Thank you for visiting the Pokemon Center!");
    }
}
