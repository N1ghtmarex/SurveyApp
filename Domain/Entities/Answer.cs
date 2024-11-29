namespace Domain.Entities
{
    public class Answer : BaseEntity<Guid>
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public required Guid QuestionId { get; set; }
        public Question? Question { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
