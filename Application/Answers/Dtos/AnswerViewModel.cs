namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель варианта ответа
    /// </summary>
    public class AnswerViewModel
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public required Guid QuestionId { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
