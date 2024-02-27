namespace Mausam.Services.UserService.Models
{
    public class UserLoginModel
    {
        public UserLoginModel()
        {
            Id = "123";
            Username = "test";
            Email = "test.com";
            LoginIdentifier = string.Empty;
            LoginPassword = string.Empty;
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string LoginIdentifier { get; set; }
        public string LoginPassword { get; set; }
    }
}
