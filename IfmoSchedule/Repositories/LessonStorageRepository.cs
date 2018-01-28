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
        private List<LessonModel> _data;
        private static string baseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";
            
        private void UpdateFromApi(string groupName)
        {
            string address = $"{baseUrl}{groupName}";
            HttpClient client = new HttpClient();
            var result = client.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(result);
            var lessons = lessonsObject["schedule"];
            _data = lessons.ToObject<List<LessonModel>>();
        }


        public LessonStorageRepository(string groupName)
        {
            UpdateFromApi(groupName);
        }

        public IEnumerable<LessonModel> GetAllLesson()
        {
            return _data;
        }

        public IEnumerable<LessonModel> GetLesson(int day, Week weekType)
        {
            return _data.Where(i => ((i.DayOfWeek == day) && (i.WeekType == (int)weekType)) || ((i.DayOfWeek == day) && (i.WeekType == 0)))
                       .Where(i => i.Title != "Физическая культура (элективная дисциплина)");
        }
    }
}