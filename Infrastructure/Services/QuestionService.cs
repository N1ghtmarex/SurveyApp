using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class QuestionService(ApplicationDbContext dbContext) : IQuestionService
    {
        public async Task<List<Answer>?> GetQuestionAnswersAsync(Guid questionId, CancellationToken cancellationToken)
        {
            var questionAnswers = await dbContext.Answers
                .Where(x => x.QuestionId == questionId)
                .ToListAsync(cancellationToken);

            return questionAnswers;
        }

        public async Task<Question?> GetQuestionAsync(Guid questionId, CancellationToken cancellationToken, bool includeAnswers = false)
        {
            var query = dbContext.Questions
                .Where(x => x.Id == questionId);

            if (includeAnswers)
            {
                query = query.Include(x => x.Answers);
            }

            var question = await query.SingleOrDefaultAsync(cancellationToken);

            return question;
        }
    }
}
