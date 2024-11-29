using Application.Answers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/answer")]
    public class AnswerController(ISender sender) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<ActionResult<string>> AddAnswer(AddAnswerCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }
    }
}
