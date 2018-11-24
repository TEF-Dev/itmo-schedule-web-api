using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using LittleCat.ScheduleManager.Models;
using Newtonsoft.Json.Linq;

namespace LittleCat.ScheduleManager.Repositories
{
    public static class ServerApiRepository
    {
        private const string BaseUrl = "http://mountain.ifmo.ru/api.ifmo.ru/public/v1/schedule_lesson_group/";

        public static List<LessonModel> GetLessonList(string groupName, int day, WeekType weekType)
        {
            List<LessonModel> lessons = GetLessonList(groupName);

            return lessons
                ?.Where(l => l.WeekType.Compare(weekType) && l.DayOfWeek == day)
                .ToList();
        }

        public static List<LessonModel> GetLessonList(string groupName)
        {
            string address = $"{BaseUrl}{groupName}";
            
            //TODO: check timeout
            var client = new HttpClient {Timeout = TimeSpan.FromSeconds(10)};
            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(address).Result;
                string jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                JObject lessonsObject = JObject.Parse(jsonString);

                return lessonsObject["schedule"].ToObject<List<LessonModel>>();
            }
            catch (Exception)
            {
                return new List<LessonModel>();
            }
        }
    }
}