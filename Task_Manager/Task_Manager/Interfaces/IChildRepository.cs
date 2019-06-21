using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    interface IChildRepository
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
        void DeleteChild(int idChild);
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
    }
}
