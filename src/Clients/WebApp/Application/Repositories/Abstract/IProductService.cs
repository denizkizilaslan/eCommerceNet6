using WebApp.Domain.Models.ViewModels;

namespace WebApp.Application.Repositories.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(int productId);
    }
}
