using softShop.Models;

namespace softShop.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "Telefon", Price = 100 });
            products.Add(new Product { Id = 2, Name="Sakız", Price = 10 });
            products.Add(new Product { Id = 3, Name = "Çikolata", Price = 20 });
            products.Add(new Product { Id = 4, Name = "Terlik", Price = 150 });
        }
        public IList<Product> GetProducts()
        {
            return products;
        }
    }

}
