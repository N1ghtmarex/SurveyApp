using Application.Abstractions.Models;
using Application.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Users.Commands
{
    [Description("Регистрация пользователя")]
    public class CreateUserCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required CreateUserModel Body { get; set; }
    }
}
