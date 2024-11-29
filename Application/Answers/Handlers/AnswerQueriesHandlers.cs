using Application.Abstractions.Interfaces;
using Application.Answers.Dtos;
using Application.Answers.Queries;
using Common.Exceptions;
using Domain;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Answers.Handlers
{
    internal class AnswerQueriesHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<GetAnswerQuery, AnswerViewModel>, IRequestHandler<GetAnswerListQuery, AnswerListViewModel>
    {
        public async Task<AnswerViewModel> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            var answer = await dbContext.Answers
                .Where(x => x.Id == request.AnswerId)
                .SingleOrDefaultAsync(cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Вариант ответа с идентификатором \"{request.AnswerId}\" не найден!");
            }

            var answerViewModel = new AnswerViewModel
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Title = answer.Title
            };

            return answerViewModel;
        }

        public async Task<AnswerListViewModel> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Id == request.QuestionId)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.QuestionId}\" не найден!");
            }

            var answers = await dbContext.Answers
                .Where(x => x.QuestionId == question.Id)
                .ProjectToType<AnswerViewModel>()
                .ToListAsync(cancellationToken);

            return new AnswerListViewModel { Answers = answers };
        }
    }
}
