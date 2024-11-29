using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Answers.Queries
{
    public class GetAnswerListQuery : IRequest<AnswerListViewModel>
    {
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
