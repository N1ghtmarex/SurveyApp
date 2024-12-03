namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель для обновления варианта ответа
    /// </summary>
    public class UpdateAnswerModel
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
