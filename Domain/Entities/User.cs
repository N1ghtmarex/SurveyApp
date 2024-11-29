namespace Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        /// <summary>
        /// Связка с тестами
        /// </summary>
        public ICollection<UserSurveyBind>? UserSurveyBinds { get; set; }

        public required string Username { get; set; }
        public required string Password { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}
