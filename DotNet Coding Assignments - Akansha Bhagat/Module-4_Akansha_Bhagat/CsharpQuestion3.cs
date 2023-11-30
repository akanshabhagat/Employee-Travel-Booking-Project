using System;

// Delegate declaration
delegate void NumberStatusDelegate();

class Program
{
    static void Main()
    {
        // Create an instance of the delegate
        NumberStatusDelegate numberStatusDelegate = new NumberStatusDelegate(CheckNumberStatus);

        // Invoke the delegate
        numberStatusDelegate.Invoke();
    }

    // Method to check if a number is even or odd
    static void CheckNumberStatus()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine($"{number} is an even number.");
        }
        else
        {
            Console.WriteLine($"{number} is an odd number.");
        }
    }
}
