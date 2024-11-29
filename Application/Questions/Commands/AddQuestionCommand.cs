using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Questions.Commands
{
    public class AddQuestionCommand : IRequest<string>
    {
        [FromBody]
        public required AddQuestionModel Body { get; set; }
    }
}
