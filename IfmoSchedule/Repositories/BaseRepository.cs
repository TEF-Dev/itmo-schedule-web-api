using System.Collections.Generic;
using System.Linq;
using IfmoSchedule.Models;

namespace IfmoSchedule.Repositories
{
    public class BaseRepository
    {
        private List<LessonModel> _lessonList;
        public List<LessonModel> LessonList
        {
            get => _lessonList;
            protected set
            {
                _lessonList = value
                    .Where(i => i.Title != "Физическая культура (элективная дисциплина)")
                    .Where(i => i.Title != "Учебная практика, по получению первичных профессиональных умений и навыков")
                    .ToList();
            }
        }

        public IEnumerable<LessonModel> GetLesson(int day, Week weekType)
        {
            return LessonList
                .Where(i =>
                    i.DayOfWeek == day && i.WeekType == (int)weekType
                    || i.DayOfWeek == day && i.WeekType == 0);
        }
    }
}