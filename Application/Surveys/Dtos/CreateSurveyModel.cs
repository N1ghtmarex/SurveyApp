using Application.Questions.Dtos;

namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель создания опроса
    /// </summary>
    public class CreateSurveyModel
    {
        /// <summary>
        /// Название опроса
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Описание опроса
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Список вопросов
        /// </summary>
        public required List<AddQuestionModel> Questions { get; set; }
    }
}
