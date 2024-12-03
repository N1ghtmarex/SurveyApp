namespace Application.Surveys.Dtos
{
    /// <summary>
    /// Модель списка опросов
    /// </summary>
    public class SurveyListViewModel
    {
        /// <summary>
        /// Список опросов
        /// </summary>
        public required List<SurveyViewModel> Surveys { get; set; }
    }
}
