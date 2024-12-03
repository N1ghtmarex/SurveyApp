using System.ComponentModel;

namespace Domain.Enums
{
    /// <summary>
    /// Тип вопроса
    /// </summary>
    public enum QuestionTypeEnum
    {
        /// <summary>
        /// Один ответ
        /// </summary>
        [Description("Вопрос с выбором одного ответа")]
        OneAnswer = 0,

        /// <summary>
        /// Несколько ответов
        /// </summary>
        [Description("Вопрос с выбором нескольких ответов")]
        MultipleAnswer = 1
    }
}
