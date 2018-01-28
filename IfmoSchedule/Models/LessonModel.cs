using Newtonsoft.Json;

namespace IfmoSchedule.Models
{
    public class LessonModel
    {
        [JsonProperty("data_day")]
        public int? DayOfWeek { get; }

        [JsonProperty("status")]
        public string Status { get; }

        [JsonProperty("data_week")]
        public int? WeekType { get; }

        [JsonProperty("subj_time")]
        public string FullTime { get; }

        [JsonProperty("room")]
        public string Room { get; }

        //TODO: Custom setter
        [JsonProperty("place")]
        public string Place { get; }

        [JsonProperty("title")]
        public string Title { get; }

        [JsonProperty("person")]
        public string Teacher { get; }

        [JsonProperty("start_time")]
        public string TimeBegin { get; }

        [JsonProperty("end_time")]
        public string TimeEnd { get; }
    }
}