using MediatR;

namespace Application.Surveys.Queries
{
    public class GetSurveyStatusQuery : IRequest<string>
    {
        public required Guid UserId { get; set; }
        public required Guid SurveyId { get; set; }
    }
}
