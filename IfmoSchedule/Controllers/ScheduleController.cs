using System;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        [HttpGet("{group}")]
        public string Get(string group)
        {
            return MessageGeneratorService.CreateDailyMessage(group);
        }

        [HttpGet("{group}/{week:int}/{day}")]
        public string Get(string group, int week, int day)
        {
            if (week > 2 || week < 1)
                throw new ArgumentException("Incorrect week type");

            return MessageGeneratorService.CreateDailyMessage(group, (WeekType) week, day);
        }
    }
}