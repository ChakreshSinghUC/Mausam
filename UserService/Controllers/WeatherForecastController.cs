using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    // Controllers/UserController.cs
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users = new List<User>(); // In-memory storage for simplicity

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            newUser.Id = _users.Count + 1;
            _users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }
    }

}
