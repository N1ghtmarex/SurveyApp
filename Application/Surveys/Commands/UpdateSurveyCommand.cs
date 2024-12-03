using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Commands
{
    public class UpdateSurveyCommand : IRequest
    {
        [FromBody]
        public required UpdateSurveyModel Body { get; set; }
    }
}
