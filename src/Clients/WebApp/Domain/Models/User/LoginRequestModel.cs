namespace WebApp.Domain.Models.User
{
    public class LoginRequestModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public LoginRequestModel(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
