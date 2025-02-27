﻿using Domain.Abstractions;

namespace Domain.Entities
{
    /// <summary>
    /// Опрос
    /// </summary>
    public class Survey : BaseEntity<Guid>, IHaveDateTrack, IHaveDeleteTrack
    {
        /// <summary>
        /// Название опроса
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Описание опроса
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public ICollection<Question>? Questions { get; set; }

        /// <summary>
        /// Связь с пользователями
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
