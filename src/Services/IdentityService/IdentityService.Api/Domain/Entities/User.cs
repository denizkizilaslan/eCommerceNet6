namespace IdentityService.Api.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string FullName { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual DateTime RegisterDate { get; set; }
        public virtual bool Active { get; set; }
    }
}
