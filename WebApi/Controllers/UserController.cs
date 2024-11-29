using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Application.Users.Commands;
using MediatR;

namespace WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthUserCommand command, CancellationToken cancellationToken)
        {
            var userId = await sender.Send(command, cancellationToken);

            if (userId != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }
    }
}
