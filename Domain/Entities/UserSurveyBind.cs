using Domain.Enums;

namespace Domain.Entities
{
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
        public required ICollection<Answer> Answers { get; set; }

        /// <summary>
        /// Время завершения
        /// </summary>
        public required DateTimeOffset CompletedAt { get; set; }
    }
}
