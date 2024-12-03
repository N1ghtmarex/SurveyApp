using Application.Abstractions.Models;
using Application.Choice.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Choice.Commands
{
    [Description("Выбор варианта ответа")]
    public class AddChoiceCommand : IRequest<CreatedOrUpdatedEntityViewModel<Guid>>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        public required Guid UserId { get; set; }
        public required Guid AnswerId { get; set; }
    }
}
