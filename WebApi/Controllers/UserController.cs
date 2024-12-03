using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Application.Users.Commands;
using MediatR;
using Application.Abstractions.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер пользователей
    /// </summary>
    /// <param name="sender">Mediatr</param>
    [Route("api/users")]
    [ApiController]
    public class UserController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор пользователя</returns>
        [HttpPost("register")]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Register(CreateUserCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Установка cooikies</returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthUserCommand command, CancellationToken cancellationToken)
        {
            var userId = await sender.Send(command, cancellationToken);

            if (userId != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId.Value.ToString()) };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                HttpContext.Response.Cookies.Append("auth_status", "true", new CookieOptions
                {
                    HttpOnly = false,
                });

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns>Удаление cooikes</returns>
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Response.Cookies.Delete("auth_status");

            return NoContent();
        }
    }
}
