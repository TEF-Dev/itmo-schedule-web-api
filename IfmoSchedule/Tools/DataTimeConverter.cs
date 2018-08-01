using System;
using System.Globalization;
using IfmoSchedule.ScheduleManager.Models;

namespace IfmoSchedule.Tools
{
    public static class DataTimeConverter
    {
        public static (int Day, WeekType Week) GetDayAndWeek(DateTime data)
        {
            var todayWeek = GetWeekType(data);
            var todayDay = (int) data.DayOfWeek;
            return (todayDay, todayWeek);
        }

        private static WeekType GetWeekType(DateTime currentTime)
        {
            var currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                currentTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);

            //TODO: DANGER ZONE
            var resultWeek = (currentWeek - 5) % 2;
            return resultWeek == 0 ? WeekType.Even : WeekType.Odd;
        }
    }
}