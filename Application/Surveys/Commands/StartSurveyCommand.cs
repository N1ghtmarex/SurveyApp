using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Surveys.Commands
{
    [Description("Начать прохождение опроса")]
    public class StartSurveyCommand : IRequest
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required StartOrCompleteSurveyModel Body { get; set; }
    }
}
