using softShop.Models;

namespace softShop.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        
    }
}
