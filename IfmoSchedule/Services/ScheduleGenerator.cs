using System;
using IfmoSchedule.Repositories;
using System.Globalization;

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

        private static int getWeekType(DateTime current)
        {
            if (((CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)) - 5) % 2 == 0)
            {
                return 1;
            }
            return 2;
        }

        private string GetScheduleData(int day, int weekType)
        {
            //TODO: Convert data from repository to string
            LessonStorageRepository my = new LessonStorageRepository();
            DateTime current = DateTime.UtcNow;
            string answer = "";
            foreach (var item in my.GetLesson((int)current.DayOfWeek, getWeekType(current)))
            {
                answer += $"{item.TimeBegin} -> {item.Title} ({item.Status}, ауд. {item.Room} {item.Place})\n";
            }
            return answer;
        }
    }
}