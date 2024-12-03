using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Questions.Commands
{
    [Description("Удаление вопроса")]
    public class DeleteQuestionCommand : IRequest
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
