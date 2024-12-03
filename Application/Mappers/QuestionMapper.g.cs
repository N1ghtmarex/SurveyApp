using System;
using Application.Questions;
using Application.Questions.Dtos;
using Domain.Entities;

namespace Application.Questions
{
    public partial class QuestionMapper : IQuestionMapper
    {
        public Question MapToEntity(ValueTuple<AddQuestionModel, Guid> p1)
        {
            return new Question()
            {
                SurveyId = p1.Item2,
                Title = p1.Item1.Title,
                Type = p1.Item1.Type
            };
        }
    }
}