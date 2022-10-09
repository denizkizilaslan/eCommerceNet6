namespace WebApp.Application.Repositories.Abstract
{
    public interface IIdentityService
    {
        string GetUserName();
        string GetCustomerUserId();

        string GetUserToken();


        Task<bool> Login(string userName, string password);

        void Logout();
    }
}
