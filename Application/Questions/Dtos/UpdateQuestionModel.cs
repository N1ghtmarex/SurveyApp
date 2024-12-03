using Domain.Enums;

namespace Application.Questions.Dtos
{
    public class UpdateQuestionModel
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required QuestionTypeEnum Type { get; set; }
    }
}
