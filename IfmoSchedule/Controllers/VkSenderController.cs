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
        public string SendBotMessage(string group)
        {
            if (group != "M3205")
                throw new NotImplementedException();

            var msg = MessageGeneratorService.CreateDailyMessage("M3205");
            VkSender.Send(msg);
            return msg;
        }
    }
}