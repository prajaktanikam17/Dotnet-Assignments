using System;
using AccessModifierLibrary;

class Program
{
    static void Main(string[] args)
    {
        Demo d = new Demo();

        Console.WriteLine("Console App:");

        Console.WriteLine(d.publicVar); 

        d.Show();

        Child c = new Child();
        c.Display();
    }
}