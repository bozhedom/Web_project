namespace project_web.Enums
{
    public enum RoleType
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Пользователь
        /// </summary>
        User = 2
    }

    public static class Role
    {
        public static RoleType FromString(string str)
        {
            foreach (RoleType role in Enum.GetValues(typeof(RoleType)))
            {
                if (role.ToString() == str)
                    return role;
            }

            return RoleType.Undefined;
        }
    }
}