using System;
using LittleCat.ScheduleManager.Services;
using Microsoft.AspNetCore.Mvc;
using VkApi.Wrapper;
using VkApi.Wrapper.Auth;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/VkSender")]
    public class VkSenderController : Controller
    {
        [HttpGet]
        public ActionResult SendBotMessage([FromQuery]string group, [FromQuery]string token, [FromQuery]int? chatId)
        {
            string msg = MessageGeneratorService.NextDaySchedule(group);
            var vk = new Vkontakte(6721124, apiVersion: "5.80")
            {
                AccessToken = AccessToken.FromString(token)
            };
            try
            {
                int? result = vk.Messages.Send(peerId: chatId, message: msg).Result;
                return Ok($"Result: {result}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}