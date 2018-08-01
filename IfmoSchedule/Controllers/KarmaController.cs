using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Karma")]
    public class KarmaController : Controller
    {
        // GET: api/Karma
        [HttpGet]
        public void Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Karma/5
        [HttpGet("send/{from}/{to}", Name = "Get")]
        public string Get(string from, string to)
        {
            throw new NotImplementedException();
        }
    }
}
