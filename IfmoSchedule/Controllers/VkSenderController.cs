using System;
using IfmoSchedule.ScheduleManager.Services;
using IfmoSchedule.Tools;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/VkSender")]
    public class VkSenderController : Controller
    {
        [HttpGet("{group}")]
        public ActionResult SendBotMessage(string group)
        {
            if (group != "M3305")
                throw new NotImplementedException();

            var msg = MessageGeneratorService.CreateDailyMessage("M3305");
            return Ok(VkSender.Send(msg));
        }
    }
}