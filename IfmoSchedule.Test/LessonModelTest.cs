using System.Collections.Generic;
using System.Linq;
using IfmoSchedule.Models;
using IfmoSchedule.Repositories;
using IfmoSchedule.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class LessonModelTest
    {
        [TestMethod]
        public void ModelPropertyTest()
        {
            var repository = new ServerStorageRepository("M3205");
            var list = repository.GetAllLesson();
            Assert.IsNotNull(list);
            var data = list.First();

            Assert.IsNotNull(data.DayOfWeek);
            Assert.IsNotNull(data.Place);
            Assert.IsNotNull(data.Room);
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
            Assert.IsTrue(ScheduleGenerator.CompareData(firstList, secondList));
        }
    }
}