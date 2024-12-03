using Application.Abstractions.Interfaces;
using Application.Abstractions.Models;
using Application.Choice.Commands;
using Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Choice.Handlers
{
    public class ChoiceCommandsHandlers(ApplicationDbContext dbContext, IUserService userService, IAnswerService answerService, IQuestionService questionService)
        : IRequestHandler<AddChoiceCommand, CreatedOrUpdatedEntityViewModel<Guid>>
    {
        public async Task<CreatedOrUpdatedEntityViewModel<Guid>> Handle(AddChoiceCommand request, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByIdAsync(request.UserId, cancellationToken, includeChoice: true);

            if (user == null)
            {
                throw new ObjectNotFoundException($"Пользователь с идентификатором \"{request.UserId}\" не найден!");
            }

            var answer = await answerService.GetAnswerAsync(request.AnswerId, cancellationToken);

            if (answer == null)
            {
                throw new ObjectNotFoundException($"Вариант ответа с идентификатором \"{request.AnswerId}\" не найден!");
            }

            var questionAnswers = await questionService.GetQuestionAnswersAsync(answer.QuestionId, cancellationToken);

            if (questionAnswers == null)
            {
                throw new BusinessLogicException($"Вопрос не создан или для него не добавлены варианты ответа!");
            }

            var questionAnswersIds = questionAnswers
                .Select(x => x.Id)
                .ToList();

            var userChoices = await dbContext.Choices
                .Where(x => questionAnswersIds.Contains(x.AnswerId))
                .SingleOrDefaultAsync(cancellationToken);

            if (userChoices != null)
            {
                dbContext.Remove(userChoices);
            }

            var choiceToCreate = new Domain.Entities.Choice
            {
                UserId = user.Id,
                AnswerId = answer.Id,
                QuestionId = answer.QuestionId,
            };

            var createdChoice = await dbContext.Choices.AddAsync(choiceToCreate, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatedOrUpdatedEntityViewModel(createdChoice.Entity.Id);
        }
    }
}
