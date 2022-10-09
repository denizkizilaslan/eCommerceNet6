using FluentNHibernate.Mapping;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Quantity);
            Map(x => x.Description);
            Map(x => x.Price);
            References(x => x.Brand).Column("BrandId").Not.Nullable();
        }
    }
}
