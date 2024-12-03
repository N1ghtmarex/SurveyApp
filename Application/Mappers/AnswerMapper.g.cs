using System;
using Application.Answers;
using Application.Answers.Dtos;
using Domain.Entities;

namespace Application.Answers
{
    public partial class AnswerMapper : IAnswerMapper
    {
        public Answer MapToEntity(ValueTuple<AddAnswerModel, Guid> p1)
        {
            return new Answer()
            {
                QuestionId = p1.Item2,
                Title = p1.Item1.Title
            };
        }
        public AnswerViewModel MapToViewModel(Answer p2)
        {
            return p2 == null ? null : new AnswerViewModel()
            {
                Id = p2.Id,
                QuestionId = p2.QuestionId,
                Title = p2.Title
            };
        }
    }
}