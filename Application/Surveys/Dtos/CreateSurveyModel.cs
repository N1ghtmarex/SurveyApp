namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель для создания опроса
    /// </summary>
    public class CreateSurveyModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}
