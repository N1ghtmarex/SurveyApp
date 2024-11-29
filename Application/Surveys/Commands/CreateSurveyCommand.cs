using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Surveys.Commands
{
    public class CreateSurveyCommand : IRequest<string>
    {
        [FromBody]
        public required CreateSurveyModel Body { get; set; }
    }
}
