using Application.Abstractions.Interfaces;
using Application.Questions.Dtos;
using Application.Questions.Queries;
using Common.Exceptions;
using Mapster;
using MediatR;

namespace Application.Questions.Handlers
{
    internal class QuestionQueriesHandlers(ISurveyService surveyService, IQuestionService questionService)
        : IRequestHandler<GetQuestionQuery, QuestionViewModel>, IRequestHandler<GetQuestionsListQuery, QuestionListViewModel>
    {
        public async Task<QuestionViewModel> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetQuestionAsync(request.QuestionId, cancellationToken, includeAnswers: true);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.QuestionId}\" не найден!");
            }

            return question.Adapt<QuestionViewModel>();
        }

        public async Task<QuestionListViewModel> Handle(GetQuestionsListQuery request, CancellationToken cancellationToken)
        {

            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken, includeQuestions: true, includeAnswers: true);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            return survey.Adapt<QuestionListViewModel>();
        }
    }
}
