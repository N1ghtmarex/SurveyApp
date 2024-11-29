using Application.Questions.Commands;
using Application.Questions.Dtos;
using Application.Questions.Queries;
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

        [HttpGet("question-id={QuestionId}")]
        public async Task<QuestionViewModel> GetQuestion(GetQuestionQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        [HttpGet("survey-id={SurveyId}")]
        public async Task<QuestionListViewModel> GetQuestions(GetQuestionsListQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }
    }
}
