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

        private static Week getWeekType(DateTime current)
        {
            var todayWeek = (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 5) % 2;
            if (todayWeek == 0)
            {
                return Week.even;
            }

            return Week.odd;
        }

        private string GetScheduleData(int day, int weekType)
        {
            //TODO: Convert data from repository to string
            LessonStorageRepository my = new LessonStorageRepository();
            DateTime current = DateTime.UtcNow;
            string answer = "";
            Week todayWeek = getWeekType(current);
            foreach (var item in my.GetLesson((int)current.DayOfWeek, todayWeek))
            {
                answer += $"{item.TimeBegin} -> {item.Title} ({item.Status}, ауд. {item.Room} {item.Place})\n";
            }
            return answer;
        }
    }
}