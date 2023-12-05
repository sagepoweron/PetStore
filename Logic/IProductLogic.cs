using PetStore.Products;

namespace PetStore.Logic
{
	public interface IProductLogic
	{
		public void AddProduct(Product product);
		public List<Product> GetAllProducts();
		//public DogLeash GetDogLeashByName(string name);

		public T GetProductByName<T>(string name) where T : Product;
		public List<string> GetOnlyInStockProducts();
		public decimal GetTotalPriceOfInventory();
	}
}
