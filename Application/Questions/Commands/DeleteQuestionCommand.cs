using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Questions.Commands
{
    public class DeleteQuestionCommand : IRequest
    {
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
