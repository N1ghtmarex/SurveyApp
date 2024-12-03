using Application.Abstractions.Models;
using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Questions.Commands
{
    [Description("Изменение вопроса")]
    public class UpdateQuestionCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required UpdateQuestionModel Body { get; set; }
    }
}
