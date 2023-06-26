using System;

public class Charmander
{
    private string name;
    private int fireStrength;
    private string waterWeakness;

    public Charmander(string name, int fireStrength, string waterWeakness)
    {
        this.name = name;
        this.fireStrength = fireStrength;
        this.waterWeakness = waterWeakness;
    }

    public void BattleCry()
    {
        Console.WriteLine(name + "!");
    }
}

public class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pokemon Battle Simulator!");

        bool quitGame = false;

        while (!quitGame)
        {
            Console.WriteLine("Enter a name for your Charmander:");
            string charmanderName = Console.ReadLine();

            Charmander charmander = new Charmander(charmanderName, 10, "Water");

            Console.WriteLine("Let's hear the battle cry of " + charmanderName + "!");
            for (int i = 0; i < 10; i++)
            {
                charmander.BattleCry();
            }

            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.WriteLine("Do you want to rename your Charmander? (yes/no)");
                string renameChoice = Console.ReadLine().ToLower();

                if (renameChoice == "yes")
                {
                    Console.WriteLine("Enter a new name for your Charmander:");
                    charmanderName = Console.ReadLine();
                    charmander = new Charmander(charmanderName, 10, "Water");
                    validAnswer = true;
                }
                else if (renameChoice == "no")
                {
                    quitGame = true;
                    validAnswer = true;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand. Please enter 'yes' or 'no'.");
                }
            }
        }
    }
}
