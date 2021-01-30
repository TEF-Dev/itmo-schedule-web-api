using LittleCat.ScheduleManager.Services;
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
