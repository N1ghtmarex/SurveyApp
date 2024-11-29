using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Answers.Queries
{
    public class GetAnswerQuery : IRequest<AnswerViewModel>
    {
        [FromRoute]
        public required Guid AnswerId { get; set; }
    }
}
