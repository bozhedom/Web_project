using project_web.Enums;

namespace project_web.Objects
{
    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public class AuthInfo
    {
        /// <summary>
        /// Аутенцифицирован ли пользователь
        /// </summary>
        public bool IsAuthenticated { get; private set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public RoleType Role { get; private set; }

        /// <summary>
        /// Успешная аутентификация
        /// </summary>
        public static AuthInfo Success(RoleType role)
        {
            return new AuthInfo()
            {
                IsAuthenticated = true,
                Role = role
            };
        }

        /// <summary>
        /// Ошибка аутентификации
        /// </summary>
        /// <returns></returns>
        public static AuthInfo Fail()
        {
            return new AuthInfo()
            {
                IsAuthenticated = false,
                Role = RoleType.Undefined
            };
        }
    }
}