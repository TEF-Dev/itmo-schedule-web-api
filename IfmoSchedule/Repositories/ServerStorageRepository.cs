using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IfmoSchedule.Models;
using Newtonsoft.Json.Linq;

namespace IfmoSchedule.Repositories
{
    public class ServerStorageRepository
    {
        private static readonly string baseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";
        private List<LessonModel> _data;


        public ServerStorageRepository(string groupName)
        {
            UpdateFromApi(groupName);
        }

        private void UpdateFromApi(string groupName)
        {
            var address = $"{baseUrl}{groupName}";
            var client = new HttpClient();

            var result = client.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(result);
            var lessons = lessonsObject["schedule"];
            _data = lessons.ToObject<List<LessonModel>>();
        }

        public IEnumerable<LessonModel> GetAllLesson()
        {
            return _data;
        }

        public IEnumerable<LessonModel> GetLesson(int day, Week weekType)
        {
            return _data
                .Where(i =>
                    i.DayOfWeek == day && i.WeekType == (int) weekType
                    || i.DayOfWeek == day && i.WeekType == 0)
                .Where(i => i.Title != "Физическая культура (элективная дисциплина)").Where(i => i.Title != "Учебная практика, по получению первичных профессиональных умений и навыков");
        }
    }
}