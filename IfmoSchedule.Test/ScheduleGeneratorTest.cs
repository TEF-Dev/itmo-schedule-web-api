using System;
using IfmoSchedule.ScheduleManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class ScheduleGeneratorTest
    {
        [TestMethod]
        public void MessageNotNull()
        {
            var msg = MessageGeneratorService.NextDaySchedule("M3205");

            Assert.IsTrue(msg != string.Empty);
        }
    }
}