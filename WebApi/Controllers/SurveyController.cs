using Application.Abstractions.Models;
using Application.Surveys.Commands;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер опросов
    /// </summary>
    /// <param name="sender">Mediatr</param>
    [ApiController]
    [Route("api/surveys")]
    public class SurveyController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Создание опроса
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор опроса</returns>
        [HttpPost("create")]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> CreateSurvey(CreateSurveyCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получение конкретного опроса
        /// </summary>
        /// <param name="query">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Модель опроса</returns>
        [HttpGet("{SurveyId}")]
        public async Task<SurveyViewModel> GetSurvey(GetSurveyQuery query, CancellationToken cancellationToken)
        {
            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Получние списка опросов
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список опросов</returns>
        [HttpGet]
        public async Task<SurveyListViewModel> GetSurveys(CancellationToken cancellationToken)
        {
            return await sender.Send(new GetSurveysListQuery(), cancellationToken);
        }

        /// <summary>
        /// Запуск прохожения опроса
        /// </summary>
        /// <param name="surveyId">Идентификатор опроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        [HttpPost("start/{surveyId}")]
        [Authorize]
        public async Task<ActionResult> StartSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var model = new StartOrCompleteSurveyModel 
            { 
                SurveyId = surveyId,
                UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value)
            };

            await sender.Send(new StartSurveyCommand { Body = model }, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Завершение прохождения опроса
        /// </summary>
        /// <param name="surveyId">Идентификатор опроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        [HttpPost("complete/{surveyId}")]
        [Authorize]
        public async Task<ActionResult> CompleteSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var model = new StartOrCompleteSurveyModel
            {
                SurveyId = surveyId,
                UserId = Guid.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value)
            };

            await sender.Send(new CompleteSurveyCommand { Body = model }, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Получение связи пользователя и опроса
        /// </summary>
        /// <param name="surveyId">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Модель связи</returns>
        [HttpGet("bind/{surveyId}")]
        [Authorize]
        public async Task<UserSurveyBindViewModel> GetUserSurveyBind([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);

            var query = new GetUserSurveyBindQuery
            {
                UserId = userId,
                SurveyId = surveyId
            };

            return await sender.Send(query, cancellationToken);
        }

        /// <summary>
        /// Изменение конкретного опроса
        /// </summary>
        /// <param name="command">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> UpdateSurvey(UpdateSurveyCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Удаление опроса
        /// </summary>
        /// <param name="surveyId">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой опрос</returns>
        [HttpDelete("{surveyId}")]
        public async Task<ActionResult> DeleteSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var command = new DeleteSurveyCommand { SurveyId = surveyId };
            await sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
