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
    public class SurveyCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService, ISurveyMapper surveyMapper,
        IQuestionMapper questionMapper, IAnswerMapper answerMapper, IUserService userService)
        : IRequestHandler<CreateSurveyCommand, string>, IRequestHandler<StartSurveyCommand, string>, IRequestHandler<CompleteSurveyCommand, string>,
        IRequestHandler<UpdateSurveyCommand>, IRequestHandler<DeleteSurveyCommand>
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
            var user = await userService.GetUserByIdAsync(request.Body.UserId, cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.Body.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.Body.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.SurveyId}\" не найден!");
            }

            var userSurveyInProgressBinds = await surveyService.GetUserSurveyBindAsync(survey.Id, user.Id, cancellationToken, status: SurveyStatusEnum.InProgress);

            if (userSurveyInProgressBinds != null)
            {
                throw new BusinessLogicException($"Завершите предыдущую попытку прежде чем начать новую!");
            }

            var userSurveyBindToCreate = surveyMapper.MapToBind((user.Id, survey.Id));

            var createdUserSurveyBind = await dbContext.UserSurveyBinds.AddAsync(userSurveyBindToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdUserSurveyBind.Entity.Id.ToString();
        }

        public async Task<string> Handle(CompleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByIdAsync(request.Body.UserId, cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.Body.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.Body.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.SurveyId}\" не найден!");
            }

            var userSurveyInProgressBinds = await surveyService.GetUserSurveyBindAsync(survey.Id, user.Id, cancellationToken, status: SurveyStatusEnum.InProgress);

            if (userSurveyInProgressBinds == null)
            {
                throw new BusinessLogicException($"Вы еще не начали попытку!");
            }

            userSurveyInProgressBinds.Status = SurveyStatusEnum.Completed;
            userSurveyInProgressBinds.CompletedAt = DateTimeOffset.UtcNow;
            await dbContext.SaveChangesAsync();

            return "Попытка завершена!";
        }

        public async Task Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = await surveyService.GetSurveyAsync(request.Body.Id, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.Id}\" не найден!");
            }

            survey.Name = request.Body.Name;
            survey.Description = request.Body.Description;

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            dbContext.Remove(survey);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
    
}
