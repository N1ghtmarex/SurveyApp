using Application.Abstractions.Interfaces;
using Application.Surveys.Commands;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Surveys.Handlers
{
    public class SurveyCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<CreateSurveyCommand, string>
    {
        public async Task<string> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var surveyToCreate = new Survey
            {
                Name = request.Body.Name
            };

            if (request.Body.Description != null)
            {
                surveyToCreate.Description = request.Body.Description;
            }

            var createdSurvey = await dbContext.AddAsync(surveyToCreate);
            await dbContext.SaveChangesAsync();

            return createdSurvey.Entity.Id.ToString();
        }
    }
}
