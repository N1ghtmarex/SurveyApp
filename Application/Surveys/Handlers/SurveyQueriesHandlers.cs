using Application.Abstractions.Interfaces;
using Application.Questions.Dtos;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using Common.Exceptions;
using Domain;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Surveys.Handlers
{
    internal class SurveyQueriesHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<GetSurveyQuery, SurveyViewModel>, IRequestHandler<GetSurveysListQuery, SurveyListViewModel>, IRequestHandler<GetSurveyStatusQuery, string>,
        IRequestHandler<GetUserSurveyBindQuery, UserSurveyBindViewModel>
    {
        public async Task<SurveyViewModel> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
        {
            var includeQuestions = true;
            var includeAnswers = true;

            var survey = await surveyService.GetSurveyAsync(request.SurveyId.ToString(), cancellationToken, includeQuestions, includeAnswers);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            return survey.Adapt<SurveyViewModel>();
        }

        public async Task<SurveyListViewModel> Handle(GetSurveysListQuery request, CancellationToken cancellationToken)
        {
            var surveys = await dbContext.Surveys
                .ProjectToType<SurveyViewModel>()
                .ToListAsync(cancellationToken);

            return new SurveyListViewModel { Surveys = surveys };
        }

        public async Task<string> Handle(GetSurveyStatusQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Where(x => x.Id == request.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.UserId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(request.SurveyId.ToString(), cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            var userSurveyBind = await dbContext.UserSurveyBinds
                .Where(x => x.UserId == user.Id && x.SurveyId == survey.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (userSurveyBind == null)
            {
                return "Опрос не начат";
            }
            
            return userSurveyBind.Status.ToString();
        }

        public async Task<UserSurveyBindViewModel> Handle(GetUserSurveyBindQuery request, CancellationToken cancellationToken)
        {
            var userSurveyBind = await dbContext.UserSurveyBinds
                .Where(x => x.SurveyId == request.SurveyId && x.UserId == request.UserId)
                .ProjectToType<UserSurveyBindViewModel>()
                .SingleOrDefaultAsync(cancellationToken);

            if (userSurveyBind == null)
            {
                throw new ObjectNotFoundException();
            }

            return userSurveyBind;
        }
    }
}
