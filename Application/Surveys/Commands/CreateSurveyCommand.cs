using Application.Abstractions.Models;
using Application.Surveys.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Surveys.Commands
{
    [Description("Создание опроса")]
    public class CreateSurveyCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required CreateSurveyModel Body { get; set; }
    }
}
