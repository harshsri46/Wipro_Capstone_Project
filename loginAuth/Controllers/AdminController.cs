using loginAuth.DTO;
using loginAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace loginAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {

        private readonly IUserService _userService; // Your user service interface

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            // Convert the id from string to int if necessary
            if (!int.TryParse(id, out var userId))
            {
                return BadRequest("Invalid user ID format.");
            }

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserDTO createUserDto)
        {
            // Validate input
            if (createUserDto == null)
            {
                return BadRequest("User data is required.");
            }

            var user = await _userService.CreateUserAsync(createUserDto);
            if (user == null)
            {
                return BadRequest("User creation failed.");
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDTO updateUserDto)
        {
            // Convert the id from string to int if necessary
            if (!int.TryParse(id, out var userId))
            {
                return BadRequest("Invalid user ID format.");
            }

            var result = await _userService.UpdateUserAsync(userId, updateUserDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}