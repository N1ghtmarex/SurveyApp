namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель для добавления варианта ответа
    /// </summary>
    public class AddAnswerModel
    { 
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public Guid QuestionId { get; set; }
        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
