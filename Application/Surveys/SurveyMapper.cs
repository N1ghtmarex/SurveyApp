using Application.Surveys.Dtos;
using Domain.Entities;
using Domain.Enums;
using Mapster;

namespace Application.Surveys
{
    [Mapper]
    public interface ISurveyMapper
    {
        UserSurveyBind MapToBind((Guid userId, Guid surveyId) src);
        UserSurveyBindViewModel MapBindToViewModel(UserSurveyBind entity);
    }

    partial class SurveyMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(Guid UserId, Guid SurveyId), UserSurveyBind>()
                .Map(d => d.Status, src => SurveyStatusEnum.InProgress)
                .Map(d => d.UserId, src => src.UserId)
                .Map(d => d.SurveyId, src => src.SurveyId)
                .Map(d => d.StartedAt, src => DateTimeOffset.UtcNow);

            config.NewConfig<UserSurveyBind, UserSurveyBindViewModel>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.Status, src => src.Status)
                .Map(d => d.UserId, src => src.UserId)
                .Map(d => d.SurveyId, src => src.SurveyId)
                .Map(d => d.StartedAt, src => src.StartedAt)
                .Map(d => d.CompletedAt, src => src.CompletedAt);
        }
    }
}
