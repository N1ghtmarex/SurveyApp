namespace Application.Surveys.Dtos
{
    public class StartSurveyModel
    {
        public Guid? UserId { get; set; }
        public required Guid SurveyId { get; set; }
    }
}
