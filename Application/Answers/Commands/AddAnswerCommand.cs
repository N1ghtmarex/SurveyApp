using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Answers.Commands
{
    public class AddAnswerCommand : IRequest<string>
    {
        [FromBody]
        public required AddAnswerModel Body { get; set; }
    }
}
