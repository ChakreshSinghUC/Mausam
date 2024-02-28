namespace Mausam.Services.UserService.Models
{
    public class GoogleLoginModel
    {
        public GoogleLoginModel()
        {
            GoogleAccessToken = string.Empty; 
        }
        public string GoogleAccessToken { get; set; }
    }
}
