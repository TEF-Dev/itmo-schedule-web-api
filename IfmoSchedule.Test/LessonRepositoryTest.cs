using System.Linq;
using ItmoScheduleApiWrapper.Types;
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
            var lessons = ServerApiRepository.GetLessonList(GroupName);
            Assert.IsNotNull(lessons);
        }

        [TestMethod]
        public void LessonList_NotEmpty()
        {
            var lessons = ServerApiRepository.GetLessonList(GroupName);
            Assert.IsTrue(lessons.Any());
        }

        [TestMethod]
        public void DayLessonList_NotEmpty()
        {
            var lessons = ServerApiRepository.GetLessonList(GroupName, DataDayType.Monday, DataWeekType.Both);
            Assert.IsTrue(lessons.Any());
        }

        [DataRow(1, DataWeekType.Even, 3)]
        [DataRow(1, DataWeekType.Odd, 2)]
        [DataTestMethod]
        public void MondayLessonList(int day, DataWeekType weekType, int count)
        {
            var lessons = ServerApiRepository.GetLessonList(GroupName, (DataDayType)day, weekType);
            Assert.AreEqual(lessons.Count, count);
        }
    }
}
