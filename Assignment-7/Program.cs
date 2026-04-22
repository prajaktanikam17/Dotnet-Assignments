using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Assignment_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;password=your_password;database=your_database;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database connection successful!");

                    // Example: Insert a new record into the database
                    string insertQuery = "INSERT INTO your_table (column1, column2) VALUES (@value1, @value2)";
                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@value1", "Sample Value 1");
                        command.Parameters.AddWithValue("@value2", "Sample Value 2");
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) inserted.");
                    }

                    // Example: Retrieve records from the database
                    string selectQuery = "SELECT * FROM your_table";
                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["id"]}, Column1: {reader["column1"]}, Column2: {reader["column2"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}