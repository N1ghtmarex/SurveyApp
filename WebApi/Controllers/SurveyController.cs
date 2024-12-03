using Application.Questions.Commands;
using Application.Surveys.Commands;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost("start")]
        public async Task<string> StartSurvey(StartOrCompleteSurveyModel model, CancellationToken cancellationToken)
        {
            model.UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return await sender.Send(new StartSurveyCommand { Body = model }, cancellationToken);
        }

        [HttpPost("complete")]
        public async Task<string> CompleteSurvey(StartOrCompleteSurveyModel model, CancellationToken cancellationToken)
        {
            model.UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            return await sender.Send(new CompleteSurveyCommand { Body = model }, cancellationToken);
        }

        [HttpGet("status/{surveyId}")]
        public async Task<string> GetSurveyStatus([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetSurveyStatusQuery
            {
                UserId = userId,
                SurveyId = surveyId
            };

            return await sender.Send(query, cancellationToken);
        }

        [HttpGet("bind/{surveyId}")]
        public async Task<UserSurveyBindViewModel> GetUserSurveyBind([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var query = new GetUserSurveyBindQuery
            {
                UserId = userId,
                SurveyId = surveyId
            };

            return await sender.Send(query, cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSurvey(UpdateSurveyCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{surveyId}")]
        public async Task<ActionResult> DeleteSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var command = new DeleteSurveyCommand { SurveyId = surveyId };
            await sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
