namespace Mausam.Services.UserService.Models
{
    public class UserRegistrationModel
    {
        public UserRegistrationModel() 
        { 
            LoginPassword = string.Empty; 
        }
        public string LoginPassword { get; set; }
    }
}
