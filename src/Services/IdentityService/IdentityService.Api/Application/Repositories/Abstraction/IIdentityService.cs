using IdentityService.Api.Application.Models;
using IdentityService.Api.Domain.Entities;

namespace IdentityService.Api.Application.Repositories.Abstraction
{
    public interface IIdentityService
    {
        Task<LoginResponseModel> Login( LoginRequestModel loginRequestModel);
        User UserExits(string email);
    }
}
