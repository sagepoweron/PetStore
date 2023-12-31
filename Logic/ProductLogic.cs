﻿using PetStore.Products;
using PetStore.Validators;

namespace PetStore.Logic
{
	public class ProductLogic : IProductLogic
	{
		private List<Product> _products;
		private Dictionary<string, DogLeash> _dogleashes;
		private Dictionary<string, CatFood> _catfood;

		public ProductLogic()
		{
			_products = new List<Product>();
			_dogleashes = new Dictionary<string, DogLeash>();
			_catfood = new Dictionary<string, CatFood>();

			CreateDefaultProducts();
		}

		private void CreateDefaultProducts()
		{
			{
				DogLeash dogleash = new()
				{
					Name = "Popular Dog Leash",
					Quantity = 1,
					Price = 10
				};
				AddProduct(dogleash);
			}

			{
				DogLeash dogleash = new()
				{
					Name = "Common Dog Leash",
					Quantity = 1,
					Price = 1
				};
				AddProduct(dogleash);
			}

			{
				DogLeash dogleash = new()
				{
					Name = "Rare Dog Leash",
					Quantity = 0,
					Price = 20
				};
				AddProduct(dogleash);
			}
		}

		public void AddProduct(Product product)
		{
			if (product is DogLeash dogleash)
			{
				DogLeashValidator validator = new();

				if (validator.Validate(dogleash).IsValid)
				{
					_dogleashes.Add(dogleash.Name, dogleash);
				}
				else
				{
					throw new Exception("Not valid.");
				}

				
			}
			else if (product is CatFood catfood)
			{
				_catfood.Add(catfood.Name, catfood);
			}

			_products.Add(product);
		}

		public List<Product> GetAllProducts()
		{
			return _products;
		}



		public T GetProductByName<T>(string name) where T : Product
		{
			try
			{
				if (typeof(T) == typeof(DogLeash))
				{
					return _dogleashes[name] as T;
				}

				if (typeof(T) == typeof(CatFood))
				{
					return _catfood[name] as T;
				}

				return null;
				
			}
			catch (Exception)
			{
				return null;
			}
		}

		//public DogLeash GetDogLeashByName(string name)
		//{
		//	try
		//	{
		//		return _dogleashes[name];
		//	}
		//	catch (Exception ex)
		//	{
		//		return null;
		//	}

		//}

		public List<string> GetOnlyInStockProducts()
		{
			return _products.InStock().Select(x => x.Name).ToList();
		}

		public decimal GetTotalPriceOfInventory()
		{
			return _products.InStock().Select(x => x.Price).Sum();
		}
	}
}
