using System.ComponentModel;

namespace Domain.Enums
{
    public enum QuestionTypeEnum
    {
        [Description("Вопрос с одним правильным ответом")]
        OneAnswer = 0,

        [Description("Вопрос с несколькими правильными ответами")]
        MultipleAnswer = 1,

        [Description("Вопрос с вводом текста")]
        InputAnswer = 2
    }
}
