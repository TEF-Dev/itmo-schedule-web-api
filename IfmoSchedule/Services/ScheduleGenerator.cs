using System;
using IfmoSchedule.Repositories;
using System.Globalization;
using IfmoSchedule.Models;

namespace IfmoSchedule.Services
{
    public class ScheduleGenerator
    {
        private string GetHeader()
        {
            return "Расписание на завтра!\n";
        }

        public string GenerateMessage(int day, int weekType)
        {
            var msg = GetHeader();
            msg += GetScheduleData(day, weekType);
            return msg;
        }

        //TODO: Naming GetWeekType
        private static Week getWeekType(DateTime current)
        {
            var todayWeek = (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 5) % 2;
            //TODO: use ternaty operator ( bool ? val1 : val2 )
            if (todayWeek == 0)
            {
                return Week.Even;
            }

            return Week.Odd;
        }

        //TODO: Create GenerateMessage()
        //TODO: Move getting day/week to GenerateMessage()
        private string GetScheduleData(int day, int weekType)
        {
            //TODO: var, var, var...
            LessonStorageRepository my = new LessonStorageRepository();
            DateTime current = DateTime.UtcNow;
            string answer = "";
            Week todayWeek = getWeekType(current);
            //TODO: Use linq aggregation
            foreach (var item in my.GetLesson((int)current.DayOfWeek, todayWeek))
            {
                //TODO: null property
                answer += $"{item.TimeBegin} -> {item.Title} ({item.Status}, ауд. {item.Room} {item.Place})\n";
            }
            return answer;
        }
    }
}