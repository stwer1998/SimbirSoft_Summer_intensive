using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IAccountReposirory
    {
        /// <summary>
        /// Если есть пользователь с таким Login и Password то вернет User
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetUser(string login, string password);
        /// <summary>
        /// Добавления пользователя в базу данных
        /// </summary>
        /// <param name="organizer"></param>
        void AddUser(User user);
        /// <summary>
        /// Проверякт есть ли пользователь таким логином если есть вернет true
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        bool CheckLogin(string login);
    }
}
