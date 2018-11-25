using System.Collections.Generic;
using System.Linq;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonModelTest
    {
        [DataTestMethod]
        [DataRow("M3303")]
        [DataRow("M3305")]
        [DataRow("M3306")]
        [DataRow("M3307")]
        [DataRow("M3308")]
        [DataRow("M3309")]
        public void ModelPropertyTest(string group)
        {
            List<LessonModel> list = ServerApiRepository.GetLessonList(group);
            Assert.IsNotNull(list);
            LessonModel data = list.First();

            Assert.IsNotNull(data.DayOfWeek);
            Assert.IsNotNull(data.Place);
            //Assert.IsNotNull(data.Room);
            Assert.IsNotNull(data.Status);
            //Assert.IsNotNull(data.Teacher);
            Assert.IsNotNull(data.TimeBegin);
            Assert.IsNotNull(data.Title);
            Assert.IsNotNull(data.WeekType);
        }

        [TestMethod]
        public void CompareTest()
        {
            var first = new LessonModel
            {
                Title = "t",
                TimeBegin = "t",
                WeekType = 0,
                DayOfWeek = 0
            };
            var second = new LessonModel
            {
                Title = "t",
                TimeBegin = "t",
                WeekType = 0,
                DayOfWeek = 0
            };
            var firstList = new List<LessonModel>
            {
                first
            };
            var secondList = new List<LessonModel>
            {
                second
            };
            Assert.AreEqual(first, second);

            IEnumerable<LessonModel> diff = firstList.Except(secondList);
            Assert.IsFalse(diff.Any());
        }
    }
}