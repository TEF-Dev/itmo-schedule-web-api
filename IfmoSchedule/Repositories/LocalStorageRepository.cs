using System.Collections.Generic;
using System.IO;
using System.Linq;
using IfmoSchedule.Models;
using Newtonsoft.Json;
//todo: fix JSON
namespace IfmoSchedule.Repositories
{
    public class LocalStorageRepository
    {
        private const string LocalBackupFileName = @"LocalBackup.json";

        private static List<LessonModel> CreateFromFile()
        {
            return File.Exists(LocalBackupFileName) ? JsonConvert.DeserializeObject<List<LessonModel>>(File.ReadAllText(LocalBackupFileName)) : null;
        }

        public IEnumerable<LessonModel> GetLesson(int day, Week weekType)
        {
            return CreateFromFile()
                ?.Where(i =>
                    i.DayOfWeek == day && i.WeekType == (int)weekType
                    || i.DayOfWeek == day && i.WeekType == 0)
                .Where(i => i.Title != "Физическая культура (элективная дисциплина)")
                .Where(i => i.Title != "Учебная практика, по получению первичных профессиональных умений и навыков");
        }
    }
}