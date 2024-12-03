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
    internal class AnswerQueriesHandlers( IAnswerService answerService, IAnswerMapper answerMapper, IQuestionService questionService)
        : IRequestHandler<GetAnswerQuery, AnswerViewModel>, IRequestHandler<GetAnswerListQuery, AnswerListViewModel>
    {
        public async Task<AnswerViewModel> Handle(GetAnswerQuery request, CancellationToken cancellationToken)
        {
            var answer = await answerService.GetAnswerAsync(request.AnswerId, cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Вариант ответа с идентификатором \"{request.AnswerId}\" не найден!");
            }

            var answerViewModel = answerMapper.MapToViewModel(answer);

            return answerViewModel;
        }

        public async Task<AnswerListViewModel> Handle(GetAnswerListQuery request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetQuestionAsync(request.QuestionId, cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.QuestionId}\" не найден!");
            }

            var answers = await answerService.GetAnswersListByQuestionAsync(request.QuestionId, cancellationToken);

            if (answers == null)
            {
                return new AnswerListViewModel { Answers = new List<AnswerViewModel>() };
            }

            var result = answers.Select(answerMapper.MapToViewModel).ToList();

            return new AnswerListViewModel { Answers = result };
        }
    }
}
