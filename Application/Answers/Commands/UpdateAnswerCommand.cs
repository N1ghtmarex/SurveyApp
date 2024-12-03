using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Answers.Commands
{
    public class UpdateAnswerCommand : IRequest
    {
        [FromBody]
        public required UpdateAnswerModel Body { get; set; }
    }
}
