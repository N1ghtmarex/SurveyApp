using Application.Surveys.Dtos;
using MediatR;

namespace Application.Surveys.Queries
{
    public class GetUserSurveyBindQuery : IRequest<UserSurveyBindViewModel>
    {
        public required Guid UserId { get; set; }
        public required Guid SurveyId { get; set; }
    }
}
