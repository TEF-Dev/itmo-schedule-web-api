using System;
using System.Collections.Generic;
using System.Linq;
using IfmoSchedule.ScheduleManager.Models;

namespace IfmoSchedule.ScheduleManager.Services
{
    public static class AnswerGeneratorService
    {
        public static string GenerateHeader(WeekType targetWeekType, int targetDay)
        {
            var week = targetWeekType != WeekType.Odd ? "чётная" : "нечётная";
            var greeting = "🔑 Расписание на завтра!\n 👀 Нас ждёт ";
            greeting += $"{GetDayName(targetDay)}, {week} неделя \n";
            return greeting;
        }

        public static string LessonToString(LessonModel lesson)
        {
            var room = lesson.Title == "Иностранный язык" ? "" : $"ауд. {lesson.Room} ";
            var s = $"📌 {lesson.TimeBegin} -> {lesson.Title} ({lesson.Status}), {room}{lesson.Place}";
            return s;
        }

        public static string NoLessonMessage()
        {
            return "🔮 Пар не будет, ура!";
        }

        public static string DifferentSchedule(List<LessonModel> isuSchedule, List<LessonModel> localSchedule)
        {
            throw new NotImplementedException();
            return "❌ ИСУ вернула расписание, отличное от локального\n"
                   + "С ИСУ:\n" + string.Join("\n", isuSchedule.Select(AnswerGeneratorService.LessonToString))
                   + "\nЛокально:\n" + string.Join("\n", localSchedule.Select(AnswerGeneratorService.LessonToString));
        }

        private static string GetDayName(int day)
        {
            switch (day)
            {
                case 0:
                    return "понедельник";
                case 1:
                    return "вторник";
                case 2:
                    return "среда";
                case 3:
                    return "четверг";
                case 4:
                    return "пятница";
                case 5:
                    return "суббота";
                case 6:
                    return "воскресенье";
            }

            throw new ArgumentException(day.ToString());
        }
    }
}