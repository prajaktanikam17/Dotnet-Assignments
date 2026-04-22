using System;

interface IWork
{
    void Work();
}

interface IEat
{
    void Eat();
}

class Human : IWork, IEat
{
    public void Work()
    {
        Console.WriteLine("Human working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human eating...");
    }
}

class Robot : IWork
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }
}

class Program
{
    static void Main()
    {
        Human h = new Human();
        h.Work();
        h.Eat();

        Robot r = new Robot();
        r.Work();
    }
}