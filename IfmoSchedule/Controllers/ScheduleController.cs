using System;
using LittleCat.ScheduleManager.Models;
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
        public ActionResult GetWithParams([FromQuery]string group, [FromQuery]int? week, [FromQuery]int? day)
        {
            if (group == null || week == null || day == null)
            {
                var answer = "Messing argument:";
                if (group == null) answer += $" {nameof(group)}";
                if (day == null) answer += $" {nameof(day)}";
                if (week == null) answer += $" {nameof(week)}";
                return BadRequest(answer);
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
/*
            LocalStorageRepository.Update(group, ServerApiRepository.GetLessonList(group));
*/
        }
    }
}