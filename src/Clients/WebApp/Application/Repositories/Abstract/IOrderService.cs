using WebApp.Domain.Models.ViewModels;

namespace WebApp.Application.Repositories.Abstract
{
    public interface IOrderService
    {
        Task AddOrder(CustomerBasket orderModel);
    }
}
