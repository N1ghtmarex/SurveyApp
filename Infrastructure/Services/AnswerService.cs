using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AnswerService(ApplicationDbContext dbContext) : IAnswerService
    {
        public async Task<Answer?> GetAnswerAsync(Guid id, CancellationToken cancellationToken)
        {
            var answer = await dbContext.Answers
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            return answer;
        }

        public async Task<List<Answer>?> GetAnswersListByQuestionAsync(Guid questionId, CancellationToken cancellationToken)
        {
            var answers = await dbContext.Answers
                .Where(x => x.QuestionId == questionId)
                .ToListAsync(cancellationToken);

            return answers;
        }
    }
}
