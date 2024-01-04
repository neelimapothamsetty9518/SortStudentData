using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortStudentDataConsoleApp1
{
    class Student
    {
     
        public string Name { get; set; }
        public string Class { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Class: {Class}";
        }
    }

    class Program
    {
        static void Main()
        {
            // File path to store student data
            string filePath = "C:\\Users\\Hp\\Desktop\\PRACTISE EXCERCISES\\C#\\students.txt";

            // Read student data from the file
            List<Student> students = ReadStudentData(filePath);

            // Display menu
            while (true)
            {
                Console.WriteLine("1. Display Students (Sorted by Name)");
                Console.WriteLine("2. Search Student by Name");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayStudentsSortedByName(students);
                        break;
                    case "2":
                        SearchStudentByName(students);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
        }
    

        static List<Student> ReadStudentData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return new List<Student>();
            }
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Create a list to store student objects
            var students = new List<Student>();

            // Parse each line and create Student objects
            foreach (var line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length == 2)
                {
                    var student = new Student
                    {
                        Name = data[0].Trim(),
                        Class = data[1].Trim()
                    };

                    students.Add(student);
                }
            }

            return students;
        }

        static void DisplayStudentsSortedByName(List<Student> students)
        {
            // Sort students by name
            students = students.OrderBy(s => s.Name).ToList();

            // Display sorted students
            Console.WriteLine("Students Sorted by Name:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SearchStudentByName(List<Student> students)
        {
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();

            // Search for the student by name
            var result = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            // Display the search result
            if (result != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"No student found with the name '{searchName}'.");
            }
        }
    }

    
    
}
