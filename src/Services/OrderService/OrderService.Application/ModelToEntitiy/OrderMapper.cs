using OrderService.Application.Model;
using OrderService.Domain.Models;

namespace OrderService.Application.ModelToEntitiy
{
    public static class OrderMapper
    {
        public static Order ToEntity(this OrderModel request)
        {
            var order = new Order();
            order.ReferanceNumber = request.ReferanceNumber;
            order.OrderDate = request.OrderDate;
            order.OrderStatus = request.OrderStatus;
            order.Description = request.Description;
            order.Total = request.Total;
            order.OrderItems = new List<OrderItem>();
            foreach (var item in request.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    PictureUrl = item.PictureUrl,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }
            return order;
        }
    }
}
