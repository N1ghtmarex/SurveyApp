using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Questions.Commands
{
    public class UpdateQuestionCommand : IRequest
    {
        [FromBody]
        public required UpdateQuestionModel Body { get; set; }
    }
}
