using System;

class Product
{
    // Properties
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    // Parameterless Constructor
    public Product()
    {
        // Set default values or initialize as needed
        ProductId = 0;
        ProductName = "DefaultProduct";
        Price = 0.0;
    }

    // Copy Constructor
    public Product(Product otherProduct)
    {
        // Copy values from the otherProduct instance
        ProductId = otherProduct.ProductId;
        ProductName = otherProduct.ProductName;
        Price = otherProduct.Price;
    }

    // Method to display property values
    public void DisplayProduct()
    {
        Console.WriteLine($"Product ID: {ProductId}");
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Price: {Price:C2}");
    }
}

class Program
{
    static void Main()
    {
        // Create an object using the parameterless constructor
        Product defaultProduct = new Product();
        Console.WriteLine("Default Product:");
        defaultProduct.DisplayProduct();
        Console.WriteLine();

        // Create an object using the copy constructor
        Product customProduct = new Product(defaultProduct);
        // Modify some properties for demonstration purposes
        customProduct.ProductId = 1;
        customProduct.ProductName = "CustomProduct";
        customProduct.Price = 19.99;

        Console.WriteLine("Custom Product (copied from default product and modified):");
        customProduct.DisplayProduct();
    }
}
