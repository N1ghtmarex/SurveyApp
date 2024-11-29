using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Queries
{
    public class GetSurveyQuery : IRequest<SurveyViewModel>
    {
        [FromRoute]
        public required Guid SurveyId { get; set; }
    }
}
