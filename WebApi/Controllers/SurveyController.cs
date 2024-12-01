using Application.Surveys.Commands;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/surveys")]
    public class SurveyController(ISender sender) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateSurvey(CreateSurveyCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        [HttpGet("{SurveyId}")]
        public async Task<SurveyViewModel> GetSurvey(GetSurveyQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        [HttpGet]
        public async Task<SurveyListViewModel> GetSurveys(CancellationToken cancellationToken)
        {
            return await sender.Send(new GetSurveysListQuery(), cancellationToken);
        }
    }
}
