namespace Domain.Entities
{
    /// <summary>
    /// Ответ
    /// </summary>
    public class Choice : BaseEntity<Guid>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }
        public User? User { get; set; }

        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public required Guid QuestionId { get; set; }
        public Question? Question { get; set; }

        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public required Guid AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}
