using Application.Abstractions.Interfaces;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using Common.Exceptions;
using Domain;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Surveys.Handlers
{
    internal class SurveyQueriesHandlers(ApplicationDbContext dbContext, ISurveyService surveyService, IUserService userService, ISurveyMapper surveyMapper)
        : IRequestHandler<GetSurveyQuery, SurveyViewModel>, IRequestHandler<GetSurveysListQuery, SurveyListViewModel>, IRequestHandler<GetSurveyStatusQuery, string>,
        IRequestHandler<GetUserSurveyBindQuery, UserSurveyBindViewModel>
    {
        public async Task<SurveyViewModel> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
        {
            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken, includeQuestions: true, includeAnswers: true);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            return survey.Adapt<SurveyViewModel>();
        }

        public async Task<SurveyListViewModel> Handle(GetSurveysListQuery request, CancellationToken cancellationToken)
        {
            var surveys = await surveyService.GetSurveysListAsync(cancellationToken);

            return new SurveyListViewModel { Surveys = surveys ?? new List<SurveyViewModel>() };
        }

        public async Task<string> Handle(GetSurveyStatusQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            var userSurveyBind = await surveyService.GetUserSurveyBindAsync(survey.Id, user.Id, cancellationToken);

            if (userSurveyBind == null)
            {
                return "Опрос не начат";
            }
            
            return userSurveyBind.Status.ToString();
        }

        public async Task<UserSurveyBindViewModel> Handle(GetUserSurveyBindQuery request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.SurveyId}\" не найден!");
            }

            var userSurveyBind = await surveyService.GetUserSurveyBindAsync(survey.Id, user.Id, cancellationToken);

            if (userSurveyBind == null)
            {
                throw new ObjectNotFoundException();
            }
            var userSurveyBindViewModel = surveyMapper.MapBindToViewModel(userSurveyBind);

            return userSurveyBindViewModel;
        }
    }
}
