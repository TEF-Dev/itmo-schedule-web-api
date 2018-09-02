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
        public ActionResult Get(string group)
        {
            try
            {
                return Ok(MessageGeneratorService.CreateDailyMessage(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{group}/{week:int}/{day}")]
        public ActionResult Get(string group, int week, int day)
        {

            if (week > 2 || week < 1)
                return BadRequest("Week incorrect. 2 код нечетной и 1 четной");
            try
            {
                return Ok(MessageGeneratorService.CreateDailyMessage(group, (WeekType)week, day));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}