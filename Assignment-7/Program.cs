using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Assignment_7
{
    class Medicine
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int MedicineId { get; set; }
    }

    class Program
    {
        static string connStr = "server=127.0.0.1;port=3306;user=root;password=root;database=medicalstoredb;";

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Enter number of medicines: ");
                int n = int.Parse(Console.ReadLine());

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    Console.WriteLine("Database Connected Successfully!");

                    // Insert Customer
                    MySqlCommand custCmd = new MySqlCommand(
                        "INSERT INTO Customer(Name) VALUES (@name); SELECT LAST_INSERT_ID();",
                        conn);

                    custCmd.Parameters.AddWithValue("@name", customerName);

                    int customerId = Convert.ToInt32(custCmd.ExecuteScalar());

                    // Create Bill with CustomerId
                    MySqlCommand billCmd = new MySqlCommand(
                        "INSERT INTO Bill(CustomerId) VALUES (@cid); SELECT LAST_INSERT_ID();",
                        conn);

                    billCmd.Parameters.AddWithValue("@cid", customerId);

                    int billId = Convert.ToInt32(billCmd.ExecuteScalar());

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

                        // Insert Medicine
                        MySqlCommand medCmd = new MySqlCommand(
                            "INSERT INTO Medicine(Name, Rate) VALUES (@name, @rate); SELECT LAST_INSERT_ID();",
                            conn);

                        medCmd.Parameters.AddWithValue("@name", m.Name);
                        medCmd.Parameters.AddWithValue("@rate", m.Rate);

                        m.MedicineId = Convert.ToInt32(medCmd.ExecuteScalar());

                        // Insert BillDetails
                        MySqlCommand detailCmd = new MySqlCommand(
                            "INSERT INTO BillDetails(BillId, MedicineId, Quantity) VALUES (@billId, @medId, @qty)",
                            conn);

                        detailCmd.Parameters.AddWithValue("@billId", billId);
                        detailCmd.Parameters.AddWithValue("@medId", m.MedicineId);
                        detailCmd.Parameters.AddWithValue("@qty", m.Quantity);

                        detailCmd.ExecuteNonQuery();

                        // Insert into Sales table
                        MySqlCommand salesCmd = new MySqlCommand(
                            "INSERT INTO Sales(CustomerName, MedicineName, Quantity, Rate, Total) VALUES (@cname, @mname, @qty, @rate, @total)",
                            conn);

                        salesCmd.Parameters.AddWithValue("@cname", customerName);
                        salesCmd.Parameters.AddWithValue("@mname", m.Name);
                        salesCmd.Parameters.AddWithValue("@qty", m.Quantity);
                        salesCmd.Parameters.AddWithValue("@rate", m.Rate);
                        salesCmd.Parameters.AddWithValue("@total", m.Quantity * m.Rate);

                        salesCmd.ExecuteNonQuery();

                        medicines.Add(m);
                    }

                    // Print Bill
                    PrintBill(conn, billId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        static void PrintBill(MySqlConnection conn, int billId)
        {
            Console.WriteLine("\n==============================================");
            Console.WriteLine("\tNIKAM MEDICAL STORE");
            Console.WriteLine("==============================================");

            Console.WriteLine("Medicine\tRate\tQty\tAmount");
            Console.WriteLine("----------------------------------------------");

            string query = @"SELECT m.Name, m.Rate, bd.Quantity, (m.Rate * bd.Quantity) AS Amount
                             FROM BillDetails bd
                             JOIN Medicine m ON bd.MedicineId = m.MedicineId
                             WHERE bd.BillId = @billId";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@billId", billId);

            MySqlDataReader reader = cmd.ExecuteReader();

            int subtotal = 0;

            while (reader.Read())
            {
                string name = reader.GetString("Name");
                int rate = reader.GetInt32("Rate");
                int qty = reader.GetInt32("Quantity");
                int amount = reader.GetInt32("Amount");

                Console.WriteLine($"{name}\t{rate}\t{qty}\t{amount}");
                subtotal += amount;
            }

            reader.Close();

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
}