namespace Application.Answers.Dtos
{
    /// <summary>
    /// Модель списка вариантов ответа
    /// </summary>
    public class AnswerListViewModel
    {
        /// <summary>
        /// Варианты ответа
        /// </summary>
        public required List<AnswerViewModel> Answers { get; set; }
    }
}
