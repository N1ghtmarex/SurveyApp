using Application.Questions.Dtos;

namespace Application.Surveys.Dtos
{
    public class CreateSurveyModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required List<AddQuestionModel> Questions { get; set; }
    }
}
