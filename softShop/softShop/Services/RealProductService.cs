using softShop.Models;

namespace softShop.Services
{
    public class RealProductService : IProductService
    {
        private List<Product> products;
        public RealProductService()
        {
            products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "A", Price = 100 });
            products.Add(new Product { Id = 2, Name = "B", Price = 10 });
            products.Add(new Product { Id = 3, Name = "C", Price = 20 });
            products.Add(new Product { Id = 4, Name = "D", Price = 150 });
        }
        public IList<Product> GetProducts()
        {
            return products;
        }
    }
}
