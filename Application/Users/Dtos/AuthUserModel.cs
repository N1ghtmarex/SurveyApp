namespace Application.Users.Dtos
{
    /// <summary>
    /// Модель авторизации пользователя
    /// </summary>
    public class AuthUserModel
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
