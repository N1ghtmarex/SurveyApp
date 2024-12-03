using Domain.Enums;

namespace Application.Questions.Dtos
{
    /// <summary>
    /// Модель изменения вопроса
    /// </summary>
    public class UpdateQuestionModel
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public required Guid Id { get; set; }

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
