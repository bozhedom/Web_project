namespace project_web.Objects
{
    /// <summary>
    /// Данные для аутентификации
    /// </summary>
    public class AuthInput
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}