using OrderService.Application.Repositories.Abstraction;
using OrderService.Domain.Models;
using OrderService.Infrastructure.Repository;

namespace OrderService.Application.Repositories.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _repository;

        public OrderService(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }
        public bool AddOrder(Order item)
        {
            return _repository.Add(item);
        }

        public Order GetOrder(int id)
        {
            return _repository.FindBy(id);
        }

        public List<Order> GetOrders()
        {
            return _repository.All().ToList();
        }
    }
}
