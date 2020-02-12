using System;
using System.Collections.Generic;
using System.Linq;
using ItmoScheduleApiWrapper.Types;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;

namespace LittleCat.ScheduleManager.Services
{
    public static class MessageGeneratorService
    {
        public static string NextDaySchedule(string groupName)
        {
            DateTime nextDay = DateTime.UtcNow.AddDays(1);
            (int day, DataWeekType week) = DataTimeConverter.GetDayAndWeek(nextDay);
            return CreateDailyMessage(groupName, week, day);
        }

        public static string TodaySchedule(string groupName)
        {
            (int day, DataWeekType week) = DataTimeConverter.GetDayAndWeek(DateTime.UtcNow);
            return CreateDailyMessage(groupName, week, day);
        }

        public static string CreateDailyMessage(string groupName, DataWeekType week, int day)
        {
            List<LessonModel> localSchedule = LocalStorageRepository.GetLessonList(groupName, day, week);
            var isuSchedule = ServerApiRepository.GetLessonList(groupName, (DataDayType)day, week);
            string header = AnswerGeneratorService.GenerateHeader(week, day);

            return header;
            //TODO: fix
            //return header += string.Join("\n", isuSchedule.Select(AnswerGeneratorService.LessonToString));
            
            //TODO: fix this
/*
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
*/
        }
    }
}