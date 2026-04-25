using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public string City { get; set; }
    public string Course { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student{ StudentId=1, Name="Amit", Marks=78, City="Pune", Course="C#" },
            new Student{ StudentId=2, Name="Neha", Marks=45, City="Mumbai", Course="Java" },
            new Student{ StudentId=3, Name="Rahul", Marks=88, City="Pune", Course="C#" },
            new Student{ StudentId=4, Name="Sneha", Marks=32, City="Delhi", Course="Python" },
            new Student{ StudentId=5, Name="Priya", Marks=67, City="Mumbai", Course="Java" }
        };

        //Filtering
        var passStudents = students.Where(s => s.Marks >= 50);
        var puneStudents = students.Where(s => s.City == "Pune");
        var failStudents = students.Where(s => s.Marks < 35);

        //Projection
        var names = students.Select(s => s.Name);
        var idName = students.Select(s => new { Id = s.StudentId, Name = s.Name });
        var formatted = students.Select(s => $"{s.Name} - {s.Course} - {s.Marks}");

        //Sorting
        var sortByMarks = students.OrderBy(s => s.Marks);
        var sortByCityThenMarks = students.OrderBy(s => s.City).ThenBy(s => s.Marks);

        //Paging
        var top2 = students.OrderByDescending(s => s.Marks).Take(2);
        var page2 = students.OrderBy(s => s.StudentId).Skip(2).Take(2);

        //Aggregates
        int total = students.Count();
        int passCount = students.Count(s => s.Marks >= 50);
        int maxMarks = students.Max(s => s.Marks);
        int minMarks = students.Min(s => s.Marks);
        double avgMarks = students.Average(s => s.Marks);

        //Quantifiers
        bool anyFail = students.Any(s => s.Marks < 35);
        bool allPass = students.All(s => s.Marks >= 50);

        //Element Operators
        var firstPune = students.First(s => s.City == "Pune");
        var safeDelhi = students.FirstOrDefault(s => s.City == "Delhi");
        var student4 = students.SingleOrDefault(s => s.StudentId == 4);
        var topStudent = students.OrderByDescending(s => s.Marks).First();

        //Grouping
        var groupByCity = students.GroupBy(s => s.City);
        var groupByCourse = students.GroupBy(s => s.Course);

        foreach (var g in groupByCourse)
        {
            Console.WriteLine($"{g.Key} - Count: {g.Count()}");
        }

        foreach (var g in groupByCity)
        {
            Console.WriteLine($"{g.Key} - Avg Marks: {g.Average(x => x.Marks)}");
        }

        //Dictionary
        var dictById = students.ToDictionary(s => s.StudentId);
        var dictByCourse = students.GroupBy(s => s.Course)
                                   .ToDictionary(g => g.Key, g => g.ToList());

        var lookupCity = students.ToLookup(s => s.City);
        var puneList = lookupCity["Pune"];
    }
}