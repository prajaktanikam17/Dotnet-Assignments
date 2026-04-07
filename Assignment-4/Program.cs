using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\n----- Student Management System -----");
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
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter correct numeric value.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddStudent()
    {
        try
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Student s in students)
            {
                if (s.StudentId == id)
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

            Student student = new Student();

            student.StudentId = id;

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            student.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter Course: ");
            student.Course = Console.ReadLine();

            students.Add(student);

            Console.WriteLine("Student Added Successfully!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! ID and Age must be numbers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Add Student: " + ex.Message);
        }
    }

    static void ViewStudentsList()
    {
        try
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No records found!");
                return;
            }

            foreach (Student s in students)
            {
                Console.WriteLine("\nID: " + s.StudentId);
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Age: " + s.Age);
                Console.WriteLine("Course: " + s.Course);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in View Students: " + ex.Message);
        }
    }

    static void UpdateStudent()
    {
        try
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Student s in students)
            {
                if (s.StudentId == id)
                {
                    Console.Write("Enter New Name: ");
                    s.Name = Console.ReadLine();

                    Console.Write("Enter New Age: ");
                    s.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter New Course: ");
                    s.Course = Console.ReadLine();

                    Console.WriteLine("Updated Successfully!");
                    return;
                }
            }

            Console.WriteLine("Student not found!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter numeric value for ID and Age.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Update Student: " + ex.Message);
        }
    }

    static void DeleteStudent()
    {
        try
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentId == id)
                {
                    students.RemoveAt(i);
                    Console.WriteLine("Deleted Successfully!");
                    return;
                }
            }

            Console.WriteLine("Student not found!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter numeric value for ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Delete Student: " + ex.Message);
        }
    }

    static void FindStudentById()
    {
        try
        {
            Console.Write("Enter ID to find: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Student s in students)
            {
                if (s.StudentId == id)
                {
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine("ID: " + s.StudentId);
                    Console.WriteLine("Name: " + s.Name);
                    Console.WriteLine("Age: " + s.Age);
                    Console.WriteLine("Course: " + s.Course);
                    return;
                }
            }

            Console.WriteLine("Student not found!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter numeric value for ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Find Student: " + ex.Message);
        }
    }

    static void ExportToCSV()
    {
        try
        {
            string filePath = @"D:\Dotnet Assignments\Assignment-4\Student.csv";
            bool fileExists = File.Exists(filePath);

            StreamWriter writer = new StreamWriter(filePath, true);

            if (!fileExists)
            {
                writer.WriteLine("StudentId,Name,Age,Course");
            }

            foreach (Student s in students)
            {
                writer.WriteLine(s.StudentId + "," + s.Name + "," + s.Age + "," + s.Course);
            }

            writer.Close();

            Console.WriteLine("Data Exported Successfully to Student.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in Export To CSV: " + ex.Message);
        }
    }

    static bool IsIdExistsInCSV(int id)
    {
        try
        {
            string filePath = @"D:\Dotnet Assignments\Assignment-4\Student.csv";

            if (!File.Exists(filePath))
            {
                return false;
            }

            StreamReader reader = new StreamReader(filePath);
            string line;

            reader.ReadLine();

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
        catch (Exception ex)
        {
            Console.WriteLine("Error in Checking CSV: " + ex.Message);
            return false;
        }
    }
}