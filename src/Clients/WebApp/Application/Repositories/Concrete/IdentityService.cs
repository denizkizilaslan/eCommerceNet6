using Newtonsoft.Json;
using WebApp.Application.Repositories.Abstract;
using WebApp.Domain.Models.User;
using WebApp.Extensions;

namespace WebApp.Application.Repositories.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient apiClient;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession _session => httpContextAccessor.HttpContext.Session;
        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            this.apiClient = httpClient;
            this.httpContextAccessor = httpContextAccessor;
            apiClient.BaseAddress = new Uri("http://localhost:5001/");
        }


        public bool IsLoggedIn => !string.IsNullOrEmpty(GetUserToken());

        public string GetUserName()
        {
            if (_session.GetString("username") == null)
                return "";
            else
            return _session.GetString("username").ToString();
        }

        public string GetCustomerUserId()
        {
            if (_session.GetString("customerId") == null)
                return "";
            else
                return _session.GetString("customerId").ToString();
        }

        public string GetUserToken()
        {
            return _session.GetString("token");
        }

        public async Task<bool> Login(string userName, string password)
        {
            var req = new LoginRequestModel(userName, password);

            apiClient.BaseAddress = new Uri("http://localhost:5001/");
            var response = await apiClient.PostGetResponseAsync<LoginResponseModel, LoginRequestModel>("/api/Auth/Login", req);

            if (!string.IsNullOrEmpty(response.UserToken))
            {
                _session.SetString("token", response.UserToken);
                _session.SetString("username", response.UserName);
                _session.SetString("customerId", response.CustomerId);

                apiClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", response.UserToken);

                return true;
            }
            return false;
        }

        public void Logout()
        {
            _session.Remove("token");
            _session.Remove("username");

            apiClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
