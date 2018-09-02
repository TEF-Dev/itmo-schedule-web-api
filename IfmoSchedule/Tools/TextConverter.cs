using System;
using IfmoSchedule.Models;

namespace IfmoSchedule.Tools
{
    public static class TextConverter
    {
        private static string GetDayName(int day)
        {
            if (day == 0) return "понедельник";
            if (day == 1) return "вторник";
            if (day == 2) return "среда";
            if (day == 3) return "четверг";
            if (day == 4) return "пятница";
            if (day == 5) return "суббота";
            if (day == 6) return "воскресенье";
            throw new ArgumentException(day.ToString());
        }

        public static string GenerateHeader(Week targetWeek, int targetDay)
        {
            string greeting = "🔑 Расписание на завтра!\n 👀 Нас ждёт ";
            greeting += GetDayName(targetDay);
            greeting += ", ";
            greeting += targetWeek != Week.Odd ? "чётная" : "нечётная";
            greeting += " неделя \n";
            return greeting;
        }
    }
}