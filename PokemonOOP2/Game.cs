using System;

public class Game
{
    public static void Main(string[] args)
    {
        bool quitGame = false;

        while (!quitGame)
        {
            Console.WriteLine("Welcome to the Pokemon Battle Simulator!");

            Console.WriteLine("Enter a name for the first trainer:");
            string trainer1Name = Console.ReadLine();
            Trainer trainer1 = new Trainer(trainer1Name);

            Console.WriteLine("Enter a name for the second trainer:");
            string trainer2Name = Console.ReadLine();
            Trainer trainer2 = new Trainer(trainer2Name);

            while (true)
            {
                Console.WriteLine($"{trainer1Name}, throw a pokeball!");
                trainer1.ThrowPokeball();

                Console.WriteLine($"{trainer2Name}, throw a pokeball!");
                trainer2.ThrowPokeball();

                Console.WriteLine($"{trainer1Name}, return your pokemon!");
                trainer1.ReturnPokemon();

                Console.WriteLine($"{trainer2Name}, return your pokemon!");
                trainer2.ReturnPokemon();

                Console.WriteLine("Do you want to quit the game? (yes/no)");
                string quitChoice = Console.ReadLine().ToLower();

                if (quitChoice == "yes")
                {
                    quitGame = true;
                    break;
                }
                else if (quitChoice == "no")
                {
                    Console.WriteLine("Restarting the game...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'yes' or 'no'.");
                }
            }
        }
    }
}
