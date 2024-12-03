using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Surveys.Commands
{
    [Description("Удаление конкретного опроса")]
    public class DeleteSurveyCommand : IRequest
    {
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        [FromRoute]
        public required Guid SurveyId { get; set; }
    }
}
