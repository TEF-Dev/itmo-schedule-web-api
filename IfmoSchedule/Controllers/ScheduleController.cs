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
            //TODO: use api/VkSender
            var msg = ScheduleGenerator.GenerateMessage("M3205");
            VKSender.Send(msg);
            return msg;
        }

        [HttpGet("{group}")]
        public string Get(string group)
        {
            return ScheduleGenerator.GenerateMessage(group);
        }

        [HttpGet("{group}/{week:int}/{day}")]
        public string Get(string group, int week, int day)
        {
            if (week > 2 || week < 1) { return "error with week"; }
            return ScheduleGenerator.GenerateMessage(group, week, day);
        }
    }
}