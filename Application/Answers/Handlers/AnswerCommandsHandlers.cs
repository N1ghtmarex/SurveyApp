using Application.Answers.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Answers.Handlers
{
    internal class AnswerCommandsHandlers(ApplicationDbContext dbContext)
        : IRequestHandler<AddAnswerCommand, string>
    {
        public async Task<string> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Title == request.Body.Title)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.Body.Title}\" не найден!");
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
    }
}
