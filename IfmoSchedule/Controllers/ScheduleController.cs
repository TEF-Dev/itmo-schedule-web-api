using System;
using LittleCat.ScheduleManager.Models;
using LittleCat.ScheduleManager.Repositories;
using LittleCat.ScheduleManager.Services;
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
                return BadRequest($"Messing argument " + group
                                                          ?? day.ToString()
                                                          ?? week.ToString()
                                                          ?? throw new Exception());
            }

            if (week != 2 && week != 1)
                return BadRequest(AnswerGeneratorService.WeekTypeException());
    
            try
            {
                return Ok(MessageGeneratorService.CreateDailyMessage(group, (WeekType)week, day.Value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("update/{group}")]
        public void UpdateLocalData(string group)
        {
            throw new NotImplementedException();
            var localStorage = new LocalStorageRepository();
            localStorage.Update(group, ServerApiRepository.GetLessonList(group));
        }
    }
}