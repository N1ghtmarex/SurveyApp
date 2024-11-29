using Application.Questions.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class QuestionController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> AddQuestion(AddQuestionCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }
    }
}
