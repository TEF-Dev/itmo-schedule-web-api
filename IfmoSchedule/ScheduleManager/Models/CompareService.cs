using System;
using System.Collections.Generic;

namespace IfmoSchedule.ScheduleManager.Models
{
    public class CompareService
    {
        public CompareService(List<LessonModel> firstGroup, List<LessonModel> secondGroup)
        {
            FirstGroup = firstGroup;
            SecondGroup = secondGroup;
            throw new NotImplementedException();

            SameLesson = null;
            DifferentLesson = null;
        }

        public List<LessonModel> FirstGroup { get; }
        public List<LessonModel> SecondGroup { get; }
        public List<LessonModel> SameLesson { get; }
        public List<LessonModel> DifferentLesson { get; }
    }
}