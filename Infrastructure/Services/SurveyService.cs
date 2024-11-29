using Application.Abstractions.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SurveyService(ApplicationDbContext dbContext) : ISurveyService
    {
        public async Task<Survey?> GetSurveyAsync(string id, CancellationToken cancellationToken)
        {
            var survey = await dbContext.Surveys
                .Where(x => x.Id == Guid.Parse(id))
                .SingleOrDefaultAsync(cancellationToken);

            return survey;
        }
    }
}
