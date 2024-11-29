using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController() : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "person.Email") };
            
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return NoContent();
        }
        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return NoContent();
        }
    }
}
