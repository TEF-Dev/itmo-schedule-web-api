using System.Collections.Generic;
using System.Linq;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonModelTest
    {
        [DataTestMethod]
        [DataRow("M3200")]
        [DataRow("M3201")]
        [DataRow("M3203")]
        [DataRow("M3205")]
        [DataRow("M3206")]
        [DataRow("M3207")]
        [DataRow("M3208")]
        [DataRow("M3209")]
        [DataRow("M3210")]
        [DataRow("M3211")]
        public void ModelPropertyTest(string group)
        {
            var repository = new ServerStorageRepository();
            var list = repository.GetLessonList(group);
            Assert.IsNotNull(list);
            var data = list.First();

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

            var diff = firstList.Except(secondList);
            Assert.IsFalse(diff.Any());
        }
    }
}