using Application.Answers.Dtos;
using Domain.Entities;
using Mapster;

namespace Application.Answers
{
    [Mapper]
    public interface IAnswerMapper
    {
        AnswerViewModel MapToViewModel(Answer answer);
    }

    partial class AnswerMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Answer, AnswerViewModel>()
                .Map(d => d.Id, src => src.Id)
                .Map(d => d.QuestionId, src => src.QuestionId)
                .Map(d => d.Title, src => src.Title);
        }
    }
}
