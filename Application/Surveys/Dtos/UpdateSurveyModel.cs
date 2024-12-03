namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель изменения опроса
    /// </summary>
    public class UpdateSurveyModel
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
    }
}
