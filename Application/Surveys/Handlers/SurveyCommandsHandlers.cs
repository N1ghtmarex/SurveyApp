using Application.Abstractions.Interfaces;
using Application.Abstractions.Models;
using Application.Answers;
using Application.Questions;
using Application.Surveys.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Surveys.Handlers
{
    public class SurveyCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService, ISurveyMapper surveyMapper,
        IQuestionMapper questionMapper, IAnswerMapper answerMapper, IUserService userService)
        : IRequestHandler<CreateSurveyCommand, CreatedOrUpdatedEntityViewModel<Guid>>, IRequestHandler<StartSurveyCommand>, IRequestHandler<CompleteSurveyCommand>,
        IRequestHandler<UpdateSurveyCommand, CreatedOrUpdatedEntityViewModel<Guid>>, IRequestHandler<DeleteSurveyCommand>
    {
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            var surveyToCreate = new Survey
            { 
                Name = request.Body.Name,
                Description = request.Body.Description,
            };

            var createdSurvey = await dbContext.AddAsync(surveyToCreate);

            var questionsToCreate = request.Body.Questions
                .Select(x => questionMapper.MapToEntity((x, createdSurvey.Entity.Id)))
                .ToList();

            await dbContext.AddRangeAsync(questionsToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);


            for (var i = 0; i < questionsToCreate.Count; i++)
            {
                var answers = request.Body.Questions[i].Answers;

                if (answers == null)
                {
                    continue;
                }

                var answersToCreate = answers.Select(x => answerMapper.MapToEntity((x, questionsToCreate[i].Id))).ToList();

                await dbContext.AddRangeAsync(answersToCreate, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatedOrUpdatedEntityViewModel(createdSurvey.Entity.Id);
        }

        public async Task Handle(StartSurveyCommand request, CancellationToken cancellationToken)
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
        }

        public async Task Handle(CompleteSurveyCommand request, CancellationToken cancellationToken)
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
        }

        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var survey = await surveyService.GetSurveyAsync(request.Body.Id, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.Id}\" не найден!");
            }

            survey.Name = request.Body.Name;
            survey.Description = request.Body.Description;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatedOrUpdatedEntityViewModel(survey.Id);
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
