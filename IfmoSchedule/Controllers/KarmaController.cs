using System;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Karma")]
    public class KarmaController : Controller
    {
        [HttpGet]
        public void Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("send/{from}/{to}")]
        public string Get(string from, string to)
        {
            throw new NotImplementedException();
        }
    }
}