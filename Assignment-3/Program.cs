using System;
using System.IO;

class Program
{
    static int[] studentId = new int[100];
    static string[] name = new string[100];
    static int[] age = new int[100];
    static string[] course = new string[100];

    static int count = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n---- Student Management System ----");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Find Student By ID");
            Console.WriteLine("6. Export To CSV");
            Console.WriteLine("7. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ViewStudentsList();
                    break;

                case 3:
                    UpdateStudent();
                    break;

                case 4:
                    DeleteStudent();
                    break;

                case 5:
                    FindStudentById();
                    break;

                case 6:
                    ExportToCSV();
                    break;

                case 7:
                    Console.WriteLine("Program Ended");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        if (count >= 100)
        {
            Console.WriteLine("Student storage is full!");
            return;
        }

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (studentId[i] == id)
            {
                Console.WriteLine("Student ID already exists!");
                return;
            }
        }

        if (IsIdExistsInCSV(id))
        {
            Console.WriteLine("Student ID already exists in CSV file!");
            return;
        }

        studentId[count] = id;

        Console.Write("Enter Name: ");
        name[count] = Console.ReadLine();

        Console.Write("Enter Age: ");
        age[count] = int.Parse(Console.ReadLine());

        Console.Write("Enter Course: ");
        course[count] = Console.ReadLine();

        count++;
        Console.WriteLine("Student Added Successfully!");
    }

    static void ViewStudentsList()
    {
        if (count == 0)
        {
            Console.WriteLine("No records found!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nID: " + studentId[i]);
            Console.WriteLine("Name: " + name[i]);
            Console.WriteLine("Age: " + age[i]);
            Console.WriteLine("Course: " + course[i]);
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (studentId[i] == id)
            {
                Console.Write("Enter New Name: ");
                name[i] = Console.ReadLine();

                Console.Write("Enter New Age: ");
                age[i] = int.Parse(Console.ReadLine());

                Console.Write("Enter New Course: ");
                course[i] = Console.ReadLine();

                Console.WriteLine("Updated Successfully!");
                return;
            }
        }

        Console.WriteLine("Student not found!");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (studentId[i] == id)
            {
                for (int j = i; j < count - 1; j++)
                {
                    studentId[j] = studentId[j + 1];
                    name[j] = name[j + 1];
                    age[j] = age[j + 1];
                    course[j] = course[j + 1];
                }

                count--;
                Console.WriteLine("Deleted Successfully!");
                return;
            }
        }

        Console.WriteLine("Student not found!");
    }

    static void FindStudentById()
    {
        Console.Write("Enter ID to find: ");
        int id = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (studentId[i] == id)
            {
                Console.WriteLine("\nStudent Found:");
                Console.WriteLine("ID: " + studentId[i]);
                Console.WriteLine("Name: " + name[i]);
                Console.WriteLine("Age: " + age[i]);
                Console.WriteLine("Course: " + course[i]);
                return;
            }
        }

        Console.WriteLine("Student not found!");
    }

    static void ExportToCSV()
    {
        string filePath = @"D:\Dotnet Assignments\Assignment-3\Student.csv";
        bool fileExists = File.Exists(filePath);
       
        StreamWriter writer = new StreamWriter(filePath, true);

        if (!fileExists)
        {
            writer.WriteLine("StudentId,Name,Age,Course");
        }

        for (int i = 0; i < count; i++)
        {
            writer.WriteLine(studentId[i] + "," + name[i] + "," + age[i] + "," + course[i]);
        }

        writer.Close();

        Console.WriteLine("Data Exported Successfully to Student.csv");
    }

    static bool IsIdExistsInCSV(int id)
    {
        string filePath = @"D:\Dotnet Assignments\Assignment-3\Student.csv";

        if (!File.Exists(filePath))
        {
            return false;
        }

        StreamReader reader = new StreamReader(filePath);
        string line;

        reader.ReadLine(); // Skip header

        while ((line = reader.ReadLine()) != null)
        {
            string[] data = line.Split(',');

            if (int.Parse(data[0]) == id)
            {
                reader.Close();
                return true;
            }
        }

        reader.Close();
        return false;
    }
}