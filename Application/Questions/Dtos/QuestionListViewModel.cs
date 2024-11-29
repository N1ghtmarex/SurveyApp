namespace Application.Questions.Dtos
{
    /// <summary>
    /// Модель списка вопросов
    /// </summary>
    public class QuestionListViewModel
    {
        /// <summary>
        /// Вопросы
        /// </summary>
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
