using System;


namespace CodingTimeTracker;

class Program
{
    public static void Main(string[] args)
    {
        DatabaseManager.InitializeDatabase();
        Console.WriteLine("Test");
    }

}