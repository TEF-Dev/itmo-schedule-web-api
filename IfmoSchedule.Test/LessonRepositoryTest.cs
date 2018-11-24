using System.Collections.Generic;
using System.Linq;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonRepositoryTest
    {
        private const string GroupName = "M3305";
        [TestMethod]
        public void LessonList_NotNull()
        {
            List<LessonModel> lessons = ServerApiRepository.GetLessonList(GroupName);
            Assert.IsNotNull(lessons);
        }

        [TestMethod]
        public void LessonList_NotEmpty()
        {
            List<LessonModel> lessons = ServerApiRepository.GetLessonList(GroupName);
            Assert.IsTrue(lessons.Any());
        }

        [TestMethod]
        public void DayLessonList_NotEmpty()
        {
            List<LessonModel> lessons = ServerApiRepository.GetLessonList(GroupName, 1, WeekType.All);
            Assert.IsTrue(lessons.Any());
        }

        [DataRow(1, WeekType.Even, 3)]
        [DataRow(1, WeekType.Odd, 2)]
        [DataTestMethod]
        public void MondayLessonList(int day, WeekType weekType, int count)
        {
            List<LessonModel> lessons = ServerApiRepository.GetLessonList(GroupName, day, weekType);
            Assert.AreEqual(lessons.Count, count);
        }
    }
}
