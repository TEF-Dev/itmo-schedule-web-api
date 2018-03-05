using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfmoSchedule.Services;
using Microsoft.AspNetCore.Http;
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

            var msg = ScheduleGenerator.GenerateMessage("M3205");
            VkSenderService.Send(msg);
            return msg;
        }
    }
}
