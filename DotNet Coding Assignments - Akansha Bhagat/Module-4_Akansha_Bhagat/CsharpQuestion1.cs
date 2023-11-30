using System;

// Base class Person
class Person
{
    private int age;

    // Method to greet
    public void Greeting(string str)
    {
        Console.WriteLine(str);
    }

    // Method to set age
    public void SetAge(int n)
    {
        age = n;
    }
}

// Derived class Student
class Student : Person
{
    // Public method specific to Student
    public void GoToClasses()
    {
        Console.WriteLine("I'm going to class.");
    }

    // Public method to display age
    public void ShowAge()
    {
        Console.WriteLine($"My age is: {base.age} years old");
    }
}

// Test class StudentTest
class StudentTest
{
    static void Main()
    {
        // Create a Person
        Person person = new Person();
        person.Greeting("Hello");

        // Create a Student
        Student student = new Student();
        student.SetAge(21);
        student.Greeting("Good morning");
        student.ShowAge();
    }
}
