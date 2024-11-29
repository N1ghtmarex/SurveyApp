using Application.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Users.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        [FromBody]
        public required CreateUserModel Body { get; set; }
    }
}
