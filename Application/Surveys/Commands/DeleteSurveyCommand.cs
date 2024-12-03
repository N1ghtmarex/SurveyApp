using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Commands
{
    public class DeleteSurveyCommand : IRequest
    {
        [FromRoute]
        public required Guid SurveyId { get; set; }
    }
}
