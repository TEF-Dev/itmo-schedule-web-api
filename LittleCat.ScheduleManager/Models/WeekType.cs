using System;

namespace LittleCat.ScheduleManager.Models
{
    public enum WeekType
    {
        All = 0,
        Even = 1,
        Odd = 2,
    }

    public static class WeekTypeExtensions
    {
        public static bool Compare(this WeekType first, WeekType other)
        {
            if (first == WeekType.All || other == WeekType.All)
                return true;
            return (first == other);
        }

        public static string MakeString(this WeekType week)
        {
            switch (week)
            {
                case WeekType.Even:
                    return "чётная";
                case WeekType.Odd:
                    return "нечётная";  
                default:
                    throw new ArgumentOutOfRangeException(nameof(week), week, null);
            }
        }
    }
}