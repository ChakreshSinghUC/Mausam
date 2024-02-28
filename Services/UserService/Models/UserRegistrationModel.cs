namespace Mausam.Services.UserService.Models
{
    public class UserRegistrationModel
    {
        public UserRegistrationModel() 
        {
            UserName = string.Empty;
            Email = string.Empty;
            LoginPassword = string.Empty; 
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string LoginPassword { get; set; }
    }
}
