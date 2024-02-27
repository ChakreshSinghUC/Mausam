using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    // Controllers/CheckInController.cs
    [ApiController]
    [Route("api/checkin")]
    public class CheckInController : ControllerBase
    {
        [HttpPost("{userId}")]
        public IActionResult CheckIn(int userId)
        {
            // Implement logic for user check-in (update user status, record timestamp, etc.)
            // For simplicity, you can just return a success response.
            return Ok(new { Message = $"User with ID {userId} checked in successfully." });
        }
    }

}
