using BasketService.Api.Core.Domain.Models;

namespace BasketService.Api.Core.Application.Repositories
{
    public interface IBasketService
    {
        Task<CustomerBasket> GetBasketAsync(string customerId);
        IEnumerable<string> GetUsers();
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string id);
    }
}
