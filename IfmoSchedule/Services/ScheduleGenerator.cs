using System;
using IfmoSchedule.Repositories;
using System.Globalization;
using IfmoSchedule.Models;

namespace IfmoSchedule.Services
{
    public class ScheduleGenerator
    {

        public string GenerateMessage(string groupName)
        {
            var msg = GetHeader();
            var date = GenerateDate();
            msg += GetScheduleData(date.Item1, date.Item2, groupName);
            return msg;
        }

        private string GetHeader()
        {
            return "Расписание на завтра!\n";
        }

        private static Week GetWeekType(DateTime current)
        {
            var todayWeek = (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(current, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 5) % 2;
            return todayWeek == 0 ? Week.Even : Week.Odd;
        }

        private (int, Week) GenerateDate()
        {

            var current = DateTime.UtcNow;
            var todayWeek = GetWeekType(current);
            return ((int)current.DayOfWeek, todayWeek);
        }

        private string GetScheduleData(int day, Week weekType, string groupName)
        {
            var answer = "";
            LessonStorageRepository my = new LessonStorageRepository(groupName);

            foreach (var item in my.GetLesson(day, weekType))
            {
                string room = item.Title == "Иностранный язык" ? "" : $"ауд. {item.Room} ";
                answer += $"{item.TimeBegin} -> {item.Title} ({item.Status}, {room}{item.Place})\n";
            }

            return answer;
        }
    }
}