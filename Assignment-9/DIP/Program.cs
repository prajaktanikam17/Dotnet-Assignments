using System;

interface IDatabase
{
    void Connect();
}

class MySQL : IDatabase
{
    public void Connect()
    {
        Console.WriteLine("Connected to MySQL");
    }
}

class MongoDB : IDatabase
{
    public void Connect()
    {
        Console.WriteLine("Connected to MongoDB");
    }
}

class Service
{
    private IDatabase db;

    public Service(IDatabase database)
    {
        db = database;
    }

    public void Start()
    {
        db.Connect();
    }
}

class Program
{
    static void Main()
    {
        IDatabase db = new MySQL();
        Service service = new Service(db);
        service.Start();
    }
}