using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Вопрос
    /// </summary>
    public class Question : BaseEntity<Guid>, IHaveDateTrack, IHaveDeleteTrack
    {
        /// <summary>
        /// Идентификатор теста
        /// </summary>
        public required Guid SurveyId { get; set; }
        public Survey? Survey {  get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Тип вопроса
        /// </summary>
        public required QuestionTypeEnum Type { get; set; }

        /// <summary>
        /// Связка с ответами
        /// </summary>
        public ICollection<Answer>? Answers { get; set; }

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
