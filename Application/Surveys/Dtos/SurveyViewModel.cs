using Application.Questions.Dtos;

namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель опроса
    /// </summary>
    public class SurveyViewModel
    {
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid Id { get; set; }

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
        public List<QuestionViewModel>? Questions { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public required DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public required DateTimeOffset UpdatedAt { get; set; }
    }
}
