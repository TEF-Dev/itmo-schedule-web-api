using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IfmoSchedule.ScheduleManager.Models;
using Newtonsoft.Json.Linq;

namespace IfmoSchedule.ScheduleManager.Repositories
{
    public class ServerStorageRepository
    {
        private const string BaseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";

        public List<LessonModel> GetLessonList(string groupName)
        {
            return GetFromApi(groupName);
        }

        public List<LessonModel> GetLessonList(string groupName, int day, WeekType weekType)
        {
            try
            {
                var lessons = GetFromApi(groupName);
                return lessons
                    .Where(l => l.DayOfWeek == day
                                && (l.WeekType == weekType || l.WeekType == WeekType.All))
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        private List<LessonModel> GetFromApi(string groupName)
        {
            var address = $"{BaseUrl}{groupName}";

            var client = new HttpClient {Timeout = TimeSpan.FromSeconds(10)};
            var httpResponseMessage = client.GetAsync(address).Result;
            var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var lessonsObject = JObject.Parse(jsonString);

            return lessonsObject["schedule"].ToObject<List<LessonModel>>();
        }
    }
}