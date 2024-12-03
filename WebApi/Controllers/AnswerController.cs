using Application.Answers.Commands;
using Application.Answers.Dtos;
using Application.Answers.Queries;
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

        [HttpGet("answer-id={AnswerId}")]
        public async Task<AnswerViewModel> GetAnswer([FromQuery] GetAnswerQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        [HttpGet("question-id={QuestionId}")]
        public async Task<AnswerListViewModel> GetAnswers([FromQuery] GetAnswerListQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAnswer(UpdateAnswerCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{answerId}")]
        public async Task<ActionResult> DeleteAnswer(DeleteAnswerCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
