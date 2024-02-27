// IUserService.cs
namespace Mausam.Services.UserService.Interfaces
{
    public interface IUserCheckin
    {
        // User registration
        bool RegisterUser(string username, string email, string password);

        // User login
        bool LoginUser(string loginIdentifier, string password);

        // Forgot password
        bool ForgotPassword(string email);

        // Google login
        bool GoogleLogin(string googleAccessToken);

    }
}
