using Newtonsoft.Json;
using System.Text;
using WebApp.Application.Repositories.Abstract;
using WebApp.Domain.Models.ViewModels;
using WebApp.Extensions;

namespace WebApp.Application.Repositories.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient apiClient;
        private readonly IIdentityService identityService;
        private readonly ILogger<BasketService> logger;
        private readonly IProductService productService;

        public BasketService(HttpClient apiClient, IIdentityService identityService, ILogger<BasketService> logger, IProductService productService)
        {
            this.apiClient = apiClient;
            //apiClient.BaseAddress = new Uri("http://localhost:5003/");
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:5003/");
            this.identityService = identityService;
            this.logger = logger;
            this.productService = productService;
        }

        public async Task<bool> AddItemToBasket(int productId)
        {
            var userName = identityService.GetUserName();
            if (string.IsNullOrEmpty(userName))
                return false;

            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:5003/");
            var resss = identityService.GetCustomerUserId();
            var product = await productService.GetProductById(productId);
            //var basket = await GetBasket();
            var basket = await http.GetResponseAsync<CustomerBasket>("api/Basket/" + identityService.GetCustomerUserId());

            var models = new BasketItem
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = product.Id,
                PictureUrl = "",
                Price = product.Price,
                ProductName = product.Name,
                Quantity = product.Quantity
            };

            await http.PostAsync($"/api/Basket/additem/{identityService.GetCustomerUserId()}", models);
            return true;

        }

        public async Task<CustomerBasket> GetBasket()
        {
            if (identityService.GetCustomerUserId() == "")
            {
                return new CustomerBasket();
            }
            else
            {
                apiClient.BaseAddress = new Uri("http://localhost:5003/");
                var response = await apiClient.GetResponseAsync<CustomerBasket>("api/Basket/" + identityService.GetCustomerUserId());

                return response ?? new CustomerBasket() { CustomerId = identityService.GetCustomerUserId() };
            }
        }
        public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
        {
            var response = await apiClient.PostGetResponseAsync<CustomerBasket, CustomerBasket>("http://localhost:5003/api/basket/update", basket);

            return response;
        }
    }
}
