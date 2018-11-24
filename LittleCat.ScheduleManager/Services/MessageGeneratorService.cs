using System;
using System.Linq;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;
using LittleCat.ScheduleManager.Services;

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
            var isuSchedule = repository.GetLessonList(groupName, day, week);
            var localSchedule = localRepo.GetLessonList(groupName, day, week);
            var header = AnswerGeneratorService.GenerateHeader(week, day);

            if (isuSchedule == null)
            {
                //TODO: isu empty
                if (localSchedule == null)
                {
                    //TODO: isu and local empty
                }
                else
                {
                    //TODO: return local schedule
                }
            }
            else
            {
                if (localSchedule == null)
                {
                    //TODO: no local data
                }
                else
                {
                    if (isuSchedule.Except(localSchedule).Any())
                    {
                        return header + AnswerGeneratorService.DifferentSchedule(isuSchedule, localSchedule);
                    }
                    else if (!isuSchedule.Any())
                    {
                        return header += AnswerGeneratorService.NoLessonMessage();
                    }
                    else
                    {
                        return header += string.Join("\n", isuSchedule.Select(AnswerGeneratorService.LessonToString));
                    }
                }
            }

            return header;
        }
    }
}