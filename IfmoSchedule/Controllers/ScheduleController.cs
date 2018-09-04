using System;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using IfmoSchedule.ScheduleManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        [HttpGet("{group}")]
        public ActionResult GetNextDaySchedule(string group)
        {
            try
            {
                return Ok(MessageGeneratorService.NextDaySchedule(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("today/{group}")]
        public ActionResult GetTodaySchedule(string group)
        {
            try
            {
                return Ok(MessageGeneratorService.TodaySchedule(group));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetWithParams([FromRoute]string group, [FromRoute]int? week, [FromRoute]int? day)
        {
            if (group == null || week == null || day == null)
            {
                BadRequest("Messing argument");
            }

            if (week > 2 || week < 1)
                return BadRequest("Week incorrect. 2 код нечетной и 1 четной");
    
            try
            {
                return Ok(MessageGeneratorService.CreateDailyMessage(group, (WeekType)week, (int)day));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("update/{group}")]
        public void UpdateLocalData(string group)
        {
            var localStorage = new LocalStorageRepository();
            var storage = new ServerStorageRepository();
            localStorage.Update(group, storage.GetLessonList(group));
        }
    }
}