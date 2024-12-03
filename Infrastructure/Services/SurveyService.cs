using Application.Abstractions.Interfaces;
using Application.Surveys.Dtos;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SurveyService(ApplicationDbContext dbContext) : ISurveyService
    {
        public async Task<Survey?> GetSurveyAsync(Guid id, CancellationToken cancellationToken, bool includeQuestions = false, bool includeAnswers = false)
        {
            var surveyQuery = dbContext.Surveys
                .Where(x => x.Id == id);

            if (includeQuestions)
            {
                surveyQuery = surveyQuery.Include(x => x.Questions);
            }

            if (includeAnswers)
            {
                surveyQuery = surveyQuery
                    .Include(x => x.Questions!)
                    .ThenInclude(x => x.Answers);
            }

            var survey = await surveyQuery.SingleOrDefaultAsync(cancellationToken);

            return survey;
        }

        public Task<UserSurveyBind?> GetUserSurveyBindAsync(Guid surveyId, Guid userId, CancellationToken cancellationToken, SurveyStatusEnum? status = null)
        {
            var query = dbContext.UserSurveyBinds
                .Where(x => x.UserId == userId && x.SurveyId == surveyId);

            if (status != null)
            {
                query = query.Where(x => x.Status == status);
            }
            
            var userSurveyBind = query.SingleOrDefaultAsync(cancellationToken);

            return userSurveyBind;
        }

        public void UpdateEntityStatus(Survey survey)
        {
            dbContext.Entry(survey).State = EntityState.Modified;
        }

        public async Task<List<SurveyViewModel>?> GetSurveysListAsync(CancellationToken cancellationToken)
        {
            var surveys = await dbContext.Surveys
                .ProjectToType<SurveyViewModel>()
                .ToListAsync(cancellationToken);

            return surveys;
        }
    }
}
