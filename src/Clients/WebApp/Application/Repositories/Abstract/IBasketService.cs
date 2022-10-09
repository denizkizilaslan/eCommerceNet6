using WebApp.Domain.Models.ViewModels;

namespace WebApp.Application.Repositories.Abstract
{
    public interface IBasketService
    {
        Task<CustomerBasket> GetBasket();

        Task<CustomerBasket> UpdateBasket(CustomerBasket basket);

        Task<bool> AddItemToBasket(int productId);

    }
}
