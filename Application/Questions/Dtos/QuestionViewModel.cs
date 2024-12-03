using Application.Answers.Dtos;
using Domain.Enums;

namespace Application.Questions.Dtos
{
    /// <summary>
    /// Модель вопроса 
    /// </summary>
    public class QuestionViewModel
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid SurveyId { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public required QuestionTypeEnum Type { get; set; }

        /// <summary>
        /// Список вариантов ответа
        /// </summary>
        public List<AnswerViewModel>? Answers { get; set; }
    }
}
