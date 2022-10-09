using IdentityService.Api.Application.Models;
using IdentityService.Api.Application.Repositories.Abstraction;
using IdentityService.Api.Domain.Entities;
using IdentityService.Api.Extensions;
using IdentityService.Api.Infrastructure.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Api.Application.Repositories.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly IGenericRepository<User> _repository;

        public IdentityService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            User user = UserExits(loginRequestModel.Email);
            if (user == null)
            {
                return Task.FromResult(new LoginResponseModel
                {
                    Success = false,
                    Message = "Sistemde bu mail adresine kayıtlı kullanıcı mevcut değil"
                });
            }
            else
            {
                if (!HashingHelper.VerifyPasswordHash(loginRequestModel.Password, user.PasswordHash, user.PasswordSalt))
                {
                    LoginResponseModel response = new()
                    {
                        Success = false,
                        Message = "Parola hatası !"
                    };

                    return Task.FromResult(response);
                }
                else
                {

                    var claims = new Claim[]
                  {
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                  };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eCommerceSecretKeyu3qdsahdq7374312"));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expiry = DateTime.Now.AddDays(10);

                    var token = new JwtSecurityToken(claims: claims, expires: expiry, signingCredentials: creds, notBefore: DateTime.Now);

                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return Task.FromResult(new LoginResponseModel
                    {
                        CustomerId=user.Id.ToString(),
                        UserToken = encodedJwt,
                        UserName = user.FullName,
                        Success = true,
                        Message = "İşlem Başarılı"
                    });
                }

            }
        }

        public User UserExits(string email)
        {
            return _repository.FindBy(c => c.Email == email);
        }
    }
}
