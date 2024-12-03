namespace Application.Surveys.Dtos
{
    public class StartOrCompleteSurveyModel
    {
        public Guid UserId { get; set; }
        public required Guid SurveyId { get; set; }
    }
}
