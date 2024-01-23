namespace PetStore.Data
{
	public interface IProductRepository
	{
		void AddProduct(Product product);
		List<Product> GetAllProducts();
		Product GetProductById(int product_id);
	}
}
