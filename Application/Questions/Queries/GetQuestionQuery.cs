using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Questions.Queries
{
    public class GetQuestionQuery : IRequest<QuestionViewModel>
    {
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
