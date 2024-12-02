using Application.Answers;
using Application.Questions.Dtos;
using Domain.Entities;
using Mapster;

namespace Application.Questions
{
    [Mapper]
    public interface IQuestionMapper
    {
        Question MapToEntity((AddQuestionModel model, Guid surveyId) src);
    }

    partial class QuestionMapper() : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(AddQuestionModel Model, Guid SurveyId), Question>()
                .Map(d => d.SurveyId, src => src.SurveyId)
                .Map(d => d.Title, src => src.Model.Title)
                .Map(d => d.Type, src => src.Model.Type);
        }
    }
}
