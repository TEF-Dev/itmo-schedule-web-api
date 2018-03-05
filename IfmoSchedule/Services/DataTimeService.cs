using System;
using System.Globalization;
using IfmoSchedule.Models;

namespace IfmoSchedule.Services
{
    public static class DataTimeService
    {
        private static Week GetWeekType(DateTime currentTime)
        {
            var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                time: currentTime,
                rule: CalendarWeekRule.FirstFourDayWeek,
                firstDayOfWeek: DayOfWeek.Monday);

            //TODO: DANGER ZONE
            var resultWeek = (currentWeek - 5) % 2;
            return resultWeek == 0 ? Week.Even : Week.Odd;
        }

        private static (int Day, Week Week) Convert(DateTime data)
        {
            var todayWeek = GetWeekType(data);
            var todayDay = (int) data.DayOfWeek;
            return (todayDay, todayWeek);
        }

        public static (int Day, Week Week) GenerateCurrentDay()
        {
            var current = DateTime.UtcNow;
            return Convert(current);
        }

        public static (int Day, Week Week) GenerateNextDay()
        {
            var current = DateTime.UtcNow.AddDays(1);
            return Convert(current);
        }
    }
}