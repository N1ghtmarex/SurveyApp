using Domain.Enums;

namespace Application.Questions.Dtos
{
    /// <summary>
    /// Модель для добавления вопроса
    /// </summary>
    public class AddQuestionModel
    {
        /// <summary>
        /// Идентификатор опроса, к которому относится вопрос
        /// </summary>
        public required string SurveyId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public required QuestionTypeEnum Type { get; set; }
    }
}
