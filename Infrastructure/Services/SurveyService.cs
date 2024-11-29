using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SurveyService(ApplicationDbContext dbContext) : ISurveyService
    {
        public async Task<Survey?> GetSurveyAsync(string id, CancellationToken cancellationToken, bool includeQuestions = false, bool includeAnswers = false)
        {
            var surveyQuery = dbContext.Surveys
                .Where(x => x.Id == Guid.Parse(id));

            if (includeQuestions)
            {
                surveyQuery = surveyQuery.Include(x => x.Questions);
            }

            if (includeAnswers)
            {
                surveyQuery = surveyQuery
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers);
            }

            var survey = await surveyQuery.SingleOrDefaultAsync(cancellationToken);

            return survey;
        }
    }
}
