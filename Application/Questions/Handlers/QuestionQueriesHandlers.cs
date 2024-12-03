using Application.Abstractions.Interfaces;
using Application.Questions.Dtos;
using Application.Questions.Queries;
using Common.Exceptions;
using Domain;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Questions.Handlers
{
    internal class QuestionQueriesHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<GetQuestionQuery, QuestionViewModel>, IRequestHandler<GetQuestionsListQuery, QuestionListViewModel>
    {
        public async Task<QuestionViewModel> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Id == request.QuestionId)
                .Include(x => x.Answers)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.QuestionId}\" не найден!");
            }

            

            return question.Adapt<QuestionViewModel>();
        }

        public async Task<QuestionListViewModel> Handle(GetQuestionsListQuery request, CancellationToken cancellationToken)
        {
            var includeQuestions = true;
            var includeAnswers = true;

            var survey = await surveyService.GetSurveyAsync(request.SurveyId, cancellationToken, includeQuestions, includeAnswers);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.SurveyId}\" не найден!");
            }

            return survey.Adapt<QuestionListViewModel>();
        }
    }
}
