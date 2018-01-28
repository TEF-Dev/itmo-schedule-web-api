using IfmoSchedule.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        // GET: api/Schedule
        [HttpGet]
        public string Get()
        {
            var msg = ScheduleGenerator.GenerateMessage("M3205");
            VKSender.Send(msg);
            return msg;
        }

        [HttpGet("{group}")]
        public string Get(string group)
        {
            var msg = ScheduleGenerator.GenerateMessage(group);
            return msg;
        }

        [HttpGet("{group}/{week:int}/{day}")]
        public string Get(string group, int week, int day)
        {
            if (week > 2 || week < 0) { return "error with week"; }
            var msg = ScheduleGenerator.GenerateMessage(group, week, day);
            return msg;
        }
    }
}