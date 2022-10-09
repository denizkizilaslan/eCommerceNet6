using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Repositories.Abstraction
{
    public interface IOrderService
    {
        bool AddOrder(Order item);
        Order GetOrder(int id);
        List<Order> GetOrders();
    }
}
