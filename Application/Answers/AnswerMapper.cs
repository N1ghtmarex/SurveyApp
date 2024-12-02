using Application.Answers.Dtos;
using Domain.Entities;
using Mapster;

namespace Application.Answers
{
    [Mapper]
    public interface IAnswerMapper
    {
        Answer MapToEntity((AddAnswerModel model, Guid questionId) src);
        AnswerViewModel MapToViewModel(Answer answer);
    }

    partial class AnswerMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(AddAnswerModel Model, Guid QuestionId), Answer>()
                .Map(d => d.QuestionId, src => src.QuestionId)
                .Map(d => d.Title, src => src.Model.Title);

            config.NewConfig<Answer, AnswerViewModel>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.QuestionId, src => src.QuestionId)
                .Map(d => d.Title, src => src.Title);
        }
    }
}
