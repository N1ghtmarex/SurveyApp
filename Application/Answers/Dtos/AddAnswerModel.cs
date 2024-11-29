namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель для добавления варианта ответа
    /// </summary>
    public class AddAnswerModel
    {
        /// <summary>
        /// Идентификатор вопроса, на который добавляется ответ
        /// </summary>
        public required string QuestionId { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
