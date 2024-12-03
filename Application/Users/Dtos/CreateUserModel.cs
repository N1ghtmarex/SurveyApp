namespace Application.Users.Dtos
{
    /// <summary>
    /// Модель регистрации пользователя
    /// </summary>
    public class CreateUserModel
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public required string Password { get; set; }
    }
}
