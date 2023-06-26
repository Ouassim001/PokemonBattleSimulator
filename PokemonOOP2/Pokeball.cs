using System;

public class Pokeball
{
    private bool isEmpty;
    private Charmander charmander;

    public Pokeball()
    {
        isEmpty = true;
        charmander = null;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void Throw()
    {
        if (!isEmpty)
        {
            isEmpty = true;
            Console.WriteLine("The pokeball opens up!");
            charmander.BattleCry();
        }
        else
        {
            Console.WriteLine("The pokeball is empty.");
        }
    }

    public void Return()
    {
        if (!isEmpty)
        {
            Console.WriteLine("The pokeball closes again.");
        }
        else
        {
            Console.WriteLine("The pokeball is already empty.");
        }
    }

    public void Capture(Charmander newCharmander)
    {
        if (isEmpty)
        {
            isEmpty = false;
            charmander = newCharmander;
            Console.WriteLine("You captured a Charmander!");
        }
        else
        {
            Console.WriteLine("The pokeball is already occupied.");
        }
    }
}
