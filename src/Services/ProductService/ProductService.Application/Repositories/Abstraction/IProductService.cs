using ProductService.Domain.Entities;

namespace ProductService.Application.Repositories.Abstraction
{
    public interface IProductService
    {
        bool AddProduct(Product item);
        bool DeleteProduct(Product item);
        Product GetProduct(int id);
        List<Product> GetProducts();
        List<Product> GetProductsByBrandId(int brandId);
    }
}
