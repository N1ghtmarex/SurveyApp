using Application.Abstractions.Interfaces;
using Application.Questions.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Questions.Handlers
{
    internal class QuestionCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<AddQuestionCommand, string>, IRequestHandler<UpdateQuestionCommand>, IRequestHandler<DeleteQuestionCommand>
    {
        public async Task<string> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {

            var survey = await surveyService.GetSurveyAsync(request.Body.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"\" не найден!");
            }

            var questionToCreate = new Question
            {
                SurveyId = survey.Id,
                Title = request.Body.Title,
                Type = request.Body.Type
            };
            
            var createdQuestion = await dbContext.AddAsync(questionToCreate, cancellationToken);
            dbContext.Entry(survey).State = EntityState.Modified;

            await dbContext.SaveChangesAsync(cancellationToken);

            return questionToCreate.Id.ToString();
        }

        public async Task Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Id == request.Body.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException($"Вопрос с идентификатором \"\" не найден!");
            }

            question.Title = request.Body.Title;
            question.Type = request.Body.Type;

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await dbContext.Questions
                .Where(x => x.Id == request.QuestionId)
                .SingleOrDefaultAsync(cancellationToken);

            if (question == null)
            {
                throw new ObjectNotFoundException();
            }

            dbContext.Questions.Remove(question);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
