using Middlewares.Models;

namespace Middlewares.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService()
        {
            products = new List<Product>
            {
                new Product{ Id=1, Name="Klavye"},
                new Product{ Id=2, Name="Mouse"},
                new Product{ Id=3, Name="Monitor"},
                new Product{ Id=4, Name="Kulaklık"},
                new Product{ Id=5, Name="Televizyon"},
                new Product{ Id=6, Name="Bilgisayar"}              

            };
        }
        public bool IsProductExist(int id)
        {
            return products.Any(x => x.Id == id);
        }
    }
}
