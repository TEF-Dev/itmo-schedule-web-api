using System;
using ItmoScheduleApiWrapper.Types;

namespace LittleCat.ScheduleManager.Models
{
    public static class WeekTypeExtensions
    {
        public static string MakeString(this DataWeekType week)
        {
            switch (week)
            {
                case DataWeekType.Even:
                    return "чётная";
                case DataWeekType.Odd:
                    return "нечётная";  
                default:
                    throw new ArgumentOutOfRangeException(nameof(week), week, null);
            }
        }
    }
}