using Application.Abstractions.Interfaces;
using Application.Abstractions.Models;
using Application.Answers.Commands;
using Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Answers.Handlers
{
    internal class AnswerCommandsHandlers(ApplicationDbContext dbContext, IQuestionService questionService, ISurveyService surveyService, IAnswerMapper answerMapper,
        IAnswerService answerService)
        : IRequestHandler<AddAnswerCommand, CreatedOrUpdatedEntityViewModel<Guid>>, IRequestHandler<UpdateAnswerCommand, CreatedOrUpdatedEntityViewModel<Guid>>,
        IRequestHandler<DeleteAnswerCommand>
    {
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetQuestionAsync(request.Body.QuestionId, cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.Body.QuestionId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(question.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{question.SurveyId}\" не найден!");
            }

            var answerToCreate = answerMapper.MapToEntity((request.Body, question.Id));

            var createdAnswer = await dbContext.AddAsync(answerToCreate, cancellationToken);

            dbContext.Entry(survey).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatedOrUpdatedEntityViewModel(createdAnswer.Entity.Id);
        }

        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.GetAnswerAsync(request.Body.Id, cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Ответ с идентификатором \"{request.Body.Id}\" не найден!");
            }

            var question = await questionService.GetQuestionAsync(answer.QuestionId, cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{answer.QuestionId}\" не найден!");
            }

            var survey = await surveyService.GetSurveyAsync(question.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{question.SurveyId}\" не найден!");
            }

            answer.Title = request.Body.Title;
            surveyService.UpdateEntityStatus(survey);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatedOrUpdatedEntityViewModel(answer.Id);
        }

        public async Task Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.GetAnswerAsync(request.AnswerId, cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Ответ с идентификатором \"{request.AnswerId}\" не найден!");
            }

            dbContext.Remove(answer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
