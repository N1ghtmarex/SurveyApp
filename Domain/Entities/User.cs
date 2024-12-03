namespace Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : BaseEntity<Guid>
    {
        /// <summary>
        /// Связь с тестами
        /// </summary>
        public ICollection<UserSurveyBind>? UserSurveyBinds { get; set; }

        /// <summary>
        /// Связь с ответами
        /// </summary>
        public ICollection<Choice>? Choices { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Username { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}
