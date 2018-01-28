using System.Collections.Generic;
using IfmoSchedule.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;


namespace IfmoSchedule.Repositories
{
    public class LessonStorageRepository
    {
        private List<LessonModel> Data;
        private static string baseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";
            
        private void UpdateFromApi(string groupName)
        {
            string address = $"{baseUrl}{groupName}";
            HttpClient client = new HttpClient();
            var result = client.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(result);
            var lessons = lessonsObject["schedule"];
            Data = lessons.ToObject<List<LessonModel>>();
        }

        public LessonStorageRepository()
        {
            UpdateFromApi("M3205");
        }

        public IEnumerable<LessonModel> GetAllLesson()
        {
            return Data;
        }

        //TODO: weekType - bool?
        public IEnumerable<LessonModel> GetLesson(int day, int weekType)
        {
            return Data.Where(i => ((i.DayOfWeek == day) && (i.WeekType == weekType)) || ((i.DayOfWeek == day) && (i.WeekType == 0)));
        }
    }
}