using Application.Questions.Dtos;

namespace Application.Surveys.Dtos
{
    public class SurveyViewModel
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
        public required DateTimeOffset CreatedAt { get; set; }
        public required DateTimeOffset UpdatedAt { get; set; }
    }
}
