using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using IfmoSchedule.Models;
using IfmoSchedule.Repositories;
using IfmoSchedule.Tools;

namespace IfmoSchedule.Services
{
    public static class ScheduleGenerator
    {
        public static string GenerateMessage(string groupName)
        {
            var date = DataTimeService.GenerateNextDay();
            return GetScheduleData(groupName, date.Week, date.Day);
        }

        public static string GenerateMessage(string groupName, int week, int day)
        {
            //TODO: week OutOfRange exception
            var msg = TextConverter.GenerateHeader((Week)week, day);
            msg += GetScheduleData(groupName, (Week)week, day);
            return msg;
        }

        private static string GetScheduleData(string groupName, Week weekType, int day)
        {
            var answer = "";
            var my = new ServerStorageRepository(groupName);
            var lessonList = my.GetLesson(day, weekType).ToList();

            if (!lessonList.Any())
            {
                answer = TextConverter.NoLessonMessage();
                return answer;
            }

            foreach (var item in lessonList)
            {
                answer += item.ToString();
            }
            return answer;
        }

        
    }
}