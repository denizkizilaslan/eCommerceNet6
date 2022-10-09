using FluentNHibernate.Mapping;
using OrderService.Domain.Models;

namespace OrderService.Domain.Mapping
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("OrderItem");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ProductName);
            Map(x => x.ProductId);
            Map(x => x.PictureUrl);
            Map(x => x.Price);
            Map(x => x.Quantity);
            References(x => x.Order).Column("OrderId");
        }
    }
}
