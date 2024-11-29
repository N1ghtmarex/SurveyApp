using Domain.Abstractions;

namespace Domain.Entities
{
    public class Survey : BaseEntity<Guid>, IHaveDateTrack, IHaveDeleteTrack
    {
        /// <summary>
        /// Название теста
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Описание теста
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Связка с вопросами
        /// </summary>
        public ICollection<Question>? Questions { get; set; }

        /// <summary>
        /// Связка с пользователями
        /// </summary>
        public ICollection<UserSurveyBind>? UserSurveyBinds {  get; set; } 

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Статус удаления
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
