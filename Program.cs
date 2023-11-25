using PetStore;
using System.Text.Json;

namespace PetStore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var productLogic = new ProductLogic();

			Console.WriteLine("Press 1 to add a product, 2 to view a dogleash, 3 to view in stock products, or 4 to get the total price of inventory.");
			Console.WriteLine("Type 'exit' to quit.");

			string userInput = Console.ReadLine();

			while (userInput.ToLower() != "exit")
			{
				if (userInput.ToLower() == "1")
				{
					DogLeash dogleash = new();
					Console.WriteLine("Type a name for the dogleash:");
					dogleash.Name = Console.ReadLine();
					Console.WriteLine("Type a price for the dogleash:");
					dogleash.Price = decimal.Parse(Console.ReadLine());
					Console.WriteLine("Type a quantity for the dogleash:");
					dogleash.Quantity = int.Parse(Console.ReadLine());

					productLogic.AddProduct(dogleash);
					Console.WriteLine("Product added!");

					//var options = new JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
					//Console.WriteLine(JsonSerializer.Serialize(catFood));
				}
				else if (userInput == "2")
				{
					Console.WriteLine("Enter the name of the dogleash:");
					string name = Console.ReadLine();
					DogLeash dogleash = productLogic.GetDogLeashByName(name);
					if (dogleash != null)
					{
						Console.WriteLine(JsonSerializer.Serialize(dogleash));
					}
					else
					{
						Console.WriteLine("Product not found!");
					}
					
				}
				else if (userInput == "3")
				{
					Console.WriteLine("The following products are in stock:");
					List<string> instockproducts = productLogic.GetOnlyInStockProducts();

					for (int i = 0; i < instockproducts.Count; i++)
					{
						Console.WriteLine(instockproducts[i]);
					}
				}
				else if (userInput == "4")
				{
					Console.WriteLine("The total price of inventory is:");
					decimal total = productLogic.GetTotalPriceOfInventory();
					
					Console.WriteLine(total);
				}

				Console.WriteLine("Press 1 to add a product, 2 to view a dogleash, 3 to view in stock products, or 4 to get total price of inventory.");
				Console.WriteLine("Type 'exit' to quit.");
				userInput = Console.ReadLine();
			}
		}
	}
}