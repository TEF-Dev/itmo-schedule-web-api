using System;
using System.Linq;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using IfmoSchedule.Tools;

namespace IfmoSchedule.ScheduleManager.Services
{
    public static class MessageGeneratorService
    {
        public static string CreateDailyMessage(string groupName)
        {
            var date = DataTimeConverter.GetDayAndWeek(DateTime.UtcNow.AddDays(1));
            return CreateDailyMessage(groupName, date.Week, date.Day);
        }

        public static string CreateDailyMessage(string groupName, WeekType week, int day)
        {
            var repository = new ServerStorageRepository();

            var msg = AnswerGeneratorService.GenerateHeader(week, day);
            var lessonList = repository.GetLessonList(groupName, day, week);

            if (!lessonList.Any())
            {
                return AnswerGeneratorService.NoLessonMessage();
            }

            msg += string.Join("\n", lessonList.Select(AnswerGeneratorService.LessonToString));
            return msg;
        }
    }
}