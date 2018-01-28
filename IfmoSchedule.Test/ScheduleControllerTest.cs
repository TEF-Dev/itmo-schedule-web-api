using System;
using System.Collections.Generic;
using System.Text;
using IfmoSchedule.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IfmoSchedule.Test
{
    [TestClass]
    public class ScheduleControllerTest
    {
        [TestMethod]
        public void MessageNotNull()
        {
            var controller = new ScheduleController();
            var msg = controller.Get("m3205");
            

            Assert.IsTrue(msg != string.Empty);
        }
    }
}
