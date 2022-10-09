using IdentityService.Api.Application.Models;
using IdentityService.Api.Domain.Entities;

namespace IdentityService.Api.Application.ModelToEntitiy
{
    public static class UserMapper
    {
        public static User ToEntity(this LoginRequestModel request)
        {
            var product = new User();

            product.Email = request.Email;
            return product;
        }
    }
}
