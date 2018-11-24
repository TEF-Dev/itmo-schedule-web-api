using System;
using System.Globalization;
using LittleCat.ScheduleManager.Models;

namespace LittleCat.ScheduleManager.Services
{
    public static class DataTimeConverter
    {
        public static (int Day, WeekType Week) GetDayAndWeek(DateTime data)
        {
            var todayWeek = GetWeekType(data);
            var todayDay = (int) data.DayOfWeek;
            todayDay = (todayDay + 6) % 7;
            return (todayDay, todayWeek);
        }

        private static WeekType GetWeekType(DateTime currentTime)
        {
            var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                currentTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);

            //TODO: DANGER ZONE
            var resultWeek = (currentWeek - 4) % 2;
            return resultWeek == 0 ? WeekType.Even : WeekType.Odd;
        }
    }
}