namespace Mausam.UserService.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")]
        public IActionResult GetDummyText()
        {
            // Return a dummy text for the GET request to the root URL
            return Ok(new { Message = "We are working on this." });
        }
    }

}
