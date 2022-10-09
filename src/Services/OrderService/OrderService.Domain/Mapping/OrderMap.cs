using FluentNHibernate.Mapping;
using OrderService.Domain.Models;

namespace OrderService.Domain.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ReferanceNumber).Not.Nullable();
            Map(x => x.OrderDate).Nullable();
            Map(x => x.OrderStatus).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            Map(x => x.Total).Nullable();
            HasMany(x => x.OrderItems).KeyColumn("OrderId").Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
