using PetStore.Data;

namespace PetStore.Logic
{
	public interface IProductLogic
	{
		public void AddProduct(Product product);
		public List<Product> GetAllProducts();
		Product GetProductById(int id);
	}
}
