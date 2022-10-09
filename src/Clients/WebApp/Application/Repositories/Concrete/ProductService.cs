using WebApp.Application.Repositories.Abstract;
using WebApp.Domain.Models.ViewModels;
using WebApp.Extensions;

namespace WebApp.Application.Repositories.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient apiClient;
        private readonly IIdentityService identityService;

        public ProductService(HttpClient apiClient, IIdentityService identityService)
        {
            this.apiClient = apiClient;
            this.identityService = identityService;
            apiClient.BaseAddress = new Uri("http://localhost:5002/");
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            var response = await apiClient.GetResponseAsync<ProductModel>($"api/Products/GetProductById/{productId}");
            return response;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var response = await apiClient.GetResponseAsync<List<ProductModel>>("api/Products/GetProducts");

            return response;
        }

    }
}
