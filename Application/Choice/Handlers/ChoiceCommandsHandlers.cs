using Application.Choice.Commands;
using Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Choice.Handlers
{
    public class ChoiceCommandsHandlers(ApplicationDbContext dbContext)
        : IRequestHandler<AddChoiceCommand, string>
    {
        public async Task<string> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Where(x => x.Id == request.Body.UserId)
                .Include(x => x.Choices)
                .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.Body.UserId}\" не найден!");
            }

            var answer = await dbContext.Answers
                .Where(x => x.Id == request.Body.AnswerId)
                .SingleOrDefaultAsync(cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Вариант ответа с идентификатором \"{request.Body.AnswerId}\" не найден!");
            }

            var userChoicesIds = user.Choices
                .Select(x => x.Id)
                .ToList();

            if (userChoicesIds.Contains(answer.Id))
            {
                throw new BusinessLogicException($"Вы уже выбирали этот вариант ответа!");
            }

            var choiceToCreate = new Domain.Entities.Choice
            {
                UserId = user.Id,
                AnswerId = answer.Id,
            };

            var createdChoice = await dbContext.Choices.AddAsync(choiceToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return createdChoice.Entity.Id.ToString();
        }
    }
}
