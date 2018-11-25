using System.Linq;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test.ScheduleManager
{
    [TestClass]
    public class LocalDatabaseTest
    {
        [TestMethod]
        public void CompareTest()
        {
            DbContextOptions<LocalDatabaseContext> options =
                new DbContextOptionsBuilder<LocalDatabaseContext>()
                .UseInMemoryDatabase("DatabaseTestName")
                .Options;

            using (var context = new LocalDatabaseContext(options))
            {
                var schedule = new ScheduleDbRecord
                {
                    GroupName = "test_name",
                    JsonScheduleData = "other data"
                };
                context.ScheduleDbRecords.Add(schedule);
                context.SaveChanges();
            }

            using (var context = new LocalDatabaseContext(options))
            {
                int count = context.ScheduleDbRecords.Count();
                Assert.AreEqual(1, count);

                ScheduleDbRecord u = context
                    .ScheduleDbRecords
                    .FirstOrDefault(user => 
                        user.GroupName == "test_name"
                        && user.JsonScheduleData == "other data");

                Assert.IsNotNull(u);
            }
        }
    }
}