using Newtonsoft.Json;

namespace IfmoSchedule.Models
{
    public class LessonModel
    {
        private string _place;


        [JsonProperty("data_day")] public int? DayOfWeek { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("data_week")] public int? WeekType { get; set; }

        [JsonProperty("subj_time")] public string FullTime { get; set; }

        [JsonProperty("room")] public string Room { get; set; }

        [JsonProperty("place")]
        public string Place
        {
            get => _place;
            set
            {
                if (value == null)
                {
                    value = null;
                    return;
                }

                var val = value.Split(",")[0];
                if (val == "ул.Ломоносова") val = "Ломоносова";
                if (val == "Кронверкский пр.") val = "Кронверкский";

                _place = val;
            }
        }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("person")] public string Teacher { get; set; }

        [JsonProperty("start_time")] public string TimeBegin { get; set; }

        [JsonProperty("end_time")] public string TimeEnd { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as LessonModel);
        }

        public bool Equals(LessonModel lm)
        {
            return Title == lm.Title
                         && TimeBegin == lm.TimeBegin
                         && WeekType == lm.WeekType
                         && DayOfWeek == lm.DayOfWeek;
        }

        public override string ToString()
        {
            //TODO: Check
            var room = Title == "Иностранный язык" ? "" : $"ауд. {Room} ";
            var s = $"📌 {TimeBegin} -> {Title} ({Status}), {room}{Place}\n";
            return s;
        }
    }
}