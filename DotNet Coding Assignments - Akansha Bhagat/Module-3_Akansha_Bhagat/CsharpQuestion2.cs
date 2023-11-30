using System;

class Student
{
    // Properties
    public int RollNo { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime DOB { get; set; }

    // Parameterless Constructor
    public Student()
    {
        // Set default values or initialize as needed
        RollNo = 0;
        Name = "DefaultStudent";
        Address = "DefaultAddress";
        DOB = DateTime.Now;
    }

    // Overloaded ToString method to display details
    public override string ToString()
    {
        return $"Roll No: {RollNo}\nName: {Name}\nAddress: {Address}\nDOB: {DOB.ToShortDateString()}";
    }
}

class Program
{
    static void Main()
    {
        // Create an object using the parameterless constructor
        Student defaultStudent = new Student();
        Console.WriteLine("Default Student Details:");
        Console.WriteLine(defaultStudent.ToString());
    }
}
