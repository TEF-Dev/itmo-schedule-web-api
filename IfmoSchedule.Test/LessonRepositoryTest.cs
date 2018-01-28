using System.Linq;
using IfmoSchedule.Models;
using IfmoSchedule.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonRepositoryTest
    {
        [TestMethod]
        public void LessonList_NotNull()
        {
            var repo = new LessonStorageRepository();
            var lessons = repo.GetAllLesson();
            Assert.IsNotNull(lessons);
        }

        [TestMethod]
        public void LessonList_NotEmpty()
        {
            var repo = new LessonStorageRepository();
            var lessons = repo.GetAllLesson();
            Assert.IsTrue(lessons.Any());
        }

        [TestMethod]
        public void DayLessonList_NotEmpty()
        {
            var repo = new LessonStorageRepository();
            var lessons = repo.GetLesson(1, 0);
            Assert.IsTrue(lessons.Any());
        }

        [DataRow(1, 1, 4)]
        [DataRow(1, 2, 3)]
        [DataTestMethod]
        public void MondayLessonList(int day, int weekType, int count)
        {
            var repo = new LessonStorageRepository();
            var lessons = repo.GetLesson(day, (Week)weekType);
            Assert.AreEqual(lessons.Count(), count);
        }
    }
}
