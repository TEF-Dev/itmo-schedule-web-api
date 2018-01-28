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
            return msg;
        }

        [HttpGet("{group}")]
        public string Get(string group)
        {
            var msg = ScheduleGenerator.GenerateMessage(group);
            return msg;
        }

        [HttpGet("{group}/{week}/{day}")]
        public string Get(string group, int week, int day)
        {
            //TODO: swap day and week
            var msg = ScheduleGenerator.GenerateMessage(group, day, week);
            return msg;
        }
    }
}