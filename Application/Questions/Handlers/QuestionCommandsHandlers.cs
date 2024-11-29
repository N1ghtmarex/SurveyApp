using Application.Abstractions.Interfaces;
using Application.Questions.Commands;
using Common.Exceptions;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Questions.Handlers
{
    internal class QuestionCommandsHandlers(ApplicationDbContext dbContext, ISurveyService surveyService)
        : IRequestHandler<AddQuestionCommand, string>
    {
        public async Task<string> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var survey = await surveyService.GetSurveyAsync(request.Body.SurveyId, cancellationToken);

            if (survey == null)
            {
                throw new ObjectNotFoundException($"Опрос с идентификатором \"{request.Body.SurveyId}\" не найден!");
            }

            var questionToCreate = new Question
            {
                SurveyId = survey.Id,
                Title = request.Body.Title,
                Type = request.Body.Type
            };
            
            var createdQuestion = await dbContext.AddAsync(questionToCreate, cancellationToken);
            await dbContext.SaveChangesAsync();

            return questionToCreate.Id.ToString();
        }
    }
}
