using PetStore;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

var productLogic = new ProductLogic();

Console.WriteLine("Press 1 to add a product");
Console.WriteLine("Press 2 to view a dog leash");
Console.WriteLine("Type 'exit' to quit");

string userInput = Console.ReadLine();

while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        var dogLeash = new DogLeash();

        Console.WriteLine("Adding a new dog leash..");

        Console.Write("Enter the name of the leash: ");
        dogLeash.Name = Console.ReadLine().Trim();

        Console.Write("Enter the length of the leash in inches: ");
        dogLeash.LengthInches = int.Parse(Console.ReadLine());

        Console.Write("Enter the material of the dog leash: ");
        dogLeash.Material = Console.ReadLine();

        Console.Write("Enter the price for this leash: ");
        dogLeash.Price = decimal.Parse(Console.ReadLine());

        Console.Write("How many of these do you currently have? ");
        dogLeash.Quantity = int.Parse(Console.ReadLine());
        
        Console.Write("Enter a short description of this leash: ");
        dogLeash.Description = Console.ReadLine();

        productLogic.AddProduct(dogLeash);
        Console.WriteLine("You have successfully added a new dog leash!");
    }


    if (userInput == "2")
    {
        Console.WriteLine("What is the name of the dog leash you're searching for? ");
        var dogLeashName = Console.ReadLine();
        var dogLeash = productLogic.GetDogLeashByName(dogLeashName);
        


        if (dogLeash is null)
        {
            Console.WriteLine("That product could not be found. Please try again");
        }

        else
        {
            Console.WriteLine(JsonSerializer.Serialize(dogLeash));
        }
    }
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to view a dog leash");
    Console.WriteLine("Type 'exit' to quit");
    userInput = Console.ReadLine();
}
 