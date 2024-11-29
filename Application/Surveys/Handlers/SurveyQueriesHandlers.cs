using Application.Abstractions.Interfaces;
using Application.Questions.Dtos;
using Application.Surveys.Dtos;
using Application.Surveys.Queries;
using Common.Exceptions;
using Domain;
using Mapster;
using MediatR;

namespace Application.Surveys.Handlers
{
    internal class SurveyQueriesHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<GetSurveyQuery, SurveyViewModel>
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
    }
}
