using FluentNHibernate.Mapping;
using IdentityService.Api.Domain.Entities;

namespace IdentityService.Api.Domain.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.FullName).Not.Nullable();
            Map(x => x.PasswordSalt).Not.Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.RegisterDate).Not.Nullable();
            Map(x => x.Active).Not.Nullable();
        }
    }
}
