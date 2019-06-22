using System.Collections.Generic;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IChildRepository
    {
        /// <summary>
        /// Добавляет ребёнка в базу
        /// </summary>
        /// <param name="child"></param>
        void AddChild(Child child);
        /// <summary>
        /// Редактирует ребёнка
        /// </summary>
        /// <param name="newChild"></param>
        void EditChild(Child newChild);
        /// <summary>
        /// Удаляет ребёнка
        /// </summary>
        /// <param name="idChild"></param>
        void DeleteChild(int userId,int idChild);
        /// <summary>
        /// Получение всех детей пользователя
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        List<Child> GetUserChilds(int idUser);
        /// <summary>
        /// возвращает ребёнко по Id
        /// </summary>
        /// <param name="childId"></param>
        /// <returns></returns>
        Child GetChild(int childId);

        /// <summary>
        /// Возвращает true если у пользователя нет ребёнка имеющего такого имени и фамилии
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        bool GetNameSurnameChild(int userId,Child child);
    }
}
