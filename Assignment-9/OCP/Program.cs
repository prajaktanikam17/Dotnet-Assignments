using System;

abstract class Discount
{
    public abstract double GetDiscount();
}

class FestivalDiscount : Discount
{
    public override double GetDiscount() => 10;
}

class RegularDiscount : Discount
{
    public override double GetDiscount() => 5;
}

class Program
{
    static void Main()
    {
        Discount d1 = new FestivalDiscount();
        Console.WriteLine("Festival Discount: " + d1.GetDiscount());

        Discount d2 = new RegularDiscount();
        Console.WriteLine("Regular Discount: " + d2.GetDiscount());
    }
}