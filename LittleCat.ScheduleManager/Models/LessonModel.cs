using System.Linq;
using ItmoScheduleApiWrapper.Models;

namespace LittleCat.ScheduleManager.Models
{
    public static class LessonModelExtensions
    {
        public static ScheduleItemModel CropPlaceString(this ScheduleItemModel item)
        {
            //TODO: fix it
            item.Place = item.Place
                .Split(",")
                .First()
                .Replace("ул.Ломоносова", "Ломо")
                .Replace("Кронверкский пр.", "Кронв");

            return item;
        }
    }
}