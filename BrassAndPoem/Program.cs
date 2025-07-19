using System;
using System.Collections.Generic;
using System.Linq;
using BrassAndPoem;

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 150.99M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Trombone",
        Price = 246.99M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Tuba",
        Price = 1250.99M,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Ozymandias",
        Price = 12350.99M,
        ProductTypeId = 2,
    },
    new Product()
    {
        Name = "Leaves of Grass",
        Price = 15650.99M,
        ProductTypeId = 2,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass",
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poem",
    },
};

//put your greeting here
Console.WriteLine("🎺 Welcome to Brass & Poem!📜");

//implement your loop here
bool exit = false;

while (!exit)
{
    Console.WriteLine();
    DisplayMenu();
    Console.WriteLine("Choose an option:");
    string choice = Console.ReadLine().Trim();

    switch (choice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        case "2":
            DeleteProduct(products, productTypes);
            break;
        case "3":
            AddProduct(products, productTypes);
            break;
        case "4":
            UpdateProduct(products, productTypes);
            break;
        case "5":
            exit = true;
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Please choose 1-5");
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];

        ProductType type = productTypes.FirstOrDefault(t => t.Id == product.ProductTypeId);

        Console.WriteLine($"{i + 1}. {product.Name} || ${product.Price} || {type?.Title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine("Enter the number of the product to delete:");
    string input = Console.ReadLine().Trim();
    int index = int.Parse(input) - 1;

    if (index >= 0 && index < products.Count)
    {
        products.RemoveAt(index);
        Console.WriteLine("Product Deleted");
    }
    else
    {
        Console.WriteLine("Invalid product number");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.Write("Add product name:");
    string name = Console.ReadLine().Trim();

    Console.Write("Enter Product Price:");
    string priceInput = Console.ReadLine().Trim();
    decimal price = decimal.Parse(priceInput);

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
    Console.WriteLine("Choose a product type:");
    string typeInput = Console.ReadLine().Trim();
    int typeIndex = int.Parse(typeInput) - 1;

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = productTypes[typeIndex].Id
    };

    products.Add(newProduct);
    Console.WriteLine("Product added.");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.Write("Enter the number of the product to update:");
    int index = int.Parse(Console.ReadLine()) - 1;

    if (index < 0 || index >= products.Count)
    {
        Console.WriteLine("Invalid product number.");
        return;
    }
    Product product = products[index];

    Console.WriteLine($"Enter new name (Or press Enter to keep '{product.Name}')");
    string newName = Console.ReadLine().Trim();
    if (!string.IsNullOrWhiteSpace(newName))
    {
        product.Name = newName;
    }

    Console.WriteLine($"Enter new price (Or press Enter to keep '${product.Price}')");
    string priceInput = Console.ReadLine().Trim();
    if (!string.IsNullOrWhiteSpace(priceInput))
    {
        product.Price = decimal.Parse(priceInput);
    }

    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
    Console.WriteLine($"Enter new product type (Or press Enter to keep current type)");
    string typeInput = Console.ReadLine().Trim();
    if (!string.IsNullOrWhiteSpace(typeInput))
    {
        int typeIndex = int.Parse(typeInput) - 1;
        product.ProductTypeId = productTypes[typeIndex].Id;
    }

    Console.WriteLine("Product updated.");
}

// don't move or change this!
public partial class Program { }
