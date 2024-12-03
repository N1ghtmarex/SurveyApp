using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Связь пользователя и опроса
    /// </summary>
    public class UserSurveyBind : BaseEntity<Guid>
    {
        /// <summary>
        /// Статус опроса
        /// </summary>
        public required SurveyStatusEnum Status { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid SurveyId { get; set; }
        public Survey? Survey { get; set; }

        /// <summary>
        /// Ответы
        /// </summary>
        public ICollection<Answer>? Answers { get; set; }

        /// <summary>
        /// Время начала
        /// </summary>
        public required DateTimeOffset StartedAt { get; set; }

        /// <summary>
        /// Время завершения
        /// </summary>
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
