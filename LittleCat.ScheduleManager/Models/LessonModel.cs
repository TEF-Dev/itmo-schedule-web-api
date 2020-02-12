using System.Linq;
using ItmoScheduleApiWrapper.Helpers;
using ItmoScheduleApiWrapper.Types;
using Newtonsoft.Json;

namespace LittleCat.ScheduleManager.Models
{
    public class LessonModel
    {
        private string _place;

        [JsonProperty("data_day")] public int? DayOfWeek { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("data_week")] public DataWeekType WeekType { get; set; }
        [JsonProperty("subj_time")] public string FullTime { get; set; }
        [JsonProperty("room")] public string Room { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("person")] public string Teacher { get; set; }
        [JsonProperty("start_time")] public string TimeBegin { get; set; }
        [JsonProperty("end_time")] public string TimeEnd { get; set; }

        [JsonProperty("place")]
        public string Place
        {
            //TODO: fix it
            get => _place;
            set => _place = value?.Split(",")
                .First()
                .Replace("ул.Ломоносова", "Ломо")
                .Replace("Кронверкский пр.", "Кронв");
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LessonModel lm))
            {
                return false;
            }

            return Title == lm.Title
                   && TimeBegin == lm.TimeBegin
                   && WeekType.Compare(lm.WeekType) 
                   && DayOfWeek == lm.DayOfWeek;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _place != null ? _place.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ DayOfWeek.GetHashCode();
                hashCode = (hashCode * 397) ^ (Status != null ? Status.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ WeekType.GetHashCode();
                hashCode = (hashCode * 397) ^ (FullTime != null ? FullTime.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Room != null ? Room.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Teacher != null ? Teacher.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TimeBegin != null ? TimeBegin.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TimeEnd != null ? TimeEnd.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}