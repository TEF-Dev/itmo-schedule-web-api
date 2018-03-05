using System.Collections.Generic;
using System.IO;
using System.Linq;
using IfmoSchedule.Models;
using Newtonsoft.Json;

namespace IfmoSchedule.Repositories
{
    public class LocalStorageRepository : BaseRepository
    {
        private const string LocalBackupFileName = @"LocalBackup.json";

        public LocalStorageRepository()
        {
            CreateFromFile();
        }

        private void CreateFromFile()
        {
            if (!File.Exists(LocalBackupFileName)) return;

            string fileData = File.ReadAllText(LocalBackupFileName);
            LessonList = JsonConvert.DeserializeObject<List<LessonModel>>(fileData);
        }
    }
}