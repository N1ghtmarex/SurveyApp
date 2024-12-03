namespace Application.Surveys.Dtos
{
    public class UpdateSurveyModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
