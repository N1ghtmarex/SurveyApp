using Application.Answers.Dtos;
using Domain.Enums;

namespace Application.Questions.Dtos
{
    /// <summary>
    /// Модель для добавления вопроса
    /// </summary>
    public class AddQuestionModel
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public Guid SurveyId { get; set; }

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
        public List<AddAnswerModel>? Answers { get; set; }
    }
}
