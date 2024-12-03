using Application.Answers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Answers.Queries
{
    [Description("Получение конкретного варианта ответа")]
    public class GetAnswerQuery : IRequest<AnswerViewModel>
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        [FromRoute]
        public required Guid AnswerId { get; set; }
    }
}
