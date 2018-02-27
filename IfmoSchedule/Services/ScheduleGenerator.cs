using System;
using System.Collections.Generic;
using System.Globalization;
using IfmoSchedule.Models;
using IfmoSchedule.Repositories;

namespace IfmoSchedule.Services
{
    public static class ScheduleGenerator
    {
        public static string GenerateMessage(string groupName)
        {
            var date = GenerateNextDay();
            var msg = GetHeader(date.Week, date.Day);
            msg += GetScheduleData(groupName, date.Week, date.Day);
            return msg;
        }

        public static string GenerateMessage(string groupName, int week, int day)
        {
            // var msg = GetHeader();
            var msg = "";
            msg += GetScheduleData(groupName, (Week)week, day);
            return msg;
        }

        private static string GetStringDay(int day) {
            if (day == 0) return "понедельник";
            if (day == 1) return "вторник";
            if (day == 2) return "среда";
            if (day == 3) return "четверг";
            if (day == 4) return "пятница";
            if (day == 5) return "суббота";
            if (day == 6) return "воскресенье";
            return null;
        }

        private static string GetHeader(Week targetWeek, int targetDay)
        {
            string greeting = "🔑 Расписание на завтра!\n 👀 Нас ждёт ";
            greeting += GetStringDay(targetDay);
            greeting += ", ";
            greeting += targetWeek != Week.Odd ? "чётная" : "нечётная";
            greeting += " неделя \n";
            return greeting;
        }

        private static Week GetWeekType(DateTime current)
        {
            var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(current,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
            var resultWeek = (currentWeek - 5) % 2;
            return resultWeek == 0 ? Week.Even : Week.Odd;
        }

        private static (int Day, Week Week) GenerateCurrentDay()
        {
            var current = DateTime.UtcNow;
            var todayWeek = GetWeekType(current);
            return ((int)current.DayOfWeek - 1, todayWeek);
        }

        private static (int Day, Week Week) GenerateNextDay()
        {
            var current = DateTime.UtcNow.AddDays(1);
            var todayWeek = GetWeekType(current);
            return ((int)current.DayOfWeek - 1, todayWeek);
        }

        private static string GetScheduleData(string groupName, Week weekType, int day)
        {
            var answer = "";
            var my = new ServerStorageRepository(groupName);
            var lessonList = my.GetLesson(day, weekType);

            foreach (var item in lessonList)
            {
                var room = item.Title == "Иностранный язык" ? "" : $"ауд. {item.Room} ";
                answer += $"📌 {item.TimeBegin} -> {item.Title} ({item.Status}), {room}{item.Place}\n";
            }
            if (answer == "") {
                answer = "🔮 Пар не будет, ура!";
            }
            return answer;
        }

        public static bool CompareData(List<LessonModel> local, List<LessonModel> serverResponse)
        {
            if (local.Count != serverResponse.Count) return false;
            var isSame = true;
            for (var i = 0; i < local.Count; i++)
            {
                isSame = isSame && local[i].Equals(serverResponse[i]);
            }

            return isSame;
        }
    }
}