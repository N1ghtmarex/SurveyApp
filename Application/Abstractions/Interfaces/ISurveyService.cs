using Application.Surveys.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Application.Abstractions.Interfaces
{
    public interface ISurveyService
    {
        Task<Survey?> GetSurveyAsync(Guid id, CancellationToken cancellationToken, bool includeQuestions = false, bool includeAnswers = false);
        Task<List<SurveyViewModel>?> GetSurveysListAsync(CancellationToken cancellationToken);
        void UpdateEntityStatus(Survey survey);
        Task<UserSurveyBind?> GetUserSurveyBindAsync(Guid surveyId, Guid userId, CancellationToken cancellationToken, SurveyStatusEnum? status = null);
    }
}
