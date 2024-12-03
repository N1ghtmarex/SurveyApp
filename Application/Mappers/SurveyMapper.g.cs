using System;
using Application.Surveys;
using Application.Surveys.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Surveys
{
    public partial class SurveyMapper : ISurveyMapper
    {
        public UserSurveyBind MapToBind(ValueTuple<Guid, Guid> p1)
        {
            return new UserSurveyBind()
            {
                Status = SurveyStatusEnum.InProgress,
                UserId = p1.Item1,
                SurveyId = p1.Item2,
                StartedAt = DateTimeOffset.UtcNow
            };
        }
        public UserSurveyBindViewModel MapBindToViewModel(UserSurveyBind p2)
        {
            return p2 == null ? null : new UserSurveyBindViewModel()
            {
                Id = p2.Id,
                Status = p2.Status,
                UserId = p2.UserId,
                SurveyId = p2.SurveyId,
                StartedAt = p2.StartedAt,
                CompletedAt = p2.CompletedAt
            };
        }
    }
}