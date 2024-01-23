using Microsoft.Extensions.DependencyInjection;
using PetStore.Data;
using PetStore.Logic;
using System.Text.Json;

namespace PetStore
{
	internal class Program
	{
		private static IServiceProvider serviceProvider = CreateServiceCollection();

		static void Main(string[] args)
		{
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

				userInput = UserChoiceUI();
			}
		}

		///// <summary>
		///// Asks the user to choose what to do.
		///// </summary>
		///// <returns>Users choice</returns>
		private static string UserChoiceUI()
		{
			Console.WriteLine("Press 1 to add a product 2 to view a dogleash");
			Console.WriteLine("Type 'exit' to quit.");
			return Console.ReadLine();
		}

		///// <summary>
		///// Creates a dogleash based on the user's input.
		///// </summary>
		///// <param name="productLogic"></param>
		private static void AddDogLeashUI(IProductLogic productLogic)
		{
			Product dogleash = new();
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
			Product? dogLeash = JsonSerializer.Deserialize<Product>(userInput);
			productLogic.AddProduct(dogLeash);
		}

		///// <summary>
		///// Shows a dogleash with the name provided by the user.
		///// </summary>
		///// <param name="productLogic"></param>
		private static void ViewDogLeashUI(IProductLogic productLogic)
		{
			Console.WriteLine("Enter the id of the dogleash:");
			int id = int.Parse(Console.ReadLine());
			Product dogleash = productLogic.GetProductById(id);
			if (dogleash != null)
			{
				Console.WriteLine(JsonSerializer.Serialize(dogleash));
			}
			else
			{
				Console.WriteLine("Product not found!");
			}
		}

		private static IServiceProvider CreateServiceCollection()
		{
			return new ServiceCollection()
				.AddTransient<IProductLogic, ProductLogic>()
				.AddTransient<IProductRepository, ProductRepository>()
				.BuildServiceProvider();
		}
	}
}
