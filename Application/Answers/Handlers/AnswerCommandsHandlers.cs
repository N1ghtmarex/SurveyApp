using Application.Answers.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Answers.Handlers
{
    internal class AnswerCommandsHandlers(ApplicationDbContext dbContext)
        : IRequestHandler<AddAnswerCommand, string>, IRequestHandler<UpdateAnswerCommand>, IRequestHandler<DeleteAnswerCommand>
    {
        public async Task<string> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Id == request.Body.QuestionId)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.Body.QuestionId}\" не найден!");
            }

            var survey = await dbContext.Surveys
                .Where(x => x.Id == question.SurveyId)
                .SingleOrDefaultAsync(cancellationToken);

            var answerToCreate = new Answer
            {
                QuestionId = question.Id,
                Title = request.Body.Title
            };

            var createdAnswer = await dbContext.AddAsync(answerToCreate, cancellationToken);
            dbContext.Entry(survey).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdAnswer.Entity.Id.ToString();
        }

        public async Task Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await dbContext.Answers
                .Where(x => x.Id == request.Body.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Ответ с идентификатором \"{request.Body.Id}\" не найден!");
            }

            answer.Title = request.Body.Title;

            var surveyToUpdate = await dbContext.Surveys
                .Where(x => x.Questions.Any(x => x.Answers.Any(x => x.Id == answer.Id)))
                .SingleOrDefaultAsync(cancellationToken);

            dbContext.Entry(surveyToUpdate).State = EntityState.Modified;

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await dbContext.Answers
                .Where(x => x.Id == request.AnswerId)
                .SingleOrDefaultAsync(cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Ответ с идентификатором \"{request.AnswerId}\" не найден!");
            }

            dbContext.Remove(answer);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
