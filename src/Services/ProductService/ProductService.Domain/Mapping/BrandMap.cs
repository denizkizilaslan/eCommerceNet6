using FluentNHibernate.Mapping;
using ProductService.Domain.Entities;

namespace ProductService.Domain.Mapping
{
    public class BrandMap : ClassMap<Brand>
    {
        public BrandMap()
        {
            Table("Brands");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
        }
    }
}
