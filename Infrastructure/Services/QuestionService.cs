using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class QuestionService(ApplicationDbContext dbContext) : IQuestionService
    {
        public async Task<Question?> GetQuestionAsync(Guid questionId, CancellationToken cancellationToken)
        {
            return await dbContext.Questions
                .Where(x => x.Id == questionId)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
