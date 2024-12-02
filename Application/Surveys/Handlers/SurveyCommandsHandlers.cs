using Application.Abstractions.Interfaces;
using Application.Answers;
using Application.Questions;
using Application.Surveys.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Surveys.Handlers
{
    public class SurveyCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService,
        IQuestionMapper questionMapper, IAnswerMapper answerMapper)
        : IRequestHandler<CreateSurveyCommand, string>, IRequestHandler<StartSurveyCommand, string>, IRequestHandler<CompleteSurveyCommand, string>
    {
        public async Task<string> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var surveyToCreate = new Survey
            { 
                Name = request.Body.Name,
                Description = request.Body.Description,
            };

            var createdSurvey = await dbContext.AddAsync(surveyToCreate);

            var questions = request.Body.Questions
                .Select(x => questionMapper.MapToEntity((x, createdSurvey.Entity.Id)))
                .ToList();

            await dbContext.AddRangeAsync(questions, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);


            for (var i = 0; i < questions.Count; i++)
            {
                var answersToCreate = request.Body.Questions[i].Answers.ToList();

                var answers = answersToCreate.Select(x => answerMapper.MapToEntity((x, questions[i].Id)));

                await dbContext.AddRangeAsync(answers, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

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
                .FirstOrDefaultAsync(cancellationToken);

            if (userSurveyInProgressBinds != null)
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

            var createdUserSurveyBind = await dbContext.UserSurveyBinds.AddAsync(userSurveyBindToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdUserSurveyBind.Entity.Id.ToString();
        }

        public async Task<string> Handle(CompleteSurveyCommand request, CancellationToken cancellationToken)
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
                .FirstOrDefaultAsync(cancellationToken);

            if (userSurveyInProgressBinds == null)
            {
                throw new BusinessLogicException($"Вы еще не начали попытку!");
            }

            userSurveyInProgressBinds.Status = SurveyStatusEnum.Completed;
            userSurveyInProgressBinds.CompletedAt = DateTimeOffset.UtcNow;
            await dbContext.SaveChangesAsync();

            return "Попытка завершена!";
        }
    }
}
