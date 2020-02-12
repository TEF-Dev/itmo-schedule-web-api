using System;
using System.Globalization;
using ItmoScheduleApiWrapper.Types;

namespace LittleCat.ScheduleManager.Services
{
    public static class DataTimeConverter
    {
        public static (int Day, DataWeekType Week) GetDayAndWeek(DateTime data)
        {
            DataWeekType todayWeek = GetWeekType(data);
            var todayDay = (int) data.DayOfWeek;
            todayDay = (todayDay + 6) % 7;
            return (todayDay, todayWeek);
        }

        private static DataWeekType GetWeekType(DateTime currentTime)
        {
            int currentWeek = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                currentTime,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);

            //TODO: DANGER ZONE
            int resultWeek = (currentWeek - 4) % 2;
            return resultWeek == 0 ? DataWeekType.Even : DataWeekType.Odd;
        }
    }
}