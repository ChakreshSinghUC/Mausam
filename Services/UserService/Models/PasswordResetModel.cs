namespace Mausam.Services.UserService.Models
{
    public class PasswordResetModel
    {
        public PasswordResetModel()
        {
            ResetEmail = string.Empty;
        }
        public string ResetEmail { get; set; }
    }
}
