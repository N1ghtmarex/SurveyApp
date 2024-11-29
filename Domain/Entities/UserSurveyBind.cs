namespace Domain.Entities
{
    public class UserSurveyBind : BaseEntity<Guid>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Идентификатор теста
        /// </summary>
        public required Guid TestId { get; set; }
        public Survey? Test { get; set; }

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
