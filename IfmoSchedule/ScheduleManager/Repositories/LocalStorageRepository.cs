using System.Collections.Generic;
using System.IO;
using System.Linq;
using IfmoSchedule.ScheduleManager.Models;
using Newtonsoft.Json;

namespace IfmoSchedule.ScheduleManager.Repositories
{
    public class LocalStorageRepository
    {
        private const string LocalBackupFileName = @"LocalBackup.json";

        public List<LessonModel> GetLessonList()
        {
            return ReadFromFile();
        }

        public List<LessonModel> GetLessonList(int day, WeekType weekType)
        {
            return ReadFromFile()
                .Where(l => l.DayOfWeek == day
                            && (l.WeekType == weekType || l.WeekType == WeekType.All))
                .ToList();
        }

        private static List<LessonModel> ReadFromFile()
        {
            if (!File.Exists(LocalBackupFileName))
                throw new FileNotFoundException(LocalBackupFileName);

            var fileData = File.ReadAllText(LocalBackupFileName);
            return JsonConvert.DeserializeObject<List<LessonModel>>(fileData);
        }
    }
}