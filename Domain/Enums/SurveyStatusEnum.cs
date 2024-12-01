using System.ComponentModel;

namespace Domain.Enums
{
    public enum SurveyStatusEnum
    {
        [Description("В процессе")]
        InProgress = 0,

        [Description("Завершен")]
        Completed = 1
    }
}
