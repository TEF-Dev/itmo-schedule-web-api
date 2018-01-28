using System.Collections.Generic;
using IfmoSchedule.Models;

namespace IfmoSchedule.Repositories
{
    public class LessonStorageRepository
    {
        private static List<LessonModel> Data;
        private static void UpdateFromApi()
        {
            //TODO: Make request, parse json
        }

        static LessonStorageRepository()
        {
            UpdateFromApi();
        }

        public LessonStorageRepository()
        {

        }

        public IEnumerable<LessonModel> GetAllLesson()
        {
            return null;
        }

        //TODO: weekType - bool?
        public IEnumerable<LessonModel> GetLesson(int day, int weekType)
        {
            return null;
        }
    }
}