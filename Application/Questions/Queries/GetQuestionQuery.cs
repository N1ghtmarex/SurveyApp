using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Questions.Queries
{
    [Description("Получение конкретного вопроса")]
    public class GetQuestionQuery : IRequest<QuestionViewModel>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
