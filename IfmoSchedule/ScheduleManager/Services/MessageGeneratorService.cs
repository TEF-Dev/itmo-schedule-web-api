using System;
using System.Linq;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using IfmoSchedule.Tools;

namespace IfmoSchedule.ScheduleManager.Services
{
    public static class MessageGeneratorService
    {
        public static string NextDaySchedule(string groupName)
        {
            var nextDay = DateTime.UtcNow.AddDays(1);
            var date = DataTimeConverter.GetDayAndWeek(nextDay);
            return CreateDailyMessage(groupName, date.Week, date.Day);
        }

        public static string TodaySchedule(string groupName)
        {
            var date = DataTimeConverter.GetDayAndWeek(DateTime.UtcNow);
            return CreateDailyMessage(groupName, date.Week, date.Day);
        }

        public static string CreateDailyMessage(string groupName, WeekType week, int day)
        {
            var repository = new ServerStorageRepository();
            var localRepo = new LocalStorageRepository();
            var lessonList = repository.GetLessonList(groupName, day, week);
            var localList = localRepo.GetLessonList(groupName, day, week);

            var msg = AnswerGeneratorService.GenerateHeader(week, day);
            if (lessonList.Except(localList).Any())
                msg += "❌ ИСУ вернула расписание, отличное от локального\n"
                       + "С ИСУ:\n" + string.Join("\n", lessonList.Select(AnswerGeneratorService.LessonToString))
                       + "\nЛокально:\n" + string.Join("\n", localList.Select(AnswerGeneratorService.LessonToString));
            else if (!lessonList.Any())
                msg += AnswerGeneratorService.NoLessonMessage();
            else
                msg += string.Join("\n", lessonList.Select(AnswerGeneratorService.LessonToString));

            return msg;
        }
    }
}