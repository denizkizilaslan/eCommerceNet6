using WebApp.Application.Repositories.Abstract;
using WebApp.Domain.Models.ViewModels;
using WebApp.Extensions;

namespace WebApp.Application.Repositories.Concrete
{
    public class OrderService : IOrderService
    {
        private HttpClient apiClient;
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService identityService;
        //IHttpClientFactory httpClientFactory
        public OrderService(HttpClient apiClient, IIdentityService identityService)
        {
            this.apiClient = apiClient;
            apiClient.BaseAddress = new Uri("http://localhost:5004/");
            this.identityService = identityService;
            //_httpClientFactory = httpClientFactory;
        }
        //public async Task<string> GetCustomerBasket()
        //{
        //    try
        //    {
        //        apiClient.BaseAddress = new Uri("http://localhost:5004/");

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    var response = await apiClient.GetResponseAsync<string>("api/Order/GetCustomerBasket" + identityService.GetUserName());

        //    return response.ToString();
        //}
        public async Task AddOrder(CustomerBasket customerBasket)
        {

            Order order = new Order();
            order.ReferanceNumber = Guid.NewGuid();
            order.OrderStatus = 0;
            order.OrderDate = System.DateTime.Now;
            order.Description = customerBasket.CustomerId;
            order.OrderItems = new List<OrderItem>();


            foreach (var item in customerBasket.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    Id = 0,
                    Price = item.Price,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    PictureUrl = item.PictureUrl,
                    Quantity = item.Quantity
                });
            }

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://localhost:5004/");

            await apiClient.PostAsync("api/Order/PostOrder", order);

            //todo
            //response true ise basketi temizle

            //apiClient.BaseAddress = new Uri("http://localhost:5003/");
            //var responseDelete = await apiClient.PostGetResponseAsync<dynamic, dynamic>("/api/Basket/DeleteBasketByIdAsync", "guest");

        }
    }
}
