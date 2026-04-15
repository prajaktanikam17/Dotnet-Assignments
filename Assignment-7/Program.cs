using System;
using System.Collections.Generic;

class Medicine
{
    public string Name { get; set; }
    public int Rate { get; set; }
    public int Quantity { get; set; }

    public int Amount
    {
        get { return Rate * Quantity; }
    }
}

class Bill
{
    public void GenerateBill(List<Medicine> medicines)
    {
        Console.WriteLine("\n==============================================");
        Console.WriteLine("\tNIKAM MEDICAL STORE");
        Console.WriteLine("==============================================");

        Console.WriteLine("Medicine\tRate\tQty\tAmount");
        Console.WriteLine("----------------------------------------------");

        int subtotal = 0;

        foreach (var m in medicines)
        {
            Console.WriteLine($"{m.Name}\t{m.Rate}\t{m.Quantity}\t{m.Amount}");
            subtotal += m.Amount;
        }

        double gst = subtotal * 0.05;
        double total = subtotal + gst;

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Subtotal:\t{subtotal}");
        Console.WriteLine($"GST (5%):\t{gst}");
        Console.WriteLine($"Grand Total:\t{total}");
        Console.WriteLine("==============================================");
        Console.WriteLine("\tTHANK YOU! VISIT AGAIN");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("\nEnter number of medicines: ");
        int n = int.Parse(Console.ReadLine());

        List<Medicine> medicines = new List<Medicine>();

        for (int i = 0; i < n; i++)
        {
            Medicine m = new Medicine();

            Console.WriteLine($"\nEnter Medicine {i + 1} Details");

            Console.Write("Enter Medicine Name: ");
            m.Name = Console.ReadLine();

            Console.Write("Enter Rate: ");
            m.Rate = int.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            m.Quantity = int.Parse(Console.ReadLine());

            medicines.Add(m);
        }

        Bill bill = new Bill();
        bill.GenerateBill(medicines);
    }
}