using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Questions.Queries
{
    public class GetQuestionsListQuery : IRequest<QuestionListViewModel>
    {
        [FromRoute]
        public required Guid SurveyId { get; set; }
    }
}
