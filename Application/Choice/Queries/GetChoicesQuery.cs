using Application.Choice.Dtos;
using MediatR;
using System.ComponentModel;

namespace Application.Choice.Queries
{
    [Description("Получение списка выбранных ответов")]
    public class GetChoicesQuery : IRequest<ChoiceListViewModel>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }
        
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid SurveyId { get; set; }
    }
}
