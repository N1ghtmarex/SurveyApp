using Application.Abstractions.Models;
using Application.Choice.Commands;
using Application.Choice.Dtos;
using Application.Choice.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер выбора ответа
    /// </summary>
    /// <param name="sender">Mediatr</param>
    [ApiController]
    [Route("api/choice")]
    public class ChoiceController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Выбор варианта ответа
        /// </summary>
        /// <param name="model">Модель запроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор ответа пользователя</returns>
        [HttpPost]
        [Authorize]
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> MakeChoice([FromBody] AddChoiceModel model, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);

            var command = new AddChoiceCommand
            {
                UserId = userId,
                AnswerId = model.AnswerId,
            };

            return await sender.Send(command, cancellationToken);
        }

        /// <summary>
        /// Получение ответов пользователя
        /// </summary>
        /// <param name="surveyId">Идентификатор опроса</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список ответов</returns>
        [HttpGet("survey/{surveyId}")]
        [Authorize]
        public async Task<ChoiceListViewModel> GetChoices([FromRoute] Guid surveyId, CancellationToken cancellationToken)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            var query = new GetChoicesQuery
            {
                UserId = Guid.Parse(userId),
                SurveyId = surveyId
            };

            return await sender.Send(query, cancellationToken);
        }
    }
}
