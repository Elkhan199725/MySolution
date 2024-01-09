using Models;
using System;
using System.IO;


string directoryPath = @".\ProductData";
string filePath = Path.Combine(directoryPath, "products.txt");

// Ensure the directory exists
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

// Create a new Product instance
Product product = new Product();

Console.WriteLine("Enter product name:");
product.Name = Console.ReadLine();

Console.WriteLine("Enter product price:");

// Use decimal.TryParse to handle invalid inputs
if (decimal.TryParse(Console.ReadLine(), out decimal price))
{
    product.Price = price;

    // Write to the text file
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        writer.WriteLine($"{product.Name},{product.Price}");
    }

    Console.WriteLine("Product information saved successfully.");
}
else
{
    Console.WriteLine("Invalid price format. Please enter a valid decimal number.");
}

Console.ReadLine(); // Pause to see the result
