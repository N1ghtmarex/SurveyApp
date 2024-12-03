using System.ComponentModel;

namespace Domain.Enums
{
    /// <summary>
    /// Статус опроса (для пользователя)
    /// </summary>
    public enum SurveyStatusEnum
    {
        /// <summary>
        /// В процессе
        /// </summary>
        [Description("В процессе")]
        InProgress = 0,

        /// <summary>
        /// Завершен
        /// </summary>
        [Description("Завершен")]
        Completed = 1
    }
}
