// I think this will be good, a class to manage database stuffs

using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

class DatabaseManager
{
    // Ran everytime the program opens, this will make sure a DB exists with the tables needed
    // And if it doesn't, it will create on with the correct information
    readonly static string dbPath = "Data Source=CodingTimeTracker.db";
    private static SqliteConnection dbConnection = new SqliteConnection(dbPath);
    public static void InitializeDatabase()
    {
        using (dbConnection)
        {
            dbConnection.Open();

            string commandText = 
            @"
            CREATE TABLE IF NOT EXISTS time_tracking (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            StartTime TEXT,
            EndTime Text,
            Duration INTEGER
            );";

            var command = new SqliteCommand(commandText, dbConnection).ExecuteNonQuery();
            Console.WriteLine("Inistalization done, affected rows: " + command);

            dbConnection.Close();
        }
    }

    public static void StartEntry()
    {
        using (dbConnection)
        {
            dbConnection.Open();

            string commandText = 
            @"
            INSERT INTO time_tracking (StartTime)
            SELECT '2023-11-23 08:00:00'
            WHERE NOT EXISTS (
                SELECT 1
                FROM time_tracking
                WHERE StartTime IS NOT NULL
                AND EndTime IS NULL
                AND Duration IS NULL
            );
            ";

            int command = new SqliteCommand(commandText, dbConnection).ExecuteNonQuery();

            if (command == 0)
            {
                Console.WriteLine("Looks like you already have an open session.\nWould you like to end that one now and start a new one?");
                
            }

        }
    }
}