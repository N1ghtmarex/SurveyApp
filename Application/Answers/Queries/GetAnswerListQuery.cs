using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Answers.Queries
{
    [Description("Получение вариантов ответа для конкретного вопроса")]
    public class GetAnswerListQuery : IRequest<AnswerListViewModel>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        [FromRoute]
        public required Guid QuestionId { get; set; }
    }
}
