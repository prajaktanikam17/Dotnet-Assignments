using System;

class Bird { }

class FlyingBird : Bird
{
    public void Fly()
    {
        Console.WriteLine("Flying...");
    }
}

class Sparrow : FlyingBird { }

class Ostrich : Bird { }

class Program
{
    static void Main()
    {
        Sparrow sparrow = new Sparrow();
        sparrow.Fly();

        Ostrich ostrich = new Ostrich();
        Console.WriteLine("Ostrich cannot fly");
    }
}