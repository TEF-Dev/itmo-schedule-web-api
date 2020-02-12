namespace LittleCat.ScheduleManager.Repositories
{
    //TODO: implement
    public static class LocalStorageRepository
    {
        //private static DbContextOptions<LocalDatabaseContext> _options;
        //static LocalStorageRepository()
        //{
        //    _options =
        //        new DbContextOptionsBuilder<LocalDatabaseContext>()
        //            .UseInMemoryDatabase("DatabaseTestName")
        //            .Options;
        //}
        

        //public static List<LessonModel> GetLessonList(string groupName)
        //{
        //    using (var context = new LocalDatabaseContext(_options))
        //    {
        //        string jsonData = context
        //            .ScheduleDbRecords
        //            .FirstOrDefault(r => r.GroupName == groupName)
        //            ?.JsonScheduleData;
        //        if (jsonData == null)
        //            return null;
        //        return JsonConvert.DeserializeObject<List<LessonModel>>(jsonData);
        //    }
        //}

        //public static List<LessonModel> GetLessonList(string groupName, int day, DataWeekType weekType)
        //{
        //    return GetLessonList(groupName)
        //        ?.Where(l => l.DayOfWeek == day && l.WeekType.Compare(weekType))
        //        ?.ToList();
        //}

        //public static void Update(string groupName, List<LessonModel> lessons)
        //{
        //    using (var context = new LocalDatabaseContext(_options))
        //    {
        //        var entity = new ScheduleDbRecord
        //        {
        //            GroupName = groupName,
        //            JsonScheduleData = JsonConvert.SerializeObject(lessons)
        //        };
        //        context.ScheduleDbRecords.Update(entity);
        //        context.SaveChanges();
        //    }
        //}
    }
}