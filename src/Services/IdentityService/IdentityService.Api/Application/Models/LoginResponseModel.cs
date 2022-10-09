namespace IdentityService.Api.Application.Models
{
    public class LoginResponseModel
    {
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string UserToken { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
