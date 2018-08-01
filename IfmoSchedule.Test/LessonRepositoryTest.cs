using System.Linq;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonRepositoryTest
    {
        private static ServerStorageRepository _repository = new ServerStorageRepository();
        private const string _groupName = "M3205";
        [TestMethod]
        public void LessonList_NotNull()
        {
            var lessons = _repository.GetLessonList(_groupName);
            Assert.IsNotNull(lessons);
        }

        [TestMethod]
        public void LessonList_NotEmpty()
        {
            var lessons = _repository.GetLessonList(_groupName);
            Assert.IsTrue(lessons.Any());
        }

        [TestMethod]
        public void DayLessonList_NotEmpty()
        {
            var lessons = _repository.GetLessonList(_groupName, 1, WeekType.All);
            Assert.IsTrue(lessons.Any());
        }

        [DataRow(0, WeekType.Even, 4)]
        [DataRow(0, WeekType.Odd, 3)]
        [DataTestMethod]
        public void MondayLessonList(int day, WeekType weekType, int count)
        {
            //TODO: fix this test
            //var lessons = _repository.GetLessonList(_groupName, day, weekType);
            //Assert.AreEqual(lessons.Count(), count);
        }
    }
}
