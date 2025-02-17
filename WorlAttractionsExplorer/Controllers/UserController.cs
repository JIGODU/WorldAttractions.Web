using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WorldAttractionsExplorer.DataAccess.DTOs;
using WorldAttractionsExplorer.Services.Access;

namespace WorldAttractionsExplorer.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController(UserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await userService.RegisterUserAsync(model);

            if (!result) return BadRequest();

            await userService.AddRoleToUserAsync(new() { UserId = user.Id, Role = "User"});

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await userService.LoginUserAsync(model);
            if (result is null) return Unauthorized("Invalid credentials.");

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("promote")]
        public async Task<IActionResult> AssignRole([FromBody] AssignModel model)
        {
            var result = await userService.AddRoleToUserAsync(model);

            if (!result)
                return BadRequest("Cannot do this.");
            return Ok(new { message = "Role assigned successfully!" });
        }
    }
}
