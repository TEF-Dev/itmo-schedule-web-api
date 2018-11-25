using System.ComponentModel.DataAnnotations;

namespace LittleCat.ScheduleManager.Models
{
    public class ScheduleDbRecord
    {
        [Key]
        public string GroupName { get; set; }
        public string JsonScheduleData { get; set; }
    }
}