using System.Collections.Generic;
using IfmoSchedule.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IfmoSchedule.Repositories
{
    public class LessonStorageRepository
    {
        private static List<LessonModel> Data;
        private static string constructor = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";
            
        private static void UpdateFromApi(string groupName)
        {
            string address = $"{constructor}{groupName}";
            HttpClient query = new HttpClient();
            var result = query.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(result);
            var lessons = lessonsObject["schedule"];
            Data = lessons.ToObject<List<LessonModel>>();

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