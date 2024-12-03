using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Surveys.Commands
{
    [Description("Завершение прохождения опроса")]
    public class CompleteSurveyCommand : IRequest
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required StartOrCompleteSurveyModel Body { get; set; }
    }
}
