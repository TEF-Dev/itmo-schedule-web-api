using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IfmoSchedule.Models;
using Newtonsoft.Json.Linq;

namespace IfmoSchedule.Repositories
{
    public class ServerStorageRepository
    {
        private const string BaseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";
        public List<LessonModel> LessonsData { get; private set; }

        public ServerStorageRepository(string groupName)
        {
            UpdateFromApi(groupName);
        }

        private void UpdateFromApi(string groupName)
        {
            var address = $"{BaseUrl}{groupName}";
            var client = new HttpClient();

            var result = client.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(result);
            LessonsData = lessonsObject["schedule"].ToObject<List<LessonModel>>();
        }

        public IEnumerable<LessonModel> GetLesson(int day, Week weekType)
        {
            return LessonsData
                .Where(i =>
                    i.DayOfWeek == day && i.WeekType == (int) weekType
                    || i.DayOfWeek == day && i.WeekType == 0)
                .Where(i => i.Title != "Физическая культура (элективная дисциплина)")
                .Where(i => i.Title != "Учебная практика, по получению первичных профессиональных умений и навыков");
        }
    }
}