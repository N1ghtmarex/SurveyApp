using Application.Questions.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Application.Questions.Queries
{
    [Description("Получение списка вопросов")]
    public class GetQuestionsListQuery : IRequest<QuestionListViewModel>
    {
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        [FromRoute]
        public required Guid SurveyId { get; set; }
    }
}
