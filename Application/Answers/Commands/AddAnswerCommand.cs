using Application.Abstractions.Models;
using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Answers.Commands
{
    [Description("Добавление варианта ответа")]
    public class AddAnswerCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required AddAnswerModel Body { get; set; }
    }
}
