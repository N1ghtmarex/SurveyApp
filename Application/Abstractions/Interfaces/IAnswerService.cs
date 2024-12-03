using Domain.Entities;

namespace Application.Abstractions.Interfaces
{
    public interface IAnswerService
    {
        Task<Answer?> GetAnswerAsync(Guid id, CancellationToken cancellationToken);
        Task<List<Answer>?> GetAnswersListByQuestionAsync(Guid questionId, CancellationToken cancellationToken);
    }
}
