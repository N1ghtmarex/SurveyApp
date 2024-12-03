using Application.Abstractions.Models;
using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Questions.Commands
{
    [Description("Добавление вопроса")]
    public class AddQuestionCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromBody]
        public required AddQuestionModel Body { get; set; }
    }
}
