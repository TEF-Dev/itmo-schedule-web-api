using System;
using System.Collections.Generic;
using System.Linq;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;

namespace LittleCat.ScheduleManager.Services
{
    public static class MessageGeneratorService
    {
        public static string NextDaySchedule(string groupName)
        {
            DateTime nextDay = DateTime.UtcNow.AddDays(1);
            (int day, WeekType week) = DataTimeConverter.GetDayAndWeek(nextDay);
            return CreateDailyMessage(groupName, week, day);
        }

        public static string TodaySchedule(string groupName)
        {
            (int day, WeekType week) = DataTimeConverter.GetDayAndWeek(DateTime.UtcNow);
            return CreateDailyMessage(groupName, week, day);
        }

        public static string CreateDailyMessage(string groupName, WeekType week, int day)
        {
            var localRepo = new LocalStorageRepository();
            List<LessonModel> localSchedule = localRepo.GetLessonList(groupName, day, week);
            List<LessonModel> isuSchedule = ServerApiRepository.GetLessonList(groupName, day, week);
            string header = AnswerGeneratorService.GenerateHeader(week, day);

            return header += string.Join("\n", isuSchedule.Select(AnswerGeneratorService.LessonToString));
            //TODO: fix this
            if (isuSchedule == null)
            {
                //TODO: isu empty
                if (localSchedule == null)
                {
                    //TODO: isu and local empty
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

                    if (!isuSchedule.Any())
                    {
                        return header += AnswerGeneratorService.NoLessonMessage();
                    }

                    return header += string.Join("\n", isuSchedule.Select(AnswerGeneratorService.LessonToString));
                }
            }

            return header;
        }
    }
}