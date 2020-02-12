using System;
using System.Collections.Generic;
using System.Linq;
using ItmoScheduleApiWrapper.Models;
using ItmoScheduleApiWrapper.Types;
using LittleCat.ScheduleManager.Models;

namespace LittleCat.ScheduleManager.Services
{
    public static class AnswerGeneratorService
    {
        public static string GenerateHeader(DataWeekType targetWeekType, int targetDay)
        {
            return "🔑 Расписание на завтра!\n 👀 Нас ждёт "
                   + $"{GetDayName(targetDay)}, {targetWeekType.MakeString()} неделя \n";
        }

        public static string LessonToString(ScheduleItemModel lesson)
        {
            return $"📌 {lesson.StartTime} -> {lesson.SubjectTitle} ({lesson.Status}), {lesson?.Room ?? " "}{lesson.Place}";
        }

        public static string NoLessonMessage()
        {
            return "🔮 Пар не будет, ура!";
        }

        public static string DifferentSchedule(List<ScheduleItemModel> isuSchedule, List<ScheduleItemModel> localSchedule)
        {
            throw new NotImplementedException();
/*
            return "❌ ИСУ вернула расписание, отличное от локального\n"
                   + "С ИСУ:\n" + string.Join("\n", isuSchedule.Select(LessonToString))
                   + "\nЛокально:\n" + string.Join("\n", localSchedule.Select(LessonToString));
*/
        }

        private static string GetDayName(int day)
        {
            switch (day)
            {
                case 0:
                    return "понедельник";
                case 1:
                    return "вторник";
                case 2:
                    return "среда";
                case 3:
                    return "четверг";
                case 4:
                    return "пятница";
                case 5:
                    return "суббота";
                case 6:
                    return "воскресенье";
            }

            throw new ArgumentException(day.ToString());
        }

        public static string WeekTypeException()
        {
            return "Week incorrect. 2 код нечетной и 1 четной";
        }
    }
}