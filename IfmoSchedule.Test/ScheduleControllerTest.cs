using System;
using System.Collections.Generic;
using System.Text;
using IfmoSchedule.Controllers;
using IfmoSchedule.ScheduleManager.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class ScheduleControllerTest
    {
        [TestMethod]
        public void MessageNotNull()
        {
            string msg = MessageGeneratorService.NextDaySchedule("m3205");

            Assert.IsTrue(msg != string.Empty);
        }
    }
}
