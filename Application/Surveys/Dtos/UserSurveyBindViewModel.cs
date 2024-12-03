using Domain.Enums;

namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель добавления связи между пользователем и опросом
    /// </summary>
    public class UserSurveyBindViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Статус опроса
        /// </summary>
        public required SurveyStatusEnum Status { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid SurveyId { get; set; }

        /// <summary>
        /// Дата начала прохождения
        /// </summary>
        public required DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// Дата завершения прохождения
        /// </summary>
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
