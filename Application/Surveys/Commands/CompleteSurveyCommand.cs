using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Commands
{
    public class CompleteSurveyCommand : IRequest<string>
    {
        [FromBody]
        public required StartOrCompleteSurveyModel Body { get; set; }
    }
}
