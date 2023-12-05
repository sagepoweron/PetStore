using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Logic;
using PetStore.Products;

namespace PetStore
{
    internal class Program
	{
		private static IServiceProvider serviceProvider = CreateServiceCollection();

		static void Main(string[] args)
		{
			//var productLogic = new ProductLogic();
			var productLogic = serviceProvider.GetService<IProductLogic>();

			UILogic(productLogic);
		}

		private static void UILogic(IProductLogic productLogic)
		{
			string userInput = UserChoiceUI();
			while (userInput.ToLower() != "exit")
			{
				if (userInput == "1")
				{
					//AddDogLeashUI(productLogic);
					AddDogLeashJSONUI(productLogic);
				}
				else if (userInput == "2")
				{
					ViewDogLeashUI(productLogic);
				}
				else if (userInput == "3")
				{
					ViewInStockProductsUI(productLogic);
				}
				else if (userInput == "4")
				{
					ViewTotalInventoryPriceUI(productLogic);
				}

				userInput = UserChoiceUI();
			}
		}

		/// <summary>
		/// Asks the user to choose what to do.
		/// </summary>
		/// <returns>Users choice</returns>
		private static string UserChoiceUI()
		{
			Console.WriteLine("Press 1 to add a product, 2 to view a dogleash, 3 to view in stock products, or 4 to get total price of inventory.");
			Console.WriteLine("Type 'exit' to quit.");
			return Console.ReadLine();
		}

		/// <summary>
		/// Creates a dogleash based on the user's input.
		/// </summary>
		/// <param name="productLogic"></param>
		private static void AddDogLeashUI(IProductLogic productLogic)
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

		private static void AddDogLeashJSONUI(IProductLogic productLogic)
		{
			Console.WriteLine("Add a Dog Leash in JSON format:");
			string? userInput = Console.ReadLine();
			DogLeash? dogLeash = JsonSerializer.Deserialize<DogLeash>(userInput);
			productLogic.AddProduct(dogLeash);
		}

		/// <summary>
		/// Shows a dogleash with the name provided by the user.
		/// </summary>
		/// <param name="productLogic"></param>
		private static void ViewDogLeashUI(IProductLogic productLogic)
		{
			Console.WriteLine("Enter the name of the dogleash:");
			string? name = Console.ReadLine();
			DogLeash dogleash = productLogic.GetProductByName<DogLeash>(name);
			if (dogleash != null)
			{
				Console.WriteLine(JsonSerializer.Serialize(dogleash));
			}
			else
			{
				Console.WriteLine("Product not found!");
			}
		}

		/// <summary>
		/// Shows the products that are in stock.
		/// </summary>
		/// <param name="productLogic"></param>
		private static void ViewInStockProductsUI(IProductLogic productLogic)
		{
			Console.WriteLine("The following products are in stock:");
			List<string> instockproducts = productLogic.GetOnlyInStockProducts();

			for (int i = 0; i < instockproducts.Count; i++)
			{
				Console.WriteLine(instockproducts[i]);
			}
		}

		/// <summary>
		/// Shows the total price of all the products that are in stock.
		/// </summary>
		/// <param name="productLogic"></param>
		private static void ViewTotalInventoryPriceUI(IProductLogic productLogic)
		{
			Console.WriteLine("The total price of inventory is:");
			decimal total = productLogic.GetTotalPriceOfInventory();

			Console.WriteLine(total);
		}

		private static IServiceProvider CreateServiceCollection()
		{
			return new ServiceCollection()
				.AddTransient<IProductLogic, ProductLogic>()
				.BuildServiceProvider();
		}
	}
}