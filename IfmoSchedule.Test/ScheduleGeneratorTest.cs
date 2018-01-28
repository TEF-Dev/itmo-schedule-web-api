using System;
using IfmoSchedule.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class ScheduleGeneratorTest
    {
        [TestMethod]
        public void MessageNotNull()
        {
            var msg = ScheduleGenerator.GenerateMessage("M3205");

            Assert.IsTrue(msg != string.Empty);
        }
    }
}