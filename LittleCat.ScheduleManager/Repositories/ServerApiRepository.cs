using System.Collections.Generic;
using System.Linq;
using ItmoScheduleApiWrapper;
using ItmoScheduleApiWrapper.Helpers;
using ItmoScheduleApiWrapper.Models;
using ItmoScheduleApiWrapper.Types;

namespace LittleCat.ScheduleManager.Repositories
{
    public static class ServerApiRepository
    {
        private static ItmoApiProvider _apiProvider = new ItmoApiProvider();

        public static List<ScheduleItemModel> GetLessonList(string groupName, DataDayType day, DataWeekType weekType)
        {
            List<ScheduleItemModel> lessons = GetLessonList(groupName);

            return lessons
                ?.Where(l => l.DataWeek.Compare(weekType) && l.DataDay == day)
                .ToList();
        }

        public static List<ScheduleItemModel> GetLessonList(string groupName)
        {
            //TODO: timeout
            var result = _apiProvider.ScheduleApi.GetGroupSchedule(groupName);
            result.Wait();
            return result.IsFaulted
                ? new List<ScheduleItemModel>()
                : result.Result.Schedule;
        }
    }
}