using System;
using System.Collections.Generic;
using IfmoSchedule.Models;

namespace IfmoSchedule.Services
{
    public class CompareService
    {
        public List<LessonModel> SameLesson { get; private set; }
        public List<LessonModel> DifferentLesson { get; private set; }

        public CompareService(List<List<LessonModel>> groupsData)
        {
            throw new NotImplementedException();
            SameLesson = null;
            DifferentLesson = null;
        }
    }
}