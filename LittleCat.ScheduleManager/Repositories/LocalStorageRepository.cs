﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LittleCat.ScheduleManager.Models;
using Newtonsoft.Json;

namespace LittleCat.ScheduleManager.Repositories
{
    public class LocalStorageRepository
    {
        private string LocalBackupFileName(string groupName) => $"LocalBackup{groupName}.json";

        public List<LessonModel> GetLessonList(string groupName)
        {
            return ReadFromFile(groupName);
        }

        public List<LessonModel> GetLessonList(string groupName, int day, WeekType weekType)
        {
            try
            {
                return ReadFromFile(groupName)
                    .Where(l => l.DayOfWeek == day
                                && (l.WeekType == weekType || l.WeekType == WeekType.All))
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public void Update(string groupName, List<LessonModel> lessons)
        {
            File.WriteAllText(LocalBackupFileName(groupName), JsonConvert.SerializeObject(lessons));
        }

        private List<LessonModel> ReadFromFile(string groupName)
        {
            if (!File.Exists(LocalBackupFileName(groupName)))
                return new List<LessonModel>();

            var fileData = File.ReadAllText(LocalBackupFileName(groupName));
            return JsonConvert.DeserializeObject<List<LessonModel>>(fileData);
        }
    }
}