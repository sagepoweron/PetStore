namespace PetStore.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductContext _context;

		public ProductRepository()
		{
			_context = new ProductContext();
		}


		public void AddProduct(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public Product GetProductById(int product_id)
		{
			return _context.Products.SingleOrDefault(x => x.ProductId == product_id);
		}

		public List<Product> GetAllProducts()
		{
			return _context.Products.ToList();
		}
	}
}
