using Application.Abstractions.Models;
using Application.Answers.Commands;
using Application.Answers.Dtos;
using Application.Answers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер вариантов ответа
    /// </summary>
    /// <param name="sender">Mediatr</param>
    [ApiController]
    [Route("api/answer")]
    public class AnswerController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Добавление варианта ответа
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор варианта ответа</returns>
        [HttpPost("add")]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> AddAnswer(AddAnswerCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получение конкретного варианта ответа
        /// </summary>
        /// <param name="query">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Модель варианта ответа</returns>
        [HttpGet("answer-id={AnswerId}")]
        public async Task<AnswerViewModel> GetAnswer([FromQuery] GetAnswerQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Получение списка вариантов ответа
        /// </summary>
        /// <param name="query">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список вариантов ответа</returns>
        [HttpGet("question-id={QuestionId}")]
        public async Task<AnswerListViewModel> GetAnswers([FromQuery] GetAnswerListQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Изменение конкретного варианта ответа
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор варианта ответа</returns>
        [HttpPut]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> UpdateAnswer(UpdateAnswerCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Удаление конкретного варианта ответа
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        [HttpDelete("{answerId}")]
        public async Task<ActionResult> DeleteAnswer(DeleteAnswerCommand command, CancellationToken cancellationToken)
        {
            await sender.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
