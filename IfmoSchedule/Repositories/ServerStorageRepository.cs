using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IfmoSchedule.Models;
using Newtonsoft.Json.Linq;

namespace IfmoSchedule.Repositories
{
    public class ServerStorageRepository : BaseRepository
    {
        private const string BaseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";

        public ServerStorageRepository(string groupName)
        {
            UpdateFromApi(groupName);
        }

        private void UpdateFromApi(string groupName)
        {
            var address = $"{BaseUrl}{groupName}";

            var client = new HttpClient();
            var httpResponseMessage = client.GetAsync(address).Result;
            var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(jsonString);

            LessonList = lessonsObject["schedule"].ToObject<List<LessonModel>>();
        }
    }
}