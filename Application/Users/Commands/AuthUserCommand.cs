using Application.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Users.Commands
{
    [Description("Авторизация пользователя")]
    public class AuthUserCommand : IRequest<Guid?>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required AuthUserModel Body { get; set; }
    }
}
