using Application.Answers.Dtos;
using Domain.Enums;

namespace Application.Questions.Dtos
{
    public class QuestionViewModel
    {
        public required Guid Id { get; set; }
        public required Guid SurveyId { get; set; }
        public required string Title { get; set; }
        public required QuestionTypeEnum Type { get; set; }
        public List<AnswerViewModel>? Answers { get; set; }
    }
}
