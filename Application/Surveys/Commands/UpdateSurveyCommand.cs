using Application.Abstractions.Models;
using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Surveys.Commands
{
    [Description("Изменение данных опроса")]
    public class UpdateSurveyCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required UpdateSurveyModel Body { get; set; }
    }
}
