using System.Text.Json;

namespace PetStore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Press 1 to add a product");
			Console.WriteLine("Type 'exit' to quit");

			string userInput = Console.ReadLine();

			while (userInput.ToLower() != "exit")
			{
				if (userInput.ToLower() == "1")
				{
					CatFood catFood = new();
					Console.WriteLine("Type a name for catfood");
					catFood.Name = Console.ReadLine();
					Console.WriteLine("Type a price for catfood");
					catFood.Price = decimal.Parse(Console.ReadLine());

					Console.WriteLine(JsonSerializer.Serialize(catFood));
				}

				Console.WriteLine("Press 1 to add a product");
				Console.WriteLine("Type 'exit' to quit");
				userInput = Console.ReadLine();
			}
		}
	}
}