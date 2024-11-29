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
                .Where(x => x.Id == Guid.Parse(request.Body.QuestionId))
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"{request.Body.QuestionId}\" не найден!");
            }

            var answerToCreate = new Answer
            {
                QuestionId = question.Id,
                Title = request.Body.Title
            };

            var createdAnswer = await dbContext.AddAsync(answerToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdAnswer.Entity.Id.ToString();
        }
    }
}
