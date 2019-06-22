using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Возвращает пользователя по логину
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        User GetUser(string login);
        /// <summary>
        /// Редактирует пользователя 
        /// </summary>
        /// <param name="newUser">Новые данные пользователя</param>
        void EditUser(User newUser);
        /// <summary>
        /// Установливает сегодняшнюю дату в поле UpdateTime
        /// </summary>
        /// <param name="login">Логин</param>
        void UpdateUserUpdateTime(string login);
        /// <summary>
        /// Возврашает идентификатор пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        int GetUserId(string login);
    }
}
