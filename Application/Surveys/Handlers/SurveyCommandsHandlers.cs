using Application.Abstractions.Interfaces;
using Application.Surveys.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Surveys.Handlers
{
    public class SurveyCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<CreateSurveyCommand, string>, IRequestHandler<StartSurveyCommand, string>
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

        public async Task<string> Handle(StartSurveyCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Where(x => x.Id == request.Body.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.Body.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.Body.SurveyId.ToString(), cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.SurveyId}\" не найден!");
            }

            var userSurveyInProgressBinds = await dbContext.UserSurveyBinds
                .Where(x => x.UserId == user.Id && x.SurveyId == survey.Id && x.Status == SurveyStatusEnum.InProgress)
                .ToListAsync(cancellationToken);

            if (userSurveyInProgressBinds.Count != 0)
            {
                throw new BusinessLogicException($"Завершите предыдущую попытку прежде чем начать новую!");
            }

            var userSurveyBindToCreate = new UserSurveyBind
            {
                UserId = user.Id,
                SurveyId = survey.Id,
                Status = SurveyStatusEnum.InProgress,
                StartedAt = DateTimeOffset.UtcNow
            };

            var createdUserSurveyBind = await dbContext.UserSurveyBinds.AddAsync(userSurveyBindToCreate);
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdUserSurveyBind.Entity.Id.ToString();
        }
    }
}
