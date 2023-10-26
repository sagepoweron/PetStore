using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
	internal class ProductLogic
	{
		private List<Product> _products;
		private Dictionary<string, DogLeash> _dogleashes;
		private Dictionary<string, CatFood> _catfood;

		public ProductLogic()
        {
			_products = new List<Product>();
			_dogleashes = new Dictionary<string, DogLeash>();
			_catfood = new Dictionary<string, CatFood>();
		}

		public void AddProduct(Product product)
		{
			if (product is DogLeash dogleash)
			{
				_dogleashes.Add(dogleash.Name, dogleash);
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

		public DogLeash GetDogLeashByName(string name)
		{
			return _dogleashes[name];
		}
	}
}
