using Microsoft.EntityFrameworkCore;

namespace PetStore.Data
{
	public class ProductContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		public string DbPath { get; }

		public ProductContext()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = Path.Join(path, "products.db");
		}

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}
