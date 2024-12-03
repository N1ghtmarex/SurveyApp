namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель начала/завершения опроса
    /// </summary>
    public class StartOrCompleteSurveyModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public required Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        public required Guid SurveyId { get; set; }
    }
}
