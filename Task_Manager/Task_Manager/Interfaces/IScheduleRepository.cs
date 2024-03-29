﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IScheduleRepository
    {
        /// <summary>
        /// Вернет расписани в интервале
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="endate"></param>
        /// <returns></returns>
        List<TaskForDate> GetSchedule(int childId,DateTime startdate,DateTime endate);
        /// <summary>
        /// Возврашает готовую матрицу расписаний
        /// </summary>
        /// <param name="childId"></param>
        /// <param name="startdate"></param>
        /// <param name="endate"></param>
        /// <returns></returns>
        List<List<string>> GetTable(int childId, DateTime startdate, DateTime endate);
    }
}
