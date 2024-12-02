namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель для добавления варианта ответа
    /// </summary>
    public class AddAnswerModel
    { 
        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public required string Title { get; set; }
    }
}
