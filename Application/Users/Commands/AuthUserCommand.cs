using Application.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Users.Commands
{
    public class AuthUserCommand : IRequest<string>
    {
        [FromBody]
        public required AuthUserModel Body { get; set; }
    }
}
