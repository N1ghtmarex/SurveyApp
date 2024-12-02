using Domain.Enums;

namespace Application.Surveys.Dtos
{
    public class UserSurveyBindViewModel
    {
        public required Guid Id { get; set; }
        public required SurveyStatusEnum Status { get; set; }
        public required Guid UserId { get; set; }
        public required Guid SurveyId { get; set; }
        public required DateTimeOffset StartedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
