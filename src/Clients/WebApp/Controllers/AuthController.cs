using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Repositories.Abstract;
using WebApp.Domain.Models;
using WebApp.Domain.Models.User;
using WebApp.Extensions;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService identityService;
        public AuthController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpGet]
        public string CheckLogin()
        {
            return identityService.GetCustomerUserId();
        }

        [HttpPost]
        public async Task<IActionResult> Check(string email, string password)
        {
            ResultModel resultModel = new ResultModel();
            var result = await identityService.Login(email, password);
            if (result)
                resultModel = new ResultModel { Message = "Kullanıcı Girişi Başarılı.", Status = true };
            else
                resultModel = new ResultModel { Message = "Lütfen bilgilerinizi kontrol ediniz.", Status = false };

            return Json(resultModel);
        }
    }
}
