namespace Application.Users.Dtos
{
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
