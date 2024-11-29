using Domain.Entities;

namespace Application.Abstractions.Interfaces
{
    public interface ISurveyService
    {
        Task<Survey?> GetSurveyAsync(string id, CancellationToken cancellationToken, bool includeQuestions = false, bool includeAnswers = false);
    }
}
