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
            var generator = new ScheduleGenerator();
            var msg = generator.GenerateMessage(1, 0);

            Assert.IsTrue(msg != string.Empty);
        }
    }
}