using System;
using IfmoSchedule.Tools;
using LittleCat.ScheduleManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/VkSender")]
    public class VkSenderController : Controller
    {
        [HttpGet]
        public ActionResult SendBotMessage([FromRoute]string group, [FromRoute]string token)
        {
            VkSender vkSender = new VkSender(token);

            var msg = MessageGeneratorService.NextDaySchedule(group);
            return Ok(vkSender.Send(msg));
        }
    }
}