using Application.Surveys.Commands;
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
    }
}
