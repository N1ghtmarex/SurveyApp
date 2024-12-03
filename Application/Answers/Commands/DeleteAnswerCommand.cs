using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Answers.Commands
{
    [Description("Удаление варианта ответа")]
    public class DeleteAnswerCommand : IRequest
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        [FromRoute]
        public required Guid AnswerId { get; set; }
    }
}
