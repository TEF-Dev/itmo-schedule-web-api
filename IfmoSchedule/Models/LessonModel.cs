using Newtonsoft.Json;

namespace IfmoSchedule.Models
{
    public class LessonModel
    {
        [JsonProperty("data_day")] public int? DayOfWeek { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("data_week")] public int? WeekType { get; set; }

        [JsonProperty("subj_time")] public string FullTime { get; set; }

        [JsonProperty("room")] public string Room { get; set; }

        //TODO: Custom getter
        [JsonProperty("place")] public string Place { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("person")] public string Teacher { get; set; }

        [JsonProperty("start_time")] public string TimeBegin { get; set; }

        [JsonProperty("end_time")] public string TimeEnd { get; set; }
    }
}