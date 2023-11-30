using System;

class Grading
{
    // Properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public string StudentId { get; set; }
    public double[] Marks { get; set; }

    // Constructor
    public Grading(string name, string surname, string studentId)
    {
        Name = name;
        Surname = surname;
        StudentId = studentId;
        Marks = new double[4]; // Assuming there are 4 subjects
    }

    // Method to calculate average grade
    public double CalculateAverage()
    {
        double sum = 0;

        foreach (double mark in Marks)
        {
            sum += mark;
        }

        return sum / Marks.Length;
    }
}

class Program
{
    static void Main()
    {
        // Get student information
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student surname: ");
        string surname = Console.ReadLine();

        Console.Write("Enter student ID: ");
        string studentId = Console.ReadLine();

        // Create an instance of the Grading class using the constructor
        Grading student = new Grading(name, surname, studentId);

        // Get marks for each subject
        for (int i = 0; i < student.Marks.Length; i++)
        {
            Console.Write($"Enter mark for Subject {i + 1}: ");
            student.Marks[i] = Convert.ToDouble(Console.ReadLine());
        }

        // Calculate and display the average grade
        double average = student.CalculateAverage();
        Console.WriteLine($"Average Grade for {student.Name} {student.Surname} (ID: {student.StudentId}): {average:F2}");
    }
}
