using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Answers.Commands
{
    public class DeleteAnswerCommand : IRequest
    {
        [FromRoute]
        public required Guid AnswerId { get; set; }
    }
}
