using System;
using IfmoSchedule.Services;
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
            var correctString = GroupNameValidator.Validate(group);
            return ScheduleGenerator.GenerateMessage(correctString);
        }

        [HttpGet("{group}/{week:int}/{day}")]
        public string Get(string group, int week, int day)
        {
            if (week > 2 || week < 1)
                return "error with week";

            var correctString = GroupNameValidator.Validate(group);
            return ScheduleGenerator.GenerateMessage(correctString, week, day);
        }
    }
}