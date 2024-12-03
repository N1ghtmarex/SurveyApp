using Application.Abstractions.Models;
using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Answers.Commands
{
    [Description("Обновление варианта ответа")]
    public class UpdateAnswerCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required UpdateAnswerModel Body { get; set; }
    }
}
