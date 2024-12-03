using Domain.Entities;

namespace Application.Abstractions.Interfaces
{
    public interface IQuestionService
    {
        Task<Question?> GetQuestionAsync(Guid questionId, CancellationToken cancellationToken);
    }
}
