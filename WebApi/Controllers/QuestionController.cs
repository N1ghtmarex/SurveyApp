using Application.Abstractions.Models;
using Application.Questions.Commands;
using Application.Questions.Dtos;
using Application.Questions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер вопросов
    /// </summary>
    /// <param name="sender">Mediatr</param>
    [ApiController]
    [Route("api/question")]
    public class QuestionController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Добавление вопроса
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор вопроса</returns>
        [HttpPost]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> AddQuestion(AddQuestionCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получение конкретного вопроса
        /// </summary>
        /// <param name="query">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Модель вопроса</returns>
        [HttpGet("question-id={QuestionId}")]
        public async Task<QuestionViewModel> GetQuestion(GetQuestionQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Получение списка вопросов конкретного опроса
        /// </summary>
        /// <param name="query">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список вопросов</returns>
        [HttpGet("survey-id={SurveyId}")]
        public async Task<QuestionListViewModel> GetQuestions(GetQuestionsListQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Изменение конкретного вопроса
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор вопроса</returns>
        [HttpPut]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> UpdateQuestion(UpdateQuestionCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Удаление конкретного вопроса
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        [HttpDelete("{questionId}")]
        public async Task<ActionResult> DeleteQuestion(DeleteQuestionCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
