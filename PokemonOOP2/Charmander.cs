using System;

public class Charmander
{
    private string name;

    public Charmander(string name)
    {
        this.name = name;
    }

    public void BattleCry()
    {
        Console.WriteLine(name + "!");
    }
}
