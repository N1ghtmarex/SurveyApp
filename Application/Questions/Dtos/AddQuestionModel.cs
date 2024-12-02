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
        /// Текст вопроса
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public required QuestionTypeEnum Type { get; set; }
        public required List<AddAnswerModel> Answers { get; set; }
    }
}
